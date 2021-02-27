using OpenQA.Selenium;
using spectest.Pages;
using TechTalk.SpecFlow;

namespace spectest.Steps
{
    [Binding]
    public class FrontendStepsWhen : CommonStepsBase
    {
        protected Actions.Actions actions;
        public FrontendStepsWhen(ScenarioContext injectedContext) : base(injectedContext)
        {
            actions = new Actions.Actions(injectedContext.ScenarioContainer);
        }

        [When(@"I open the main page")]
        public void WhenIOpenTheMainPage()
        {
            actions.GoToUrl(MainPage.Link);
        }

    }
}
