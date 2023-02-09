using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Collections.Viewable;
using JetBrains.Core;
using JetBrains.Diagnostics;
using JetBrains.Lifetimes;
using JetBrains.Rd;
using JetBrains.Rd.Base;
using JetBrains.Rd.Impl;
using JetBrains.Rd.Tasks;
using JetBrains.Rider.Model.Unity;
using JetBrains.Rider.Model.Unity.BackendUnity;
using JetBrains.Rider.Unity.Editor.NonUnity;
using JetBrains.Rider.Unity.Editor.Utils;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace JetBrains.Rider.Unity.Editor
{
  internal static class UnityEditorProtocol
  {
    private static ILog ourLogger;
    private static long ourInitTime;

    public delegate void OnModelInitializationHandler(UnityModelAndLifetime e);
    public static event OnModelInitializationHandler OnModelInitialization = delegate {};

    public static readonly List<ModelWithLifetime> Models = new List<ModelWithLifetime>();

    public static void Initialise(Lifetime lifetime, long initTime, ILog logger)
    {
      ourLogger = logger;
      ourInitTime = initTime;

      var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
      var solutionNames = new List<string> { currentDirectory.Name };

      ourLogger.Verbose("Initialising protocol. Looking for solution files");

      var solutionFiles = currentDirectory.GetFiles("*.sln", SearchOption.TopDirectoryOnly);
      foreach (var solutionFile in solutionFiles)
      {
        var solutionName = Path.GetFileNameWithoutExtension(solutionFile.FullName);
        if (!solutionName.Equals(currentDirectory.Name))
        {
          solutionNames.Add(solutionName);
        }
      }

      var protocols = new List<ProtocolInstance>();

      // If any protocol connection is lost, we will drop all connections and recreate them
      var allProtocolsLifetimeDefinition = lifetime.CreateNested();
      foreach (var solutionName in solutionNames)
      {
        var port = CreateProtocolForSolution(allProtocolsLifetimeDefinition.Lifetime, solutionName,
          () => allProtocolsLifetimeDefinition.Terminate());

        if (port == -1)
          continue;

        protocols.Add(new ProtocolInstance(solutionName, port));
      }

      allProtocolsLifetimeDefinition.Lifetime.OnTermination(() =>
      {
        if (lifetime.IsAlive)
        {
          ourLogger.Verbose("Recreating protocol, project lifetime is alive");
          Initialise(lifetime, initTime, logger);
        }
        else
        {
          ourLogger.Verbose("Protocol will be recreated on next domain load, plugin lifetime is not alive");
        }
      });

      ourLogger.Verbose("Writing Library/ProtocolInstance.json");
      var protocolInstancePath = Path.GetFullPath("Library/ProtocolInstance.json");
      var result = ProtocolInstance.ToJson(protocols);
      File.WriteAllText(protocolInstancePath, result);

      // TODO: Will this cause problems if we call Initialise a second time?
      // Perhaps we need another lifetime?
      lifetime.OnTermination(() =>
      {
        ourLogger.Verbose("Deleting Library/ProtocolInstance.json");
        File.Delete(protocolInstancePath);
      });
    }

    private static int CreateProtocolForSolution(Lifetime lifetime, string solutionName, Action onDisconnected)
    {
      ourLogger.Verbose($"Initialising protocol for {solutionName}");
      try
      {
        var dispatcher = MainThreadDispatcher.Instance;
        var currentWireAndProtocolLifetimeDef = lifetime.CreateNested();
        var currentWireAndProtocolLifetime = currentWireAndProtocolLifetimeDef.Lifetime;

        var riderProtocolController = new RiderProtocolController(dispatcher, currentWireAndProtocolLifetime);

        var serializers = new Serializers();
        var identities = new Identities(IdKind.Server);

        MainThreadDispatcher.AssertThread();
        var protocol = new Protocol("UnityEditorPlugin" + solutionName, serializers, identities, MainThreadDispatcher.Instance, riderProtocolController.Wire, currentWireAndProtocolLifetime);
        riderProtocolController.Wire.Connected.WhenTrue(currentWireAndProtocolLifetime, connectionLifetime =>
        {
          ourLogger.Log(LoggingLevel.VERBOSE, "Create UnityModel and advise for new sessions...");

          var model = new BackendUnityModel(connectionLifetime, protocol);

          AdviseUnityActions(model, connectionLifetime);
          AdviseEditorState(model);
          OnModelInitialization(new UnityModelAndLifetime(model, connectionLifetime));
          AdviseRefresh(model);

          var paths = GetLogPaths();
          model.UnityApplicationData.SetValue(new UnityApplicationData(
              EditorApplication.applicationPath,
              EditorApplication.applicationContentsPath,
              UnityUtils.UnityApplicationVersion,
              paths[0], paths[1],
              Process.GetCurrentProcess().Id));

          model.UnityApplicationSettings.ScriptCompilationDuringPlay.Set(UnityUtils.SafeScriptCompilationDuringPlay);
          model.UnityProjectSettings.ScriptingRuntime.SetValue(UnityUtils.ScriptingRuntime);

          AdviseShowPreferences(model, connectionLifetime, ourLogger);
          AdviseGenerateUISchema(model);
          AdviseExitUnity(model);
          GetBuildLocation(model);
          AdviseRunMethod(model);
          AdviseStartProfiling(model);
          AdviseLoggingStateChangeTimes(connectionLifetime, model);

          ourLogger.Verbose("UnityModel initialized.");
          var pair = new ModelWithLifetime(model, connectionLifetime);
          connectionLifetime.OnTermination(() => { Models.Remove(pair); });
          Models.Add(pair);

          connectionLifetime.OnTermination(() =>
          {
              ourLogger.Verbose($"Connection lifetime is not alive for {solutionName}, destroying protocol");
              onDisconnected();
          });
        });

        return riderProtocolController.Wire.Port;
      }
      catch (Exception ex)
      {
        ourLogger.Error("Init Rider Plugin " + ex);
        return -1;
      }
    }

    private static void AdviseUnityActions(BackendUnityModel model, Lifetime connectionLifetime)
    {
      var syncPlayState = new Action(() =>
      {
        MainThreadDispatcher.Instance.Queue(() =>
        {
          var isPlaying = EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying;

          if (!model.PlayControls.Play.HasValue() || model.PlayControls.Play.HasValue() && model.PlayControls.Play.Value != isPlaying)
          {
            ourLogger.Verbose("Reporting play mode change to model: {0}", isPlaying);
            model.PlayControls.Play.SetValue(isPlaying);
          }

          var isPaused = EditorApplication.isPaused;
          if (!model.PlayControls.Pause.HasValue() || model.PlayControls.Pause.HasValue() && model.PlayControls.Pause.Value != isPaused)
          {
            ourLogger.Verbose("Reporting pause mode change to model: {0}", isPaused);
            model.PlayControls.Pause.SetValue(isPaused);
          }
        });
      });

      syncPlayState();

      model.PlayControls.Play.Advise(connectionLifetime, play =>
      {
        MainThreadDispatcher.Instance.Queue(() =>
        {
          var current = EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying;
          if (current != play)
          {
            ourLogger.Verbose("Request to change play mode from model: {0}", play);
            EditorApplication.isPlaying = play;
          }
        });
      });

      model.PlayControls.Pause.Advise(connectionLifetime, pause =>
      {
        MainThreadDispatcher.Instance.Queue(() =>
        {
          ourLogger.Verbose("Request to change pause mode from model: {0}", pause);
          EditorApplication.isPaused = pause;
        });
      });

      model.PlayControls.Step.Advise(connectionLifetime, x =>
      {
        MainThreadDispatcher.Instance.Queue(EditorApplication.Step);
      });

      PlayModeStateTracker.Current.Advise(connectionLifetime, _ => syncPlayState());
    }

    private static void AdviseEditorState(BackendUnityModel modelValue)
    {
      modelValue.GetUnityEditorState.Set(rdVoid =>
      {
        if (EditorApplication.isPaused)
          return UnityEditorState.Pause;

        if (EditorApplication.isPlaying)
          return UnityEditorState.Play;

        if (EditorApplication.isCompiling || EditorApplication.isUpdating)
          return UnityEditorState.Refresh;

        return UnityEditorState.Idle;
      });
    }

    private static void AdviseRefresh(BackendUnityModel model)
    {
      model.Refresh.Set((l, force) =>
      {
        var refreshTask = new RdTask<Unit>();
        void SendResult()
        {
          if (!EditorApplication.isCompiling)
          {
            // ReSharper disable once DelegateSubtraction
            EditorApplication.update -= SendResult;
            ourLogger.Verbose("Refresh: SyncSolution Completed");
            refreshTask.Set(Unit.Instance);
          }
        }

        ourLogger.Verbose("Refresh: SyncSolution Enqueue");
        MainThreadDispatcher.Instance.Queue(() =>
        {
          if (!EditorApplication.isPlaying && EditorPrefsWrapper.AutoRefresh || force != RefreshType.Normal)
          {
            try
            {
              if (force == RefreshType.ForceRequestScriptReload)
              {
                ourLogger.Verbose("Refresh: RequestScriptReload");
                UnityEditorInternal.InternalEditorUtility.RequestScriptReload();
              }

              ourLogger.Verbose("Refresh: SyncSolution Started");
              RiderPackageInterop.SyncSolution();
            }
            catch (Exception e)
            {
              ourLogger.Error(e, "Refresh failed with exception");
            }
            finally
            {
              EditorApplication.update += SendResult;
            }
          }
          else
          {
            if (EditorApplication.isPlaying)
            {
              refreshTask.Set(Unit.Instance);
              ourLogger.Verbose("Avoid calling Refresh, when EditorApplication.isPlaying.");
            }
            else if (!EditorPrefsWrapper.AutoRefresh)
            {
              refreshTask.Set(Unit.Instance);
              ourLogger.Verbose("AutoRefresh is disabled by Unity preferences.");
            }
            else
            {
              refreshTask.Set(Unit.Instance);
              ourLogger.Verbose("Avoid calling Refresh, for the unknown reason.");
            }
          }
        });
        return refreshTask;
      });
    }

    private static string[] GetLogPaths()
    {
      // https://docs.unity3d.com/Manual/LogFiles.html
      //PlayerSettings.productName;
      //PlayerSettings.companyName;
      //~/Library/Logs/Unity/Editor.log
      //C:\Users\username\AppData\Local\Unity\Editor\Editor.log
      //~/.config/unity3d/Editor.log

      var editorLogPath = string.Empty;
      var playerLogPath = string.Empty;

      switch (PluginSettings.SystemInfoRiderPlugin.operatingSystemFamily)
      {
        case OperatingSystemFamilyRider.Windows:
        {
          var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
          editorLogPath = Path.Combine(localAppData, @"Unity\Editor\Editor.log");
          var userProfile = Environment.GetEnvironmentVariable("USERPROFILE");
          if (!string.IsNullOrEmpty(userProfile))
          {
            playerLogPath = Path.Combine(
              Path.Combine(Path.Combine(Path.Combine(userProfile, @"AppData\LocalLow"), PlayerSettings.companyName),
                PlayerSettings.productName), "output_log.txt");
          }

          break;
        }
        case OperatingSystemFamilyRider.MacOSX:
        {
          var home = Environment.GetEnvironmentVariable("HOME");
          if (!string.IsNullOrEmpty(home))
          {
            editorLogPath = Path.Combine(home, "Library/Logs/Unity/Editor.log");
            playerLogPath = Path.Combine(home, "Library/Logs/Unity/Player.log");
          }

          break;
        }
        case OperatingSystemFamilyRider.Linux:
        {
          var home = Environment.GetEnvironmentVariable("HOME");
          if (!string.IsNullOrEmpty(home))
          {
            editorLogPath = Path.Combine(home, ".config/unity3d/Editor.log");
            playerLogPath = Path.Combine(home,
              $".config/unity3d/{PlayerSettings.companyName}/{PlayerSettings.productName}/Player.log");
          }

          break;
        }
      }

      return new[] { editorLogPath, playerLogPath };
    }

    private static void AdviseShowPreferences(BackendUnityModel model, Lifetime connectionLifetime, ILog log)
    {
      model.ShowPreferences.Advise(connectionLifetime, result =>
      {
        if (result != null)
        {
          MainThreadDispatcher.Instance.Queue(() =>
          {
            try
            {
              var tab = UnityUtils.UnityVersion >= new Version(2018, 2) ? "_General" : "Rider";

              var type = typeof(SceneView).Assembly.GetType("UnityEditor.SettingsService");
              if (type != null)
              {
                // 2018+
                var method = type.GetMethod("OpenUserPreferences", BindingFlags.Static | BindingFlags.Public);

                if (method == null)
                {
                  log.Error("'OpenUserPreferences' was not found");
                }
                else
                {
                  method.Invoke(null, new object[] {$"Preferences/{tab}"});
                }
              }
              else
              {
                // 5.5, 2017 ...
                type = typeof(SceneView).Assembly.GetType("UnityEditor.PreferencesWindow");
                var method = type?.GetMethod("ShowPreferencesWindow", BindingFlags.Static | BindingFlags.NonPublic);

                if (method == null)
                {
                  log.Error("'ShowPreferencesWindow' was not found");
                }
                else
                {
                  method.Invoke(null, null);
                }
              }
            }
            catch (Exception ex)
            {
              log.Error("Show preferences " + ex);
            }
          });
        }
      });
    }

    private static void AdviseGenerateUISchema(BackendUnityModel model)
    {
      model.GenerateUIElementsSchema.Set(_ => UIElementsSupport.GenerateSchema());
    }

    private static void AdviseExitUnity(BackendUnityModel model)
    {
      model.ExitUnity.Set((_, rdVoid) =>
      {
        var task = new RdTask<bool>();
        MainThreadDispatcher.Instance.Queue(() =>
        {
          try
          {
            ourLogger.Verbose("ExitUnity: Started");
            EditorApplication.Exit(0);
            ourLogger.Verbose("ExitUnity: Completed");
            task.Set(true);
          }
          catch (Exception e)
          {
            ourLogger.Log(LoggingLevel.WARN, "EditorApplication.Exit failed.", e);
            task.Set(false);
          }
        });
        return task;
      });
    }

    private static void GetBuildLocation(BackendUnityModel model)
    {
        var path = EditorUserBuildSettings.GetBuildLocation(EditorUserBuildSettings.selectedStandaloneTarget);
        if (PluginSettings.SystemInfoRiderPlugin.operatingSystemFamily == OperatingSystemFamilyRider.MacOSX)
            path = Path.Combine(Path.Combine(Path.Combine(path, "Contents"), "MacOS"), PlayerSettings.productName);
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
            model.UnityProjectSettings.BuildLocation.Value = path;
    }

    private static void AdviseRunMethod(BackendUnityModel model)
    {
        model.RunMethodInUnity.Set((lifetime, data) =>
        {
            var task = new RdTask<RunMethodResult>();
            MainThreadDispatcher.Instance.Queue(() =>
            {
                if (!lifetime.IsAlive)
                {
                    task.SetCancelled();
                    return;
                }

                try
                {
                    ourLogger.Verbose($"Attempt to execute {data.MethodName}");
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    var assembly = assemblies
                        .FirstOrDefault(a => a.GetName().Name.Equals(data.AssemblyName));
                    if (assembly == null)
                        throw new Exception($"Could not find {data.AssemblyName} assembly in current AppDomain");

                    var type = assembly.GetType(data.TypeName);
                    if (type == null)
                        throw new Exception($"Could not find {data.TypeName} in assembly {data.AssemblyName}.");

                    var method = type.GetMethod(data.MethodName,BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

                    if (method == null)
                        throw new Exception($"Could not find {data.MethodName} in type {data.TypeName}");

                    try
                    {
                        method.Invoke(null, null);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }

                    task.Set(new RunMethodResult(true, string.Empty, string.Empty));
                }
                catch (Exception e)
                {
                    ourLogger.Log(LoggingLevel.WARN, $"Execute {data.MethodName} failed.", e);
                    task.Set(new RunMethodResult(false, e.Message, e.StackTrace));
                }
            });
            return task;
        });
    }

    private static void AdviseStartProfiling(BackendUnityModel model)
    {
        model.StartProfiling.Set((lifetime, data) =>
        {
            MainThreadDispatcher.Instance.Queue(() =>
            {
                try
                {
                    UnityProfilerApiInterop.StartProfiling(data.UnityProfilerApiPath, data.NeedRestartScripts);

                    var current = EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying;
                    if (current != data.EnterPlayMode)
                    {
                        ourLogger.Verbose("StartProfiling. Request to change play mode from model: {0}", data.EnterPlayMode);
                        EditorApplication.isPlaying = data.EnterPlayMode;
                    }
                }
                catch (Exception e)
                {
                    if (PluginSettings.SelectedLoggingLevel >= LoggingLevel.VERBOSE)
                        Debug.LogError(e);
                    throw;
                }
            });

            return Unit.Instance;
        });

        model.StopProfiling.Set((_, data) =>
        {
            MainThreadDispatcher.Instance.Queue(() =>
            {
                try
                {
                    UnityProfilerApiInterop.StopProfiling(data.UnityProfilerApiPath);
                }
                catch (Exception e)
                {
                    if (PluginSettings.SelectedLoggingLevel >= LoggingLevel.VERBOSE)
                        Debug.LogError(e);
                    throw;
                }
            });

            return Unit.Instance;
        });
    }

    private static void AdviseLoggingStateChangeTimes(Lifetime modelLifetime, BackendUnityModel model)
    {
        model.ConsoleLogging.LastInitTime.SetValue(ourInitTime);

        PlayModeStateTracker.Current.Advise(modelLifetime, state =>
        {
          if (state == PlayModeState.Playing)
            model.ConsoleLogging.LastPlayTime.Value = DateTime.UtcNow.Ticks;
        });
    }
  }

  public struct UnityModelAndLifetime
  {
    public readonly BackendUnityModel Model;
    public Lifetime Lifetime;

    public UnityModelAndLifetime(BackendUnityModel model, Lifetime lifetime)
    {
      Model = model;
      Lifetime = lifetime;
    }
  }
}