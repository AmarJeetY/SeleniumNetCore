using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestProject.SDK.PageObjects;
using Zoopla.Selenium.Framework.Interfaces;
using Zoopla.Selenium.Framework.Utilities;
using Zoopla.Selenium.Tests.Hooks;
using Zoopla.Selenium.Tests.Pages;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : StepBase
    {
        private readonly ISeleniumConfig _configuration;
        private IWebDriver _driver;
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
        
        [Given(@"I have registered on Zoopla and logged in	")]
        public void GivenIAmInNeedOfAProperty(string typeOfProperty)
        {

            //_seleniumDriver.SetBrowser(_configuration.Browser);
            //var driver = _seleniumDriver.GetWebDriver;
            //driver.Navigate().GoToUrl(_configuration.RegisterUserUrl);
            //driver.FindElement(By.ClassName("ui-button-secondary")).Click();
            //driver.FindElement(By.Id("register_email")).SendKeys(RandomString(5));
            //driver.FindElement(By.Id("register_password")).SendKeys("Password123!");
            //var dropdownselection = driver.FindElement(By.Id("sender_property_status"));
            //var selectElement = new SelectElement(dropdownselection);
            //selectElement.SelectByText("I am looking to rent");
            //driver.FindElement(By.Id("register_submit")).Click();
            //driver.FindElement(By.Id("fancybox-close")).Click();
            //driver.FindElement(By.Id("mn-rent")).Click();
            //var mywebelementt = driver.FindElement(By.Id("search-input-location"));
            //mywebelementt.SendKeys("London");
            //mywebelementt.SendKeys(Keys.Tab);

            //var minprice = driver.FindElement(By.Id("rent_price_min_per_month"));
            //var minpriceelement = new SelectElement(minprice);
            //minpriceelement.SelectByText("£800 pcm");

            //var maxprice = driver.FindElement(By.Id("rent_price_max_per_month"));
            //var maxpriceelement = new SelectElement(maxprice);
            //maxpriceelement.SelectByText("£1,000 pcm");

            //var bedrooms = driver.FindElement(By.Id("beds_min"));
            //var bedroomselement = new SelectElement(bedrooms);
            //bedroomselement.SelectByText("1+");

            //driver.FindElement(By.Id("search-submit")).Click();
            //driver.FindElement(By.Id("alert-btn-create")).Click();
            //driver.FindElement(By.Id("frequency_1")).Click();
            //driver.FindElement(By.Name("action:save")).Click();

            //driver.FindElement(By.Id("alerts-buttons-edit")).Click();

            //driver.FindElement(By.Id("frequency_3")).Click();
            //driver.FindElement(By.Name("action:save")).Click();

            //driver.Navigate().Refresh();
            ////driver.FindElement(By.ClassName("mnav__item")).Click();
            //driver.FindElement(By.Id("mn-prices")).Click();

            //driver.FindElement(By.Id("location")).Clear();
            //driver.FindElement(By.Id("location")).SendKeys("29 Broad Street, NN1 2HS");
            //driver.FindElement(By.ClassName("btn-refine-search")).Click();

            //var allpropereties = driver.FindElement(By.ClassName("hp-card-list"));

        }

        [Given(@"I have registered on Zoopla with (.*) and logged in")]
        public void RegisterAndLogIn(string userProfile)
        {
            _driver.Navigate().GoToUrl(_configuration.RegisterUserUrl);
            var registerUserPage = new RegisterUserPage();
            PageFactory.InitElements(_driver, registerUserPage);
            registerUserPage.RegisterAsNewUser(GeneratePersonData.RandomEmail(5), "Password123!", userProfile);
        }

        [Then(@"I am able to update email update frequency to (.*)")]
        public void UpdateEmailUpdateFrequency(string emailUpdateFrequency)
        {
            _driver.Navigate().GoToUrl(_configuration.MyAccountUrl);
            var registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, registerEmailAlertsPage);
            registerEmailAlertsPage.UpdateExistingEmailAlert(emailUpdateFrequency);
        }


        [When(@"I try to search property described in (.*)")]
        public void WhenITryToSearchPropertyIn(string testCase)
        {
            var parameters = _testData.GetTestParameters(testCase);
            
            _driver.FindElement(By.Id("mn-rent")).Click();
            var mywebelementt = _driver.FindElement(By.Id("search-input-location"));
            mywebelementt.SendKeys("London");
            mywebelementt.SendKeys(Keys.Tab);

            var minprice = _driver.FindElement(By.Id("rent_price_min_per_month"));
            var minpriceelement = new SelectElement(minprice);
            minpriceelement.SelectByText("£800 pcm");

            var maxprice = _driver.FindElement(By.Id("rent_price_max_per_month"));
            var maxpriceelement = new SelectElement(maxprice);
            maxpriceelement.SelectByText("£1,000 pcm");

            var bedrooms = _driver.FindElement(By.Id("beds_min"));
            var bedroomselement = new SelectElement(bedrooms);
            bedroomselement.SelectByText("1+");

            _driver.FindElement(By.Id("search-submit")).Click();
        }

        

        [Given(@"I have visited Zoopla home page and selected option (.*)")]
        public void SelectSearch(string p0)
        {

        }


        [Then(@"I am able to register for email alerts with frequency of (.*)")]
        public void GetAlertsForChosenFrequency(string alertFrequency)
        {
            _driver.Navigate().GoToUrl(_configuration.MyAccountUrl);
            var registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, registerEmailAlertsPage);
            registerEmailAlertsPage.CreateEmailAlert(alertFrequency);
        }
        

    }
}
