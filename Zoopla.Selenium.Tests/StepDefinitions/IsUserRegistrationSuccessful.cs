using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Zoopla.Selenium.Tests.Hooks;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    public class IsUserRegistrationSuccessful : StepBase
    {
        [BeforeScenario]
        public new void BeforeScenario()
        {
            base.BeforeScenario();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
           
        }

        [BeforeFeature]
        public new static void BeforeFeatureStep(FeatureContext featureContext)
        {
            StepBase.BeforeFeatureStep(featureContext);
        }


    }
}
