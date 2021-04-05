using System.Collections.Generic;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecTest.Installers
{
    public class DriverInstaller
    {
        private readonly IObjectContainer container;
        private string _name;

        public DriverInstaller(IObjectContainer container)
        {
            this.container = container;
        }

        public void Prepare(string name)
        {
            if (!container.IsRegistered<IWebDriver>(name))
            {
                var webdriver = SetupWebDriver();
                container.RegisterInstanceAs(webdriver, name: name);
                _name = name;
            }
        }

        private static IWebDriver SetupWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArguments("--disable-extensions");
            options.AddArgument("--lang=en-US");
            options.AddArgument("--disable-geolocation");
            options.AddUserProfilePreference("Default", null);
            return new ChromeDriver(options);
        }

        public void Close()
        {
            var webDriver = container.Resolve<IWebDriver>(_name);

            webDriver.Close();
            webDriver.Dispose();
        }
    }
}
