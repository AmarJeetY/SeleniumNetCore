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
        private HomePage _searchToRentPropertyPage;
        private EmailAlerts _registerEmailAlertsPage;
        private TravelTime _travelTimePage;

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

        [Given(@"I goto travel search page")]
        public void GivenIGotoTravelSearchPage()
        {
            _driver.Navigate().GoToUrl(_configuration.TravelTimeUrl);
            _travelTimePage = new TravelTime();
            PageFactory.InitElements(_driver, _travelTimePage);
        }

        [Then(@"I am able to register for email alerts with frequency of (.*)")]
        public void GetAlertsForChosenFrequency(string alertFrequency)
        {
            _registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, _registerEmailAlertsPage);
            _registerEmailAlertsPage.CreateEmailAlert(alertFrequency);
        }

        [Then(@"I am able to update (.*) to new email frequency of (.*)")]
        public void UpdateEmailUpdateFrequency(string currentAlertFrequency, string newAlertFrequency)
        {
            _registerEmailAlertsPage.UpdateExistingEmailAlert(newAlertFrequency);
        }

        [Given(@"I am on Zoopla home page")]
        public void VisitZooplaHomePage()
        {
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            _searchToRentPropertyPage = new HomePage();
            PageFactory.InitElements(_driver, _searchToRentPropertyPage);
            _searchToRentPropertyPage.AcceptCookies();
        }

        [When(@"I try to search property described in (.*)")]
        public void WhenITryToSearchPropertyIn(string testCase)
        {
            var searchParameters = _testData.GetTestParameters(testCase,_configuration.DataFile);
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            _searchToRentPropertyPage = new HomePage();
            PageFactory.InitElements(_driver, _searchToRentPropertyPage);
            _searchToRentPropertyPage.SearchToRentProperty(searchParameters);
        }

        [When(@"I try to search property based on travel time described in (.*)")]
        public void SearchPropertyBasedOnTravelTime(string testCase)
        {
            var searchParameters = _testData.GetTestParameters(testCase, _configuration.DataFile);
            PageFactory.InitElements(_driver, _travelTimePage);
            _travelTimePage.SearchPropertyBasedOnTravelTime(searchParameters);
        }
    }
}
