using System.Collections.Generic;
using FluentAssertions;
using SpecTest.Models;
using SpecTest.Pages.GoogleMaps;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;

namespace SpecTest.Steps
{
    [Binding]
    public class FrontendStepsThen : FrontendStepsBase
    {
        public FrontendStepsThen(ScenarioContext injectedContext, FeatureContext featureContext) : base(injectedContext, featureContext)
        {
        }

        [Then(@"then the field (.*) is set to (.*)")]
        public void ThenThenTheFieldIsSetTo(string fieldName, string value)
        {
            var text = GetText(fieldName);
            text.Should().Be(value, $"We expect that field's {fieldName} value should be {value}");
        }

        [Then(@"then the field (.*) is starting with (.*)")]
        public void ThenThenTheFieldIsStartingWith(string fieldName, string value)
        {
            GetText(fieldName).Should().StartWith(value, $"We expect that field's {fieldName} value should be {value}");
        }

        [Then(@"then (.*) contains more than (.*) results")]
        public void ThenResultsContainsMoreThanSomeResult(string fieldName, int minimumNumberOfResults)
        {
            var items = GetItems(fieldName, MainPage.ResultXpath);
            items.Count.Should().BeGreaterThan(minimumNumberOfResults);
        }

        [Then(@"then (.*) contains (.*) results")]
        public void ThenThenResultsContainsResult(string fieldName, int numberOfResults)
        {
            var items = GetItems(fieldName, MainPage.ResultXpath);
            items.Count.Should().Be(numberOfResults);
        }


        private List<SearchResult> GetItems(string fieldName, string resultXpath)
        {
            var elements = actions.GetInnerElements(fieldName, resultXpath);
            var results = new List<SearchResult>();
            for (var i = 1; i <= elements.Count; i++)
            {
                var element = elements.ElementAt(i - 1);
                results.Add(new SearchResult
                {
                    Title = element.FindElement(By.XPath($"({MainPage.NamesOfPlacesXpath})[{i}]")).Text,
                    Text = element.Text
                });
            }
            return results;
        }
    }
}
