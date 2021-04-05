using BoDi;
using TechTalk.SpecFlow;

namespace SpecTest.Installers
{
    [Binding]
    public static class ServiceInstaller
    {
        private static DriverInstaller _installer;

        [BeforeFeature]
        public static void BeforeRun(IObjectContainer container, FeatureContext featureContext)
        {
            _installer = new DriverInstaller(container);
            _installer.Prepare(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterRun()
        {
            _installer.Close();
        }
    }
}
