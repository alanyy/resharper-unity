﻿namespace JetBrains.ReSharper.Plugins.Unity.Resources
{
  using System;
  using JetBrains.Application.I18n;
  using JetBrains.DataFlow;
  using JetBrains.Diagnostics;
  using JetBrains.Lifetimes;
  using JetBrains.Util;
  using JetBrains.Util.Logging;
  
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
  [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
  public static class Strings
  {
    private static readonly ILogger ourLog = Logger.GetLogger("JetBrains.ReSharper.Plugins.Unity.Resources.Strings");

    static Strings()
    {
      CultureContextComponent.Instance.WhenNotNull(Lifetime.Eternal, (lifetime, instance) =>
      {
        lifetime.Bracket(() =>
          {
            ourResourceManager = new Lazy<JetResourceManager>(
              () =>
              {
                return instance
                  .CreateResourceManager("JetBrains.ReSharper.Plugins.Unity.Resources.Strings", typeof(Strings).Assembly);
              });
          },
          () =>
          {
            ourResourceManager = null;
          });
      });
    }
    
    private static Lazy<JetResourceManager> ourResourceManager = null;
    
    [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    public static JetResourceManager ResourceManager
    {
      get
      {
        var resourceManager = ourResourceManager;
        if (resourceManager == null)
        {
          return ErrorJetResourceManager.Instance;
        }
        return resourceManager.Value;
      }
    }

    public static string AccessingManagedMethodsIsNotSupported => ResourceManager.GetString("AccessingManagedMethodsIsNotSupported");
    public static string AccessingMultidimensionalArraysIsInefficientUseAJaggedOrOneDimensionalArrayInsteadMessage => ResourceManager.GetString("AccessingMultidimensionalArraysIsInefficientUseAJaggedOrOneDimensionalArrayInsteadMessage");
    public static string AlternativeNonAllocatingMethodAvailable => ResourceManager.GetString("AlternativeNonAllocatingMethodAvailable");
    public static string AnAlternativeMethodIsAvailableThatAvoidsAllocationAndReusesAnExistingBuffer => ResourceManager.GetString("AnAlternativeMethodIsAvailableThatAvoidsAllocationAndReusesAnExistingBuffer");
    public static string ApplyingAnAttributeToASingleDeclarationContainingMultipleFieldsWillApplyTheAttributeToEachFieldTheHighlightedAttributeEGFormerlySerializedAsIsIntendedToBeAppliedOnlyToASingleFieldPreferAnExplicitApplicationToASingleFieldInASingleDeclaration => ResourceManager.GetString("ApplyingAnAttributeToASingleDeclarationContainingMultipleFieldsWillApplyTheAttributeToEachFieldTheHighlightedAttributeEGFormerlySerializedAsIsIntendedToBeAppliedOnlyToASingleFieldPreferAnExplicitApplicationToASingleFieldInASingleDeclaration");
    public static string AsmDefGuidReferenceInlayHintHighlighting_ContextMenuTitle_GUID_Reference_Hints => ResourceManager.GetString("AsmDefGuidReferenceInlayHintHighlighting_ContextMenuTitle_GUID_Reference_Hints");
    public static string AsmDefIntraTextAdornmentModel_BuildContextMenuItems_Configure___ => ResourceManager.GetString("AsmDefIntraTextAdornmentModel_BuildContextMenuItems_Configure___");
    public static string AsmDefOccurrenceKindProvider_AssemblyDefinitionReference_Assembly_definition_reference => ResourceManager.GetString("AsmDefOccurrenceKindProvider_AssemblyDefinitionReference_Assembly_definition_reference");
    public static string AsmDefPackageVersionInlayHintHighlighting_ContextMenuTitle_Package_Version_Hints => ResourceManager.GetString("AsmDefPackageVersionInlayHintHighlighting_ContextMenuTitle_Package_Version_Hints");
    public static string AsmDefProjectFileType_AsmDefProjectFileType_Assembly_Definition__Unity_ => ResourceManager.GetString("AsmDefProjectFileType_AsmDefProjectFileType_Assembly_Definition__Unity_");
    public static string AsmRefProjectFileType_AsmRefProjectFileType_Assembly_Definition_Reference__Unity_ => ResourceManager.GetString("AsmRefProjectFileType_AsmRefProjectFileType_Assembly_Definition_Reference__Unity_");
    public static string AttributeIsRedundantOnThisDeclarationTypeItIsOnlyUsedWhenAppliedToDeclarationsMessage => ResourceManager.GetString("AttributeIsRedundantOnThisDeclarationTypeItIsOnlyUsedWhenAppliedToDeclarationsMessage");
    public static string AttributeIsRedundantWhenAppliedToThisDeclarationType => ResourceManager.GetString("AttributeIsRedundantWhenAppliedToThisDeclarationType");
    public static string AvoidbaseOnGUIInClassesDerivedFromPropertyDrawer => ResourceManager.GetString("AvoidbaseOnGUIInClassesDerivedFromPropertyDrawer");
    public static string baseOnGUIWillPrintNoGUIImplementedInTheUnityInspectorMessage => ResourceManager.GetString("baseOnGUIWillPrintNoGUIImplementedInTheUnityInspectorMessage");
    public static string BoxingIsNotSupported => ResourceManager.GetString("BoxingIsNotSupported");
    public static string BurstAccessingManagedMethodFromTypeIsNotSupportedMessage => ResourceManager.GetString("BurstAccessingManagedMethodFromTypeIsNotSupportedMessage");
    public static string BurstBoxingIsNotSupportedMessage => ResourceManager.GetString("BurstBoxingIsNotSupportedMessage");
    public static string BurstCompiledCode_Text => ResourceManager.GetString("BurstCompiledCode_Text");
    public static string BurstCreatingAManagedTypeIsNotSupportedMessage => ResourceManager.GetString("BurstCreatingAManagedTypeIsNotSupportedMessage");
    public static string BurstDebugLoggingFunctionsAcceptsOnlyStringsMessage => ResourceManager.GetString("BurstDebugLoggingFunctionsAcceptsOnlyStringsMessage");
    public static string BurstLoadingFromANonReadonlyStaticFieldIsNotSupportedMessage => ResourceManager.GetString("BurstLoadingFromANonReadonlyStaticFieldIsNotSupportedMessage");
    public static string BurstLoadingManagedTypeIsNotSupportedMessage => ResourceManager.GetString("BurstLoadingManagedTypeIsNotSupportedMessage");
    public static string BurstSignatureContainsManagedTypesMessage => ResourceManager.GetString("BurstSignatureContainsManagedTypesMessage");
    public static string BurstTheforeachConstructionIsNotSupportedMessage => ResourceManager.GetString("BurstTheforeachConstructionIsNotSupportedMessage");
    public static string BurstThisMethodIsAvailableInCOnlyNotHPCMessage => ResourceManager.GetString("BurstThisMethodIsAvailableInCOnlyNotHPCMessage");
    public static string BurstTryStatementIsNotSupportedMessage => ResourceManager.GetString("BurstTryStatementIsNotSupportedMessage");
    public static string BurstTypeofIsProhibitedMessage => ResourceManager.GetString("BurstTypeofIsProhibitedMessage");
    public static string BurstWritingToAStaticFieldIsNotSupportedMessage => ResourceManager.GetString("BurstWritingToAStaticFieldIsNotSupportedMessage");
    public static string CameraMainIsExpensive => ResourceManager.GetString("CameraMainIsExpensive");
    public static string CameraMainIsExpensiveMessage => ResourceManager.GetString("CameraMainIsExpensiveMessage");
    public static string CameraMainIsSlowAndDoesNotCacheItsResultUsingCameraMainInFrequentlyCalledMethodsIsVeryInefficientPreferCachingTheResultInStartOrAwake => ResourceManager.GetString("CameraMainIsSlowAndDoesNotCacheItsResultUsingCameraMainInFrequentlyCalledMethodsIsVeryInefficientPreferCachingTheResultInStartOrAwake");
    public static string CannotReferenceSelfMessage => ResourceManager.GetString("CannotReferenceSelfMessage");
    public static string CannotResolveComponentOrScriptableObject => ResourceManager.GetString("CannotResolveComponentOrScriptableObject");
    public static string CannotResolveSymbolMessage => ResourceManager.GetString("CannotResolveSymbolMessage");
    public static string ComparisonTonullIsExpensiveMessage => ResourceManager.GetString("ComparisonTonullIsExpensiveMessage");
    public static string ConvertToNamedAssemblyDefinitionReference_Description => ResourceManager.GetString("ConvertToNamedAssemblyDefinitionReference_Description");
    public static string ConvertToNamedAssemblyDefinitionReference_Name => ResourceManager.GetString("ConvertToNamedAssemblyDefinitionReference_Name");
    public static string ConvertToNamedReferenceContextAction_Text_To_named_reference => ResourceManager.GetString("ConvertToNamedReferenceContextAction_Text_To_named_reference");
    public static string CreatingAManagedTypeIsNotSupported => ResourceManager.GetString("CreatingAManagedTypeIsNotSupported");
    public static string DebugLoggingFunctionsAcceptsOnlyStrings => ResourceManager.GetString("DebugLoggingFunctionsAcceptsOnlyStrings");
    public static string DisabledIndexingOfUnityAssets_Text => ResourceManager.GetString("DisabledIndexingOfUnityAssets_Text");
    public static string DueToTheSizeOfTheProjectIndexingOfUnity_Text => ResourceManager.GetString("DueToTheSizeOfTheProjectIndexingOfUnity_Text");
    public static string DuplicateMenuItemShortCutProblemAnalyzer_Analyze_this_file => ResourceManager.GetString("DuplicateMenuItemShortCutProblemAnalyzer_Analyze_this_file");
    public static string EmptyUnityEventFunctionsAreStillCalledFromNativeCodeWhichAffectsPerformance => ResourceManager.GetString("EmptyUnityEventFunctionsAreStillCalledFromNativeCodeWhichAffectsPerformance");
    public static string EqualityOperationsOnObjectsDerivingFromUnityEngineObjectWillAlsoCheckThatTheUnderlyingNativeObjectHasNotBeenDestroyedThisRequiresACallIntoNativeCodeAndCanHaveAPerformanceImpactWhenUsedInsideFrequentlyCalledMethods => ResourceManager.GetString("EqualityOperationsOnObjectsDerivingFromUnityEngineObjectWillAlsoCheckThatTheUnderlyingNativeObjectHasNotBeenDestroyedThisRequiresACallIntoNativeCodeAndCanHaveAPerformanceImpactWhenUsedInsideFrequentlyCalledMethods");
    public static string EventFunctionWithTheSameNameIsAlreadyDeclared => ResourceManager.GetString("EventFunctionWithTheSameNameIsAlreadyDeclared");
    public static string EventFunctionWithTheSameNameIsAlreadyDeclared2 => ResourceManager.GetString("EventFunctionWithTheSameNameIsAlreadyDeclared2");
    public static string EventFunctionWithTheSameNameIsAlreadyDeclaredMessage => ResourceManager.GetString("EventFunctionWithTheSameNameIsAlreadyDeclaredMessage");
    public static string ExpectedAMethodWithSignatureMessage => ResourceManager.GetString("ExpectedAMethodWithSignatureMessage");
    public static string ExpectedBuiltInTypeDerivedFromComponentOrUserTypeDerivedFromMonoBehaviour => ResourceManager.GetString("ExpectedBuiltInTypeDerivedFromComponentOrUserTypeDerivedFromMonoBehaviour");
    public static string ExpectedTypeDerivedFromComponentOrMonoBehaviour => ResourceManager.GetString("ExpectedTypeDerivedFromComponentOrMonoBehaviour");
    public static string ExpectedTypeDerivedFromMessage => ResourceManager.GetString("ExpectedTypeDerivedFromMessage");
    public static string ExpectedTypeDerivedFromScriptableObject => ResourceManager.GetString("ExpectedTypeDerivedFromScriptableObject");
    public static string ExpectedTypeDerivedFromScriptableObject3 => ResourceManager.GetString("ExpectedTypeDerivedFromScriptableObject3");
    public static string ExpectedTypeDerivedFromUnityEngineScriptableObjectMessage => ResourceManager.GetString("ExpectedTypeDerivedFromUnityEngineScriptableObjectMessage");
    public static string ExpensiveMethodInvocation => ResourceManager.GetString("ExpensiveMethodInvocation");
    public static string ExpensiveMethodInvocationMessage => ResourceManager.GetString("ExpensiveMethodInvocationMessage");
    public static string ExpensiveNullComparison => ResourceManager.GetString("ExpensiveNullComparison");
    public static string ExplicitStringComparisonIsInefficientUseCompareTagInsteadMessage => ResourceManager.GetString("ExplicitStringComparisonIsInefficientUseCompareTagInsteadMessage");
    public static string ExplicitStringComparisonWithGameObjectTagOrComponentTagIsInefficientUseTheCompareTagMethodInstead => ResourceManager.GetString("ExplicitStringComparisonWithGameObjectTagOrComponentTagIsInefficientUseTheCompareTagMethodInstead");
    public static string FileNameShouldMatchTheNameOfTheAssembly => ResourceManager.GetString("FileNameShouldMatchTheNameOfTheAssembly");
    public static string FileNameShouldMatchTheNameOfTheAssemblyMessage => ResourceManager.GetString("FileNameShouldMatchTheNameOfTheAssemblyMessage");
    public static string FunctionSignatureCannotContainManagedTypes => ResourceManager.GetString("FunctionSignatureCannotContainManagedTypes");
    public static string IncorrectMethodParametersExpectedMessage => ResourceManager.GetString("IncorrectMethodParametersExpectedMessage");
    public static string IncorrectMethodSignature => ResourceManager.GetString("IncorrectMethodSignature");
    public static string IncorrectMethodSignatureExpectedMessage => ResourceManager.GetString("IncorrectMethodSignatureExpectedMessage");
    public static string IncorrectMethodSignatureMessage => ResourceManager.GetString("IncorrectMethodSignatureMessage");
    public static string IncorrectReturnTypeExpectedMessage => ResourceManager.GetString("IncorrectReturnTypeExpectedMessage");
    public static string IncorrectTypeParametersMessage => ResourceManager.GetString("IncorrectTypeParametersMessage");
    public static string InitializeOnLoadAttributeIsRedundantWhenStaticConstructorIsMissingMessage => ResourceManager.GetString("InitializeOnLoadAttributeIsRedundantWhenStaticConstructorIsMissingMessage");
    public static string InstantiatingAUnityObjectAndSettingTheparentPropertyAsSeparateOperationsIsInefficientAsTheTransformHierarchyIsCreatedAndImmediatelyReplacedCombineSettingTheparentPropertyWithTheCallToInstantiateTheObject => ResourceManager.GetString("InstantiatingAUnityObjectAndSettingTheparentPropertyAsSeparateOperationsIsInefficientAsTheTransformHierarchyIsCreatedAndImmediatelyReplacedCombineSettingTheparentPropertyWithTheCallToInstantiateTheObject");
    public static string InvalidDefineConstraintExpressionMessage => ResourceManager.GetString("InvalidDefineConstraintExpressionMessage");
    public static string InvalidVersionDefineExpressionMessage => ResourceManager.GetString("InvalidVersionDefineExpressionMessage");
    public static string InvalidVersionDefineSymbolMessage => ResourceManager.GetString("InvalidVersionDefineSymbolMessage");
    public static string LoadingFromANonReadonlyStaticFieldIsNotSupported => ResourceManager.GetString("LoadingFromANonReadonlyStaticFieldIsNotSupported");
    public static string LoadingManagedTypeIsNotSupported => ResourceManager.GetString("LoadingManagedTypeIsNotSupported");
    public static string Message => ResourceManager.GetString("Message");
    public static string MetaProjectFileType_MetaProjectFileType_Unity_Meta_File => ResourceManager.GetString("MetaProjectFileType_MetaProjectFileType_Unity_Meta_File");
    public static string MethodDoesNotMatchExpectedSignature => ResourceManager.GetString("MethodDoesNotMatchExpectedSignature");
    public static string MethodReferencedInStringLiteralDoesNotHaveTheExpectedSignature => ResourceManager.GetString("MethodReferencedInStringLiteralDoesNotHaveTheExpectedSignature");
    public static string MethodReferencedInStringLiteralDoesNotHaveTheExpectedSignature5 => ResourceManager.GetString("MethodReferencedInStringLiteralDoesNotHaveTheExpectedSignature5");
    public static string MissingAssemblyReferenceAssemblyWillNotBeReferencedDuringCompilationMessage => ResourceManager.GetString("MissingAssemblyReferenceAssemblyWillNotBeReferencedDuringCompilationMessage");
    public static string MonoBehaviourInstancesMustBeInstantiatedWithGameObjectAddComponentTInsteadOfnew => ResourceManager.GetString("MonoBehaviourInstancesMustBeInstantiatedWithGameObjectAddComponentTInsteadOfnew");
    public static string MonoBehaviourInstancesMustBeInstantiatedWithGameObjectAddComponentTInsteadOfnewMessage => ResourceManager.GetString("MonoBehaviourInstancesMustBeInstantiatedWithGameObjectAddComponentTInsteadOfnewMessage");
    public static string MultidimensionalArrayElementAccessIsConvertedToAMethodCallItIsMoreEfficientToUseAJaggedOrOneDimensionalArray => ResourceManager.GetString("MultidimensionalArrayElementAccessIsConvertedToAMethodCallItIsMoreEfficientToUseAJaggedOrOneDimensionalArray");
    public static string OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObject => ResourceManager.GetString("OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObject");
    public static string OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObject6 => ResourceManager.GetString("OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObject6");
    public static string OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObjectMessage => ResourceManager.GetString("OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObjectMessage");
    public static string OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObjectMessage1 => ResourceManager.GetString("OnATypeDerivingFromUnityEngineObjectBypassesTheLifetimeCheckOnTheUnderlyingUnityEngineObjectMessage1");
    public static string OrderOfMultiplicationOperationsIsInefficient => ResourceManager.GetString("OrderOfMultiplicationOperationsIsInefficient");
    public static string OrderOfMultiplicationOperationsIsInefficientMessage => ResourceManager.GetString("OrderOfMultiplicationOperationsIsInefficientMessage");
    public static string ParameterShouldBeDerivedFromComponent => ResourceManager.GetString("ParameterShouldBeDerivedFromComponent");
    public static string ParameterShouldBeDerivedFromComponent4 => ResourceManager.GetString("ParameterShouldBeDerivedFromComponent4");
    public static string ParameterShouldBeDerivedFromComponentMessage => ResourceManager.GetString("ParameterShouldBeDerivedFromComponentMessage");
    public static string PossibleIncorrectApplicationOfAttributeToMultipleFields => ResourceManager.GetString("PossibleIncorrectApplicationOfAttributeToMultipleFields");
    public static string PossibleIncorrectApplicationOfFormerlySerializedAsAttributeToMultipleFieldsMessage => ResourceManager.GetString("PossibleIncorrectApplicationOfFormerlySerializedAsAttributeToMultipleFieldsMessage");
    public static string PossibleUnintendedBypassOfLifetimeCheckOfUnderlyingUnityEngineObject => ResourceManager.GetString("PossibleUnintendedBypassOfLifetimeCheckOfUnderlyingUnityEngineObject");
    public static string PreferGUIDBasedAssemblyReferences => ResourceManager.GetString("PreferGUIDBasedAssemblyReferences");
    public static string PreferGUIDReferenceMessage => ResourceManager.GetString("PreferGUIDReferenceMessage");
    public static string RedundantAttributeUsage => ResourceManager.GetString("RedundantAttributeUsage");
    public static string RedundantFormerlySerializedAsAttribute => ResourceManager.GetString("RedundantFormerlySerializedAsAttribute");
    public static string RedundantFormerlySerializedAsAttributeMessage => ResourceManager.GetString("RedundantFormerlySerializedAsAttributeMessage");
    public static string RedundantHideInInspectorAttribute => ResourceManager.GetString("RedundantHideInInspectorAttribute");
    public static string RedundantHideInInspectorAttributeMessage => ResourceManager.GetString("RedundantHideInInspectorAttributeMessage");
    public static string RedundantInitializeOnLoadAttribute => ResourceManager.GetString("RedundantInitializeOnLoadAttribute");
    public static string RedundantSerializeFieldAttribute => ResourceManager.GetString("RedundantSerializeFieldAttribute");
    public static string RedundantSerializeFieldAttributeMessage => ResourceManager.GetString("RedundantSerializeFieldAttributeMessage");
    public static string RedundantUnityEventFunction => ResourceManager.GetString("RedundantUnityEventFunction");
    public static string RedundantUnityEventFunctionMessage => ResourceManager.GetString("RedundantUnityEventFunctionMessage");
    public static string ReferencesInAAsmdefFileCanBeByNameOrByAssetGUIDUsingAnAssetGUIDProtectsAgainstRenamingTheAssemblyDefinition => ResourceManager.GetString("ReferencesInAAsmdefFileCanBeByNameOrByAssetGUIDUsingAnAssetGUIDProtectsAgainstRenamingTheAssemblyDefinition");
    public static string RemoveInvalidArrayItemQuickFix_Text_Remove_invalid_value => ResourceManager.GetString("RemoveInvalidArrayItemQuickFix_Text_Remove_invalid_value");
    public static string RenameFileToMatchAssemblyNameQuickFix_ExecutePsiTransaction_Cannot_rename___0__ => ResourceManager.GetString("RenameFileToMatchAssemblyNameQuickFix_ExecutePsiTransaction_Cannot_rename___0__");
    public static string RenameFileToMatchAssemblyNameQuickFix_ExecutePsiTransaction_File___0___already_exists => ResourceManager.GetString("RenameFileToMatchAssemblyNameQuickFix_ExecutePsiTransaction_File___0___already_exists");
    public static string RenameFileToMatchAssemblyNameQuickFix_Text_Rename_file_to_match_assembly_name => ResourceManager.GetString("RenameFileToMatchAssemblyNameQuickFix_Text_Rename_file_to_match_assembly_name");
    public static string ReorderingMultiplicationOperationsWillImprovePerformance => ResourceManager.GetString("ReorderingMultiplicationOperationsWillImprovePerformance");
    public static string RepeatedAccessOfPropertyOnBuiltInComponentIsInefficient => ResourceManager.GetString("RepeatedAccessOfPropertyOnBuiltInComponentIsInefficient");
    public static string RepeatedPropertyAccessOfBuiltInComponentIsInefficientMessage => ResourceManager.GetString("RepeatedPropertyAccessOfBuiltInComponentIsInefficientMessage");
    public static string RiderPackageUpdateAvailabilityChecker_ShowNotificationIfNeeded_JetBrains_Rider_package_in_Unity_is_missing_ => ResourceManager.GetString("RiderPackageUpdateAvailabilityChecker_ShowNotificationIfNeeded_JetBrains_Rider_package_in_Unity_is_missing_");
    public static string RiderPackageUpdateAvailabilityChecker_ShowNotificationIfNeeded_Make_sure_JetBrains_Rider_package_is_installed_in_Unity_Package_Manager_ => ResourceManager.GetString("RiderPackageUpdateAvailabilityChecker_ShowNotificationIfNeeded_Make_sure_JetBrains_Rider_package_is_installed_in_Unity_Package_Manager_");
    public static string SceneDoesNotExist => ResourceManager.GetString("SceneDoesNotExist");
    public static string SceneIsDisabledInTheBuildSettings => ResourceManager.GetString("SceneIsDisabledInTheBuildSettings");
    public static string SceneIsDisabledInTheUnityBuildSettingsSoItCouldNotBeLoaded => ResourceManager.GetString("SceneIsDisabledInTheUnityBuildSettingsSoItCouldNotBeLoaded");
    public static string SceneIsDisabledInTheUnityBuildSettingsSoItCouldNotBeLoadedMessage => ResourceManager.GetString("SceneIsDisabledInTheUnityBuildSettingsSoItCouldNotBeLoadedMessage");
    public static string ScriptableObjectInstancesMustBeInstantiatedWithScriptableObjectCreateInstanceTInsteadOfnew => ResourceManager.GetString("ScriptableObjectInstancesMustBeInstantiatedWithScriptableObjectCreateInstanceTInsteadOfnew");
    public static string ScriptableObjectInstancesMustBeInstantiatedWithScriptableObjectCreateInstanceTInsteadOfnewMessage => ResourceManager.GetString("ScriptableObjectInstancesMustBeInstantiatedWithScriptableObjectCreateInstanceTInsteadOfnewMessage");
    public static string SettingparentPropertyImmediatelyAfterObjectInstantiationIsInefficient => ResourceManager.GetString("SettingparentPropertyImmediatelyAfterObjectInstantiationIsInefficient");
    public static string SettingparentPropertyImmediatelyAfterObjectInstantiationIsInefficientMessage => ResourceManager.GetString("SettingparentPropertyImmediatelyAfterObjectInstantiationIsInefficientMessage");
    public static string SharedStaticTypeParameterRequiresTheUnmanagedConstraint => ResourceManager.GetString("SharedStaticTypeParameterRequiresTheUnmanagedConstraint");
    public static string ShortSceneNameIsNotUnique => ResourceManager.GetString("ShortSceneNameIsNotUnique");
    public static string SomeSharedStaticGetOrCreateOverloadsCauseCompilerErrors => ResourceManager.GetString("SomeSharedStaticGetOrCreateOverloadsCauseCompilerErrors");
    public static string SomeUnityObjectPropertiesResultInNativeMethodsCallsAndRepeatedlyAccessingThePropertyIsInefficientIntroduceAVariableToLocallyCacheThePropertyValue => ResourceManager.GetString("SomeUnityObjectPropertiesResultInNativeMethodsCallsAndRepeatedlyAccessingThePropertyIsInefficientIntroduceAVariableToLocallyCacheThePropertyValue");
    public static string StringBasedGraphicsPropertyLookupIsInefficient => ResourceManager.GetString("StringBasedGraphicsPropertyLookupIsInefficient");
    public static string StringBasedLookupOfComponentTypeIsInefficient => ResourceManager.GetString("StringBasedLookupOfComponentTypeIsInefficient");
    public static string StringBasedPropertyLookupIsInefficientAsEachTimeTheMethodIsCalledTheStringNameIsConvertedIntoAnIntegerValuePreferCalculatingTheIntegerValueOnceAndCachingTheResult => ResourceManager.GetString("StringBasedPropertyLookupIsInefficientAsEachTimeTheMethodIsCalledTheStringNameIsConvertedIntoAnIntegerValuePreferCalculatingTheIntegerValueOnceAndCachingTheResult");
    public static string StringBasedPropertyLookupIsInefficientMessage => ResourceManager.GetString("StringBasedPropertyLookupIsInefficientMessage");
    public static string StringBasedTypeLookupIsInefficientUseGenericOverloadMessage => ResourceManager.GetString("StringBasedTypeLookupIsInefficientUseGenericOverloadMessage");
    public static string SyncVarAttributeCanOnlyBeAppliedInAClassThatDerivesFromNetworkBehaviourMessage => ResourceManager.GetString("SyncVarAttributeCanOnlyBeAppliedInAClassThatDerivesFromNetworkBehaviourMessage");
    public static string TheAttributeDoesNotDefineAnyRestrictionsOnValidTargetsButIsOnlyUsefulWhenAppliedToSpecificDeclarationsEGFieldClassOrMethod => ResourceManager.GetString("TheAttributeDoesNotDefineAnyRestrictionsOnValidTargetsButIsOnlyUsefulWhenAppliedToSpecificDeclarationsEGFieldClassOrMethod");
    public static string TheClassReferredToInTheCallToGetComponentAddComponentOrScriptableObjectCreateInstanceCannotBeFoundInTheCurrentProjectOrReferencedAssembliesTheCallIsLikelyToFailAtRuntimeAndReturnNull => ResourceManager.GetString("TheClassReferredToInTheCallToGetComponentAddComponentOrScriptableObjectCreateInstanceCannotBeFoundInTheCurrentProjectOrReferencedAssembliesTheCallIsLikelyToFailAtRuntimeAndReturnNull");
    public static string TheDefaultImplementationForOnGUIInPropertyDrawerWillPrintNoGUIImplementedInTheUnityInspector => ResourceManager.GetString("TheDefaultImplementationForOnGUIInPropertyDrawerWillPrintNoGUIImplementedInTheUnityInspector");
    public static string TheforeachConstructionIsNotSupported => ResourceManager.GetString("TheforeachConstructionIsNotSupported");
    public static string TheFormerlySerializedAsAttributeIsOnlyValidOnUnitySerializedFieldsItCanAlsoBeRedundantIfTheNameArgumentMatchesTheCurrentNameOfTheField => ResourceManager.GetString("TheFormerlySerializedAsAttributeIsOnlyValidOnUnitySerializedFieldsItCanAlsoBeRedundantIfTheNameArgumentMatchesTheCurrentNameOfTheField");
    public static string TheHideInInspectorAttributeOnlyAppliesToSerialisedFields => ResourceManager.GetString("TheHideInInspectorAttributeOnlyAppliesToSerialisedFields");
    public static string TheIndexIsMissingInTheBuildSettings => ResourceManager.GetString("TheIndexIsMissingInTheBuildSettings");
    public static string TheInitializeOnLoadAttributeIsRedundantWhenTheStaticConstructorIsMissing => ResourceManager.GetString("TheInitializeOnLoadAttributeIsRedundantWhenTheStaticConstructorIsMissing");
    public static string TheInputNameIsNotDefinedInTheInputManager => ResourceManager.GetString("TheInputNameIsNotDefinedInTheInputManager");
    public static string TheLayerIsNotDefinedInTheTagsLayers => ResourceManager.GetString("TheLayerIsNotDefinedInTheTagsLayers");
    public static string TheLayerIsNotDefinedInTheTagsLayersTheCallIsLikelyToFailAtRuntime => ResourceManager.GetString("TheLayerIsNotDefinedInTheTagsLayersTheCallIsLikelyToFailAtRuntime");
    public static string TheLayerIsNotDefinedInTheTagsLayersTheCallIsLikelyToFailAtRuntimeMessage => ResourceManager.GetString("TheLayerIsNotDefinedInTheTagsLayersTheCallIsLikelyToFailAtRuntimeMessage");
    public static string TheNameIsNotDefinedInTheInputManagerTheCallIsLikelyToFailAtRuntime => ResourceManager.GetString("TheNameIsNotDefinedInTheInputManagerTheCallIsLikelyToFailAtRuntime");
    public static string TheNameIsNotDefinedInTheInputManagerTheCallIsLikelyToFailAtRuntimeMessage => ResourceManager.GetString("TheNameIsNotDefinedInTheInputManagerTheCallIsLikelyToFailAtRuntimeMessage");
    public static string TheNullCoalescingOperatorDoesNotCallTheCustomEqualityOperatorsDefinedOnUnityEngineObjectWhichWillCheckToSeeIfTheUnderlyingUnityEngineObjectHasBeenDestroyedPreferAnExplicitNullComparisonOrImplicitBoolComparisonIfTheLifetimeCheckIsIntendedOrExplicitlyUseobjectReferenceEqualsForAStandardAndQuickerCLRNullCheck => ResourceManager.GetString("TheNullCoalescingOperatorDoesNotCallTheCustomEqualityOperatorsDefinedOnUnityEngineObjectWhichWillCheckToSeeIfTheUnderlyingUnityEngineObjectHasBeenDestroyedPreferAnExplicitNullComparisonOrImplicitBoolComparisonIfTheLifetimeCheckIsIntendedOrExplicitlyUseobjectReferenceEqualsForAStandardAndQuickerCLRNullCheck");
    public static string TheNullPropagatingOperatorDoesNotCallTheCustomEqualityOperatorsDefinedOnUnityEngineObjectWhichWillCheckToSeeIfTheUnderlyingUnityEngineObjectHasBeenDestroyedPreferAnExplicitNullComparisonOrImplicitBoolComparisonIfTheLifetimeCheckIsIntendedOrExplicitlyUseobjectReferenceEqualsForAStandardAndQuickerCLRNullCheck => ResourceManager.GetString("TheNullPropagatingOperatorDoesNotCallTheCustomEqualityOperatorsDefinedOnUnityEngineObjectWhichWillCheckToSeeIfTheUnderlyingUnityEngineObjectHasBeenDestroyedPreferAnExplicitNullComparisonOrImplicitBoolComparisonIfTheLifetimeCheckIsIntendedOrExplicitlyUseobjectReferenceEqualsForAStandardAndQuickerCLRNullCheck");
    public static string ThereAreSeveralScenesWithSameNameInTheUnityBuildSettingsOnlySceneWithSmallestIndexWillBeUsedMessage => ResourceManager.GetString("ThereAreSeveralScenesWithSameNameInTheUnityBuildSettingsOnlySceneWithSmallestIndexWillBeUsedMessage");
    public static string ThereAreSeveralScenesWithTheSameNameInTheUnityBuildSettingsOnlySceneWithSmallestIndexWillBeUsed => ResourceManager.GetString("ThereAreSeveralScenesWithTheSameNameInTheUnityBuildSettingsOnlySceneWithSmallestIndexWillBeUsed");
    public static string ThereIsNoAnimatorStateWithTheSameNameInTheProject => ResourceManager.GetString("ThereIsNoAnimatorStateWithTheSameNameInTheProject");
    public static string ThereIsNoAnimatorStateWithTheSameNameInTheProjectMessage => ResourceManager.GetString("ThereIsNoAnimatorStateWithTheSameNameInTheProjectMessage");
    public static string ThereIsNoSceneWithSameIndexInTheUnityBuildSettingsMessage => ResourceManager.GetString("ThereIsNoSceneWithSameIndexInTheUnityBuildSettingsMessage");
    public static string ThereIsNoSceneWithSameNameInTheProjectMessage => ResourceManager.GetString("ThereIsNoSceneWithSameNameInTheProjectMessage");
    public static string ThereIsNoSceneWithTheSameIndexInTheUnityBuildSettings => ResourceManager.GetString("ThereIsNoSceneWithTheSameIndexInTheUnityBuildSettings");
    public static string ThereIsNoSceneWithTheSameNameInTheBuildSettings => ResourceManager.GetString("ThereIsNoSceneWithTheSameNameInTheBuildSettings");
    public static string ThereIsNoSceneWithTheSameNameInTheProject => ResourceManager.GetString("ThereIsNoSceneWithTheSameNameInTheProject");
    public static string TheResourceIsNotDefinedInTheProject => ResourceManager.GetString("TheResourceIsNotDefinedInTheProject");
    public static string TheResourceIsNotDefinedInTheProjectExpressionWillReturnnull => ResourceManager.GetString("TheResourceIsNotDefinedInTheProjectExpressionWillReturnnull");
    public static string TheResourceIsNotDefinedInTheProjectExpressionWillReturnnullMessage => ResourceManager.GetString("TheResourceIsNotDefinedInTheProjectExpressionWillReturnnullMessage");
    public static string TheSameShortcutIsDefinedForAnotherMenuItem => ResourceManager.GetString("TheSameShortcutIsDefinedForAnotherMenuItem");
    public static string TheSameShortcutIsDefinedForAnotherMenuItemInMessage => ResourceManager.GetString("TheSameShortcutIsDefinedForAnotherMenuItemInMessage");
    public static string TheSceneIsMissingInTheUnityBuildSettings => ResourceManager.GetString("TheSceneIsMissingInTheUnityBuildSettings");
    public static string TheSceneIsMissingInTheUnityBuildSettingsMessage => ResourceManager.GetString("TheSceneIsMissingInTheUnityBuildSettingsMessage");
    public static string TheTagIsNotDefinedInTheTagsLayers => ResourceManager.GetString("TheTagIsNotDefinedInTheTagsLayers");
    public static string TheTagIsNotDefinedInTheTagsLayersExpressionWillReturnfalse => ResourceManager.GetString("TheTagIsNotDefinedInTheTagsLayersExpressionWillReturnfalse");
    public static string TheTagIsNotDefinedInTheTagsLayersExpressionWillReturnfalseMessage => ResourceManager.GetString("TheTagIsNotDefinedInTheTagsLayersExpressionWillReturnfalseMessage");
    public static string ThisMethodCallIsInefficientWhenCalledInsideAPerformanceCriticalContext => ResourceManager.GetString("ThisMethodCallIsInefficientWhenCalledInsideAPerformanceCriticalContext");
    public static string ToAvoidConfusionTheNameOfTheAssemblyDefinitionFileShouldMatchTheNameOfTheAssemblyBeingDefined => ResourceManager.GetString("ToAvoidConfusionTheNameOfTheAssemblyDefinitionFileShouldMatchTheNameOfTheAssemblyBeingDefined");
    public static string TryStatementIsNotSupported => ResourceManager.GetString("TryStatementIsNotSupported");
    public static string TurnOnAnyway_Text => ResourceManager.GetString("TurnOnAnyway_Text");
    public static string TypeofIsProhibitedInBurst => ResourceManager.GetString("TypeofIsProhibitedInBurst");
    public static string TypeParameterMustBeUnmanagedIsNotMessage => ResourceManager.GetString("TypeParameterMustBeUnmanagedIsNotMessage");
    public static string UnityAssetSpecificOccurrenceKinds_ComponentUsage_Unity_component_usage => ResourceManager.GetString("UnityAssetSpecificOccurrenceKinds_ComponentUsage_Unity_component_usage");
    public static string UnityAssetSpecificOccurrenceKinds_EventHandler_Unity_event_handler => ResourceManager.GetString("UnityAssetSpecificOccurrenceKinds_EventHandler_Unity_event_handler");
    public static string UnityAssetSpecificOccurrenceKinds_InspectorUsage_Inspector_values => ResourceManager.GetString("UnityAssetSpecificOccurrenceKinds_InspectorUsage_Inspector_values");
    public static string UnityFindUsagesProvider_GetNotFoundMessage__are_only_implicit_ => ResourceManager.GetString("UnityFindUsagesProvider_GetNotFoundMessage__are_only_implicit_");
    public static string UnityInlayHintSettings_t_Inlay_hint_settings_for_Unity_related_files => ResourceManager.GetString("UnityInlayHintSettings_t_Inlay_hint_settings_for_Unity_related_files");
    public static string UnityInlayHintSettings_t_Visibility_mode_of_hints_for_GUID_references_in__asmdef_files => ResourceManager.GetString("UnityInlayHintSettings_t_Visibility_mode_of_hints_for_GUID_references_in__asmdef_files");
    public static string UnityInlayHintSettings_t_Visibility_mode_of_hints_for_package_versions_in__asmdef_files => ResourceManager.GetString("UnityInlayHintSettings_t_Visibility_mode_of_hints_for_package_versions_in__asmdef_files");
    public static string UnityInlayHintsOptionsPage_UnityInlayHintsOptionsPage_Assembly_Definition_file_GUID_references => ResourceManager.GetString("UnityInlayHintsOptionsPage_UnityInlayHintsOptionsPage_Assembly_Definition_file_GUID_references");
    public static string UnityInlayHintsOptionsPage_UnityInlayHintsOptionsPage_Assembly_Definition_file_package_versions => ResourceManager.GetString("UnityInlayHintsOptionsPage_UnityInlayHintsOptionsPage_Assembly_Definition_file_package_versions");
    public static string UnityOptionsPage_AddBurstAnalysisSubSection_Enable_analysis_for_Burst_compiler_issues => ResourceManager.GetString("UnityOptionsPage_AddBurstAnalysisSubSection_Enable_analysis_for_Burst_compiler_issues");
    public static string UnityOptionsPage_AddBurstAnalysisSubSection_Show_gutter_icons_for_Burst_compiled_called_methods => ResourceManager.GetString("UnityOptionsPage_AddBurstAnalysisSubSection_Show_gutter_icons_for_Burst_compiled_called_methods");
    public static string UnityOptionsPage_AddCSharpSection_Always => ResourceManager.GetString("UnityOptionsPage_AddCSharpSection_Always");
    public static string UnityOptionsPage_AddCSharpSection_Show_gutter_icons_for_implicit_script_usages => ResourceManager.GetString("UnityOptionsPage_AddCSharpSection_Show_gutter_icons_for_implicit_script_usages");
    public static string UnityOptionsPage_AddCSharpSection_Show_gutter_icons_for_implicit_script_usages_ => ResourceManager.GetString("UnityOptionsPage_AddCSharpSection_Show_gutter_icons_for_implicit_script_usages_");
    public static string UnityOptionsPage_AddCSharpSection_When_Code_Vision_is_disabled => ResourceManager.GetString("UnityOptionsPage_AddCSharpSection_When_Code_Vision_is_disabled");
    public static string UnityOptionsPage_AddDebuggingSection_Break_on_unhandled_exceptions__setting_for_IL2CPP_players_Comment => ResourceManager.GetString("UnityOptionsPage_AddDebuggingSection_Break_on_unhandled_exceptions__setting_for_IL2CPP_players_Comment");
    public static string UnityOptionsPage_AddDebuggingSection_Debugging => ResourceManager.GetString("UnityOptionsPage_AddDebuggingSection_Debugging");
    public static string UnityOptionsPage_AddDebuggingSection_Extend_value_rendering => ResourceManager.GetString("UnityOptionsPage_AddDebuggingSection_Extend_value_rendering");
    public static string UnityOptionsPage_AddDebuggingSection_Extend_value_rendering_Comment => ResourceManager.GetString("UnityOptionsPage_AddDebuggingSection_Extend_value_rendering_Comment");
    public static string UnityOptionsPage_AddDebuggingSection_Ignore__Break_on_unhandled_exceptions__setting_for_IL2CPP_players => ResourceManager.GetString("UnityOptionsPage_AddDebuggingSection_Ignore__Break_on_unhandled_exceptions__setting_for_IL2CPP_players");
    public static string UnityOptionsPage_AddGeneralSection_ => ResourceManager.GetString("UnityOptionsPage_AddGeneralSection_");
    public static string UnityOptionsPage_AddGeneralSection_Automatically_install_and_update_Rider_s_Unity_editor_plugin => ResourceManager.GetString("UnityOptionsPage_AddGeneralSection_Automatically_install_and_update_Rider_s_Unity_editor_plugin");
    public static string UnityOptionsPage_AddGeneralSection_Automatically_refresh_assets_in_Unity => ResourceManager.GetString("UnityOptionsPage_AddGeneralSection_Automatically_refresh_assets_in_Unity");
    public static string UnityOptionsPage_AddGeneralSection_General => ResourceManager.GetString("UnityOptionsPage_AddGeneralSection_General");
    public static string UnityOptionsPage_AddGeneralSection_Notify_when_Rider_package_update_is_available => ResourceManager.GetString("UnityOptionsPage_AddGeneralSection_Notify_when_Rider_package_update_is_available");
    public static string UnityOptionsPage_AddInternalSection__Deprecated__Parse_GLSL_files_for_syntax_errors__requires_internal_mode__and_re_opening_solution_ => ResourceManager.GetString("UnityOptionsPage_AddInternalSection__Deprecated__Parse_GLSL_files_for_syntax_errors__requires_internal_mode__and_re_opening_solution_");
    public static string UnityOptionsPage_AddInternalSection_Internal => ResourceManager.GetString("UnityOptionsPage_AddInternalSection_Internal");
    public static string UnityOptionsPage_AddInternalSection_Suppress_resolve_errors_in_render_pipeline_packages => ResourceManager.GetString("UnityOptionsPage_AddInternalSection_Suppress_resolve_errors_in_render_pipeline_packages");
    public static string UnityOptionsPage_AddNamingSubSection_ALL_UPPER => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_ALL_UPPER");
    public static string UnityOptionsPage_AddNamingSubSection_Enable_inspection => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_Enable_inspection");
    public static string UnityOptionsPage_AddNamingSubSection_First_upper => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_First_upper");
    public static string UnityOptionsPage_AddNamingSubSection_lowerCamelCase => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_lowerCamelCase");
    public static string UnityOptionsPage_AddNamingSubSection_lowerCamelCase_UnderscoreTolerant => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_lowerCamelCase_UnderscoreTolerant");
    public static string UnityOptionsPage_AddNamingSubSection_lowerCamelCase_underscoreTolerant2 => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_lowerCamelCase_underscoreTolerant2");
    public static string UnityOptionsPage_AddNamingSubSection_Prefix_ => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_Prefix_");
    public static string UnityOptionsPage_AddNamingSubSection_Serialized_field_naming_rules => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_Serialized_field_naming_rules");
    public static string UnityOptionsPage_AddNamingSubSection_Style_ => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_Style_");
    public static string UnityOptionsPage_AddNamingSubSection_Suffix_ => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_Suffix_");
    public static string UnityOptionsPage_AddNamingSubSection_UpperCamelCase => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_UpperCamelCase");
    public static string UnityOptionsPage_AddNamingSubSection_UpperCamelCase_UnderscoreTolerant => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_UpperCamelCase_UnderscoreTolerant");
    public static string UnityOptionsPage_AddNamingSubSection_UpperCamelCase_underscoreTolerant2 => ResourceManager.GetString("UnityOptionsPage_AddNamingSubSection_UpperCamelCase_underscoreTolerant2");
    public static string UnityOptionsPage_AddPerformanceAnalysisSubSection_Current_method_only => ResourceManager.GetString("UnityOptionsPage_AddPerformanceAnalysisSubSection_Current_method_only");
    public static string UnityOptionsPage_AddPerformanceAnalysisSubSection_Enable_performance_analysis_in_frequently_called_code => ResourceManager.GetString("UnityOptionsPage_AddPerformanceAnalysisSubSection_Enable_performance_analysis_in_frequently_called_code");
    public static string UnityOptionsPage_AddPerformanceAnalysisSubSection_Highlight_performance_critical_contexts_ => ResourceManager.GetString("UnityOptionsPage_AddPerformanceAnalysisSubSection_Highlight_performance_critical_contexts_");
    public static string UnityOptionsPage_AddPerformanceAnalysisSubSection_Never => ResourceManager.GetString("UnityOptionsPage_AddPerformanceAnalysisSubSection_Never");
    public static string UnityOptionsPage_AddPerformanceAnalysisSubSection_Show_gutter_icons_for_frequently_called_methods => ResourceManager.GetString("UnityOptionsPage_AddPerformanceAnalysisSubSection_Show_gutter_icons_for_frequently_called_methods");
    public static string UnityOptionsPage_AddShadersSection_Shaders => ResourceManager.GetString("UnityOptionsPage_AddShadersSection_Shaders");
    public static string UnityOptionsPage_AddShadersSection_Suppress_resolve_errors_of_unqualified_names => ResourceManager.GetString("UnityOptionsPage_AddShadersSection_Suppress_resolve_errors_of_unqualified_names");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Automatically_disable_asset_indexing_for_large_solutions => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Automatically_disable_asset_indexing_for_large_solutions");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Cache_prefab_data_to_improve_find_usage_performance => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Cache_prefab_data_to_improve_find_usage_performance");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Merge_parameters => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Merge_parameters");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Parse_text_based_asset_files_for_script_and_event_handler_usages => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Parse_text_based_asset_files_for_script_and_event_handler_usages");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Prefer_UnityYamlMerge_for_merging_YAML_files => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Prefer_UnityYamlMerge_for_merging_YAML_files");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Show_Inspector_values_in_the_editor => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Show_Inspector_values_in_the_editor");
    public static string UnityOptionsPage_AddTextBasedAssetsSection_Text_based_assets => ResourceManager.GetString("UnityOptionsPage_AddTextBasedAssetsSection_Text_based_assets");
    public static string UnitySettings_t_Enable_analysis_for_Burst_compiler_issues => ResourceManager.GetString("UnitySettings_t_Enable_analysis_for_Burst_compiler_issues");
    public static string UnitySettings_t_Enable_debugger_extensions => ResourceManager.GetString("UnitySettings_t_Enable_debugger_extensions");
    public static string UnitySettings_t_Enables_asset_indexing => ResourceManager.GetString("UnitySettings_t_Enables_asset_indexing");
    public static string UnitySettings_t_Enables_completion_based_on_words_found_in_the_current_file_ => ResourceManager.GetString("UnitySettings_t_Enables_completion_based_on_words_found_in_the_current_file_");
    public static string UnitySettings_t_Enables_performance_analysis_in_frequently_called_code => ResourceManager.GetString("UnitySettings_t_Enables_performance_analysis_in_frequently_called_code");
    public static string UnitySettings_t_Enables_showing_hot_icon_for_frequently_called_code => ResourceManager.GetString("UnitySettings_t_Enables_showing_hot_icon_for_frequently_called_code");
    public static string UnitySettings_t_Enables_showing_Unity_icon_for_Burst_compiled_code => ResourceManager.GetString("UnitySettings_t_Enables_showing_Unity_icon_for_Burst_compiled_code");
    public static string UnitySettings_t_Enables_syntax_error_highlighting__brace_matching_and_more_of_ShaderLab_files_ => ResourceManager.GetString("UnitySettings_t_Enables_syntax_error_highlighting__brace_matching_and_more_of_ShaderLab_files_");
    public static string UnitySettings_t_Enables_syntax_error_highlighting_of_CG_blocks_in_ShaderLab_files_ => ResourceManager.GetString("UnitySettings_t_Enables_syntax_error_highlighting_of_CG_blocks_in_ShaderLab_files_");
    public static string UnitySettings_t_Highlighting_mode_for_performance_critical_code => ResourceManager.GetString("UnitySettings_t_Highlighting_mode_for_performance_critical_code");
    public static string UnitySettings_t_If_this_option_is_disabled__Rider_package_update_notifications_would_never_be_shown_ => ResourceManager.GetString("UnitySettings_t_If_this_option_is_disabled__Rider_package_update_notifications_would_never_be_shown_");
    public static string UnitySettings_t_If_this_option_is_enabled__Rider_will_automatically_notify_the_Unity_editor_to_refresh_assets_ => ResourceManager.GetString("UnitySettings_t_If_this_option_is_enabled__Rider_will_automatically_notify_the_Unity_editor_to_refresh_assets_");
    public static string UnitySettings_t_If_this_option_is_enabled__the_Rider_Unity_editor_plugin_will_be_automatically_installed_and_updated_ => ResourceManager.GetString("UnitySettings_t_If_this_option_is_enabled__the_Rider_Unity_editor_plugin_will_be_automatically_installed_and_updated_");
    public static string UnitySettings_t_If_this_option_is_enabled__UnityYamlMerge_would_be_used_to_merge_YAML_files_ => ResourceManager.GetString("UnitySettings_t_If_this_option_is_enabled__UnityYamlMerge_would_be_used_to_merge_YAML_files_");
    public static string UnitySettings_t_Ignore__Break_on_Unhandled_Exceptions__for_IL2CPP_players => ResourceManager.GetString("UnitySettings_t_Ignore__Break_on_Unhandled_Exceptions__for_IL2CPP_players");
    public static string UnitySettings_t_Merge_parameters => ResourceManager.GetString("UnitySettings_t_Merge_parameters");
    public static string UnitySettings_t_Prefab_cache => ResourceManager.GetString("UnitySettings_t_Prefab_cache");
    public static string UnitySettings_t_Should_yaml_heuristic_be_applied_ => ResourceManager.GetString("UnitySettings_t_Should_yaml_heuristic_be_applied_");
    public static string UnitySettings_t_Show_Inspector_properties_changes_in_editor => ResourceManager.GetString("UnitySettings_t_Show_Inspector_properties_changes_in_editor");
    public static string UnitySettings_t_Suppress_resolve_errors_in_HLSL_ => ResourceManager.GetString("UnitySettings_t_Suppress_resolve_errors_in_HLSL_");
    public static string UnitySettings_t_Suppress_resolve_errors_in_render_pipeline_package_in_HLSL_ => ResourceManager.GetString("UnitySettings_t_Suppress_resolve_errors_in_render_pipeline_package_in_HLSL_");
    public static string UnitySettings_t_Unity_highlighter_scheme_for_editor_ => ResourceManager.GetString("UnitySettings_t_Unity_highlighter_scheme_for_editor_");
    public static string UnitySettings_t_Unity_plugin_settings => ResourceManager.GetString("UnitySettings_t_Unity_plugin_settings");
    public static string UnityWillIgnoreTheSerializeFieldAttributeIfAFieldIsAlsoMarkedWithTheNonSerializedAttribute => ResourceManager.GetString("UnityWillIgnoreTheSerializeFieldAttributeIfAFieldIsAlsoMarkedWithTheNonSerializedAttribute");
    public static string UnityYamlProjectFileType_UnityYamlProjectFileType_Unity_Yaml => ResourceManager.GetString("UnityYamlProjectFileType_UnityYamlProjectFileType_Unity_Yaml");
    public static string UseCompareTagInsteadOfExplicitStringComparison => ResourceManager.GetString("UseCompareTagInsteadOfExplicitStringComparison");
    public static string UseJaggedOrOneDimensionalArrayInsteadOfMultidimensionalArray => ResourceManager.GetString("UseJaggedOrOneDimensionalArrayInsteadOfMultidimensionalArray");
    public static string UseNonAllocatingMethodMessage => ResourceManager.GetString("UseNonAllocatingMethodMessage");
    public static string UsingAStringTypeNameToLookUpAComponentIsSlowerThanSpecifyingTheTypeAsAGenericTypeParameter => ResourceManager.GetString("UsingAStringTypeNameToLookUpAComponentIsSlowerThanSpecifyingTheTypeAsAGenericTypeParameter");
    public static string UsingnewToInstantiateAClassDerivedFromMonoBehaviourWillNotAttachItToAGameObjectInstanceAndUnityWillNotCallAnyEventFunctionsCreateANewInstanceUsingGameObjectAddComponentT => ResourceManager.GetString("UsingnewToInstantiateAClassDerivedFromMonoBehaviourWillNotAttachItToAGameObjectInstanceAndUnityWillNotCallAnyEventFunctionsCreateANewInstanceUsingGameObjectAddComponentT");
    public static string UsingnewToInstantiateAClassDerivedFromScriptableObjectMeansThatUnityWillNotCallAnyEventFunctionsCreateANewInstanceUsingGameObjectAddComponentT => ResourceManager.GetString("UsingnewToInstantiateAClassDerivedFromScriptableObjectMeansThatUnityWillNotCallAnyEventFunctionsCreateANewInstanceUsingGameObjectAddComponentT");
    public static string WritingToAStaticFieldIsNotSupported => ResourceManager.GetString("WritingToAStaticFieldIsNotSupported");
  }
}