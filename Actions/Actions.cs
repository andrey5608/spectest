using BoDi;
using OpenQA.Selenium;

namespace spectest.Actions
{
    public class Actions
    {
        private readonly IWebDriver _driver;

        public Actions(IObjectContainer container)
        {
            _driver = container.Resolve<IWebDriver>();
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
