using System;
using System.Collections.Generic;
using BoDi;
using SpecTest.Pages.GoogleMaps;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecTest
{
    public class Actions
    {
        private readonly IWebDriver _driver;
        private readonly MainPage _mainPage;
        private readonly WebDriverWait _waiter;

        public Actions(IObjectContainer container, FeatureContext featureContext)
        {
            _driver = container.Resolve<IWebDriver>(featureContext.FeatureInfo.Title);
            _mainPage = new MainPage(_driver);
            _waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(120));
        }

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ElementClick(string name)
        {
            WaitForElementExists(name);
            _mainPage.GetFromDictionaryByName(name).Click();
        }

        public void WriteText(string name, string text)
        {
            var element = _mainPage.GetFromDictionaryByName(name);
            element?.SendKeys(text);
            element.SendKeys(Keys.Enter);
            WaitForLoaderDissapears();
        }

        public string GetText(string name)
        {
            string text = string.Empty;
            _ = _waiter.Until(x =>
            {
                try
                {
                    var element = _mainPage.GetFromDictionaryByName(name);
                    var elText = element.Text;
                    if (!string.IsNullOrEmpty(elText))
                    {
                        text = elText;
                    }
                    else
                    {
                        text = element.GetAttribute("value");
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                return true;
            }
            );
            return text;
        }

        public void WaitForLoaderDissapears()
        {
            _waiter.Until(condition: x => (x as IJavaScriptExecutor).ExecuteScript("return document.readyState;").ToString() == "complete");
            _waiter.Until(condition: x => !_mainPage.GetFromDictionaryByName("Loader").GetAttribute("class").Contains("loading"));
        }

        public List<IWebElement> GetInnerElements(string elementName, string xpath)
        {
            var element = WaitForElementExists(elementName);
            var innerElements = new List<IWebElement>();
            innerElements.AddRange(element.FindElements(By.XPath(xpath)));
            return innerElements;
        }

        private IWebElement WaitForElementExists(string elementName)
        {
            IWebElement element = null;
            _waiter.Until(x =>
            {
                element = _mainPage.GetFromDictionaryByName(elementName);
                try
                {
                    return element.Enabled && element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }

        public void SetUpCoordinates(string lat, string alt)
        {
            _driver.Navigate().GoToUrl($"https://www.google.com/maps/@{lat},{alt},13z?hl=en");
        }
    }
}
