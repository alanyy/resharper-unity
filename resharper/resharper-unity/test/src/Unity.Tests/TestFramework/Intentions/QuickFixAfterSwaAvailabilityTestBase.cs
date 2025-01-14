using JetBrains.Lifetimes;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.FeaturesTestFramework.Intentions;

namespace JetBrains.ReSharper.Plugins.Tests.TestFramework.Intentions
{
    public abstract class QuickFixAfterSwaAvailabilityTestBase : QuickFixAvailabilityTestBase
    {
        protected override bool ShouldGlobalWarnings => true;

        protected override void DoTest(Lifetime lifetime, IProject testProject)
        {
            var swea = Solution.GetComponent<SolutionAnalysisService>();

            using (swea.RunAnalysisCookie())
            {
                base.DoTest(lifetime, testProject);
            }
        }
    }
}