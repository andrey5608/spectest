using FluentAssertions;
using OpenQA.Selenium;
using spectest.Pages;
using TechTalk.SpecFlow;

namespace spectest.Steps
{
    [Binding]
    public class FrontendStepsThen : CommonStepsBase
    {
        private IWebDriver _driver;
        public FrontendStepsThen(ScenarioContext injectedContext) : base(injectedContext)
        {
            _driver = injectedContext.ScenarioContainer.Resolve<IWebDriver>();
        }

        [Then(@"the carousel contains few slides")]
        public void ThenTheCarouselContainsFewSlides()
        {
            var elements = _driver.FindElements(By.XPath(MainPage.WelcomeBannerXPath));
            elements.Count.Should().BeGreaterThan(0);
        }
    }
}
