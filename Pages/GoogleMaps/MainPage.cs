using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SpecTest.Pages.GoogleMaps
{
#pragma warning disable 649
    public class MainPage : DictionaryExtensions
    {
        private static IWebDriver _driver;
        [FindsBy(How = How.Name, Using = "q")]
        private readonly IWebElement _query;
        [FindsBy(How = How.XPath, Using = "//div[@id='pane']/descendant::h1/span[not(@class)]")]
        private readonly IWebElement _street;
        [FindsBy(How = How.XPath, Using = "//div[@id='pane']/descendant::span[@class='section-info-text'][1]/span[@class='widget-pane-link']")]
        private readonly IWebElement _address;
        [FindsBy(How = How.XPath, Using = "//div[@id='pane']/descendant::div[@class='section-bad-query-title']")]
        private readonly IWebElement _label;
        [FindsBy(How = How.XPath, Using = "//button[@data-query='Restaurants']")]
        private readonly IWebElement _restaurants;
        [FindsBy(How = How.Id, Using = "searchbox")]
        private readonly IWebElement _searchbox;
        [FindsBy(How = How.XPath, Using = "//div[@role='region' and div[div[a[contains(@class, 'place')]]]]")]
        private readonly IWebElement _foundResults;

        public const string Link = "https://google.com/maps?hl=en";
        public const string ResultXpath = "//div[@id='pane']/descendant::div[a[contains(@class, 'place')]]";
        public const string NamesOfPlacesXpath = "//div[contains(@class, 'subtitle') and not(contains(@class,'extension'))]";

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Elements = new Dictionary<string, IWebElement>
            {
                {"Query",  _query},
                {"Street", _street},
                {"Address", _address},
                {"Label", _label},
                {"Restaurants", _restaurants},
                {"Loader", _searchbox},
                {"Results", _foundResults}
            };
        }
    }
}
