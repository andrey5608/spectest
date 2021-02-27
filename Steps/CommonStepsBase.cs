using BoDi;
using TechTalk.SpecFlow;

namespace spectest.Steps
{
    public class CommonStepsBase
    {
        protected readonly ScenarioContext context;

        public CommonStepsBase(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
    }
}
