using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.SDK.PageObjects;
using Zoopla.Selenium.Framework.Interfaces;
using Zoopla.Selenium.Tests.Hooks;
using Zoopla.Selenium.Tests.Pages;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : StepBase
    {
        private readonly ISeleniumConfig _configuration;
        private IWebDriver _driver;
        private HomePage searchToRentPropertyPage;

        public StepDefinitions(ISeleniumConfig configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [BeforeScenario]
        public new void BeforeScenario()
        {
            base.BeforeScenario();
            _seleniumDriver.SetBrowser(_configuration.Browser);
            _driver = _seleniumDriver.GetWebDriver;
        }

        [AfterScenario]
        public new void AfterScenario()
        {
            base.AfterScenario();
        }
        
        [BeforeFeature]
        public new static void BeforeFeatureStep(FeatureContext featureContext)
        {
            StepBase.BeforeFeatureStep(featureContext);
        }

        [Given(@"I have registered on Zoopla with (.*) and logged in")]
        public void RegisterAndLogIn(string userProfile)
        {
            _driver.Navigate().GoToUrl(_configuration.RegisterUserUrl);
            var registerUserPage = new RegisterUserPage();
            PageFactory.InitElements(_driver, registerUserPage);
            registerUserPage.RegisterAsNewUser(_parsonDetails.EmailAddress(), _parsonDetails.Password(), userProfile);
        }

        [Then(@"I am able to register for email alerts with frequency of (.*)")]
        public void GetAlertsForChosenFrequency(string alertFrequency)
        {
            var registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, registerEmailAlertsPage);
            registerEmailAlertsPage.CreateEmailAlert(alertFrequency);
        }

        [Then(@"I am able to update (.*) to new email frequency of (.*)")]
        public void UpdateEmailUpdateFrequency(string currentAlertFrequency, string newAlertFrequency)
        {
            var registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, registerEmailAlertsPage);
            registerEmailAlertsPage.UpdateExistingEmailAlert(newAlertFrequency);
        }

        [Given(@"I am on Zoopla home page")]
        public void VisitZooplaHomePage()
        {
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            searchToRentPropertyPage = new HomePage();
            PageFactory.InitElements(_driver, searchToRentPropertyPage);
            searchToRentPropertyPage.AcceptCookies();
        }

        [When(@"I try to search property described in (.*)")]
        public void WhenITryToSearchPropertyIn(string testCase)
        {
            var searchParameters = _testData.GetTestParameters(testCase,_configuration.DataFile);
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            searchToRentPropertyPage = new HomePage();
            PageFactory.InitElements(_driver, searchToRentPropertyPage);
            searchToRentPropertyPage.SearchToRentProperty(searchParameters);
        }

        [Then(@"I get results from my property search")]
        public void ThenIAmGetResultsFromMyPropertySearch()
        {
           
        }


    }
}
