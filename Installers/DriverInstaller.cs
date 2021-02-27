using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace spectest.Installers
{
    [Binding]
    public class DriverInstaller
    {
        private readonly IObjectContainer container;

        public DriverInstaller(IObjectContainer container)
        {
            this.container = container;
        }

        private static IWebDriver SetupWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            return new ChromeDriver(options);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var webdriver = SetupWebDriver();
            container.RegisterInstanceAs(webdriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var webDriver = container.Resolve<IWebDriver>();

            // Output any screenshots or log dumps etc

            webDriver.Close();
            webDriver.Dispose();
        }
    }
}
