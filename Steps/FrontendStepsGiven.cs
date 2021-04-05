using SpecTest.Pages.GoogleMaps;
using TechTalk.SpecFlow;

namespace SpecTest.Steps
{
    [Binding]
    public class FrontendStepsGiven : FrontendStepsBase
    {
        public FrontendStepsGiven(ScenarioContext injectedContext, FeatureContext featureContext) : base(injectedContext, featureContext)
        {
        }

        [Given(@"I opened the main page")]
        public void GivenIOpenedTheMainPage()
        {
            actions.GoToUrl(MainPage.Link);
        }

        [Given(@"I set up (.*) restaurants near my current place")]
        public void GivenISetUpRestaurantsNearMyCurrentPlace(int numberOfNearbyRestaurants)
        {
            // here we should set up test data
            // TODO: add mockable geoposition

            //as a workaround we just set two pair of coordinates - with restaurants and without it
            string[] placeCoords;
            if (numberOfNearbyRestaurants > 0)
            {
                placeCoords = new[] { "52.49981825354782", "13.339743705250312" }; //place where restaurants exists
            }
            else
            {
                placeCoords = new[] { "80.22478011313372", "-38.8281734345883" }; //place where restaurants not exists
            }
            actions.SetUpCoordinates(placeCoords[0], placeCoords[1]);
        }

    }
}
