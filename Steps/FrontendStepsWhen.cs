using TechTalk.SpecFlow;
using SpecTest.Pages.GoogleMaps;
using System.IO;
using System;

namespace SpecTest.Steps
{
    [Binding]
    public class FrontendStepsWhen : FrontendStepsBase
    {
        public FrontendStepsWhen(ScenarioContext injectedContext, FeatureContext featureContext) : base(injectedContext, featureContext)
        {
        }

        [When(@"I open the main page")]
        public void WhenIOpenTheMainPage()
        {
            actions.GoToUrl(MainPage.Link);
        }

        [When(@"I write to the field (.*) text (.*)")]
        public void WhenIWriteTheText(string element, string text)
        {
            text = text == "' '" ? " " : text;// workaround to use single space in cucumber tables
            SetText(element, text);
        }

        [When(@"I pressed to (.*) button")]
        public void WhenIPressedToTheButton(string button)
        {
            actions.ElementClick(button);
        }

        [When(@"I write to the field (.*) query from file '(.*)'")]
        public void WhenIWriteToTheFieldQueryQueryFromFile(string elementName, string fileName)
        {
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            var text = File.ReadAllText(path);
            SetText(elementName, text);
        }
    }
}
