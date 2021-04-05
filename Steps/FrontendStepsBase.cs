using TechTalk.SpecFlow;

namespace SpecTest.Steps
{
    public class FrontendStepsBase : CommonStepsBase
    {
        protected Actions actions;
        public FrontendStepsBase(ScenarioContext injectedContext, FeatureContext featureContext) : base(injectedContext, featureContext)
        {
            actions = new Actions(injectedContext.ScenarioContainer, featureContext);
        }

        public void SetText(string elementName, string text)
        {
            actions.WriteText(elementName, text);
        }

        public string GetText(string elementName)
        {
            return actions.GetText(elementName);
        }
    }
}
