﻿using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;
using Zoopla.Selenium.Tests.Hooks;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    [Binding]
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
            _seleniumDriver.CloseWebDriverInstance();
        }

        [BeforeFeature]
        public new static void BeforeFeatureStep(FeatureContext featureContext)
        {
            StepBase.BeforeFeatureStep(featureContext);
        }

        [Given(@"I am in need of a (.*) property")]
        public void GivenIAmInNeedOfAProperty(string typeOfProperty)
        {
            _seleniumDriver.GetWebDriver.Navigate().GoToUrl("https://www.zoopla.co.uk/register/");
            



        }

        [When(@"I register myself on Zoopla website")]
        public void WhenIRegisterMyselfOnZooplaWebsite()
        {
            
        }

        [Then(@"I get (.*) of registration")]
        public void ThenIGetOfRegistration(string p0)
        {

        }

    }
}
