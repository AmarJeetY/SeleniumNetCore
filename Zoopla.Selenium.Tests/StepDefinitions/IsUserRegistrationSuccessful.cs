using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Zoopla.Selenium.Framework.Interfaces;
using Zoopla.Selenium.Tests.Hooks;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    [Binding]
    public class IsUserRegistrationSuccessful : StepBase
    {
        private readonly ISeleniumConfig _configuration;
        public IsUserRegistrationSuccessful(ISeleniumConfig configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

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
            _seleniumDriver.SetBrowser(_configuration.Browser);
            var driver = _seleniumDriver.GetWebDriver;
            driver.Navigate().GoToUrl(_configuration.RegisterUserUrl);
            driver.FindElement(By.ClassName("ui-button-secondary")).Click();
            driver.FindElement(By.Id("register_email")).SendKeys(RandomString(5));
            driver.FindElement(By.Id("register_password")).SendKeys("Password123!");
            var dropdownselection = driver.FindElement(By.Id("sender_property_status"));
            var selectElement = new SelectElement(dropdownselection);
            selectElement.SelectByText("I am looking to rent");
            driver.FindElement(By.Id("register_submit")).Click();
            driver.FindElement(By.Id("fancybox-close")).Click();
            driver.FindElement(By.Id("mn-rent")).Click();
            var mywebelementt = driver.FindElement(By.Id("search-input-location"));
            mywebelementt.SendKeys("London");
            mywebelementt.SendKeys(Keys.Tab);

            var minprice = driver.FindElement(By.Id("rent_price_min_per_month"));
            var minpriceelement = new SelectElement(minprice);
            minpriceelement.SelectByText("£800 pcm");

            var maxprice = driver.FindElement(By.Id("rent_price_max_per_month"));
            var maxpriceelement = new SelectElement(maxprice);
            maxpriceelement.SelectByText("£1,000 pcm");

            var bedrooms = driver.FindElement(By.Id("beds_min"));
            var bedroomselement = new SelectElement(bedrooms);
            bedroomselement.SelectByText("1+");

            driver.FindElement(By.Id("search-submit")).Click();
            driver.FindElement(By.Id("alert-btn-create")).Click();
            driver.FindElement(By.Id("frequency_1")).Click();
            driver.FindElement(By.Name("action:save")).Click();

            driver.FindElement(By.Id("alerts-buttons-edit")).Click();

            driver.FindElement(By.Id("frequency_3")).Click();
            driver.FindElement(By.Name("action:save")).Click();

            driver.Navigate().Refresh();
            //driver.FindElement(By.ClassName("mnav__item")).Click();
            driver.FindElement(By.Id("mn-prices")).Click();

            driver.FindElement(By.Id("location")).SendKeys("29 Broad Street, NN1 2HS");
            driver.FindElement(By.ClassName("btn-refine-search")).Click();

            var allpropereties = driver.FindElement(By.ClassName("hp-card-list"));



        }

        [When(@"I register myself on Zoopla website")]
        public void WhenIRegisterMyselfOnZooplaWebsite()
        {
            
        }

        [Then(@"I get (.*) of registration")]
        public void ThenIGetOfRegistration(string p0)
        {

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + "+blacklist@test.com";
        }


    }
}
