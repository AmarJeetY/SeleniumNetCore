using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class HomePage
    {
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

        [FindsBy(How = How.ClassName, Using = "ui-button-secondary")]
        private IWebElement _acceptCookiesElement;

        [FindsBy(How = How.XPath, Using = "(//span[contains(.,'To rent')])[1]")]
        private IWebElement _toRentSelectionElement;
        
        [FindsBy(How = How.ClassName, Using = "delete_autocomplete_suggestion")]
        private IWebElement _deleteAutoSuggestionElement;
        
        [FindsBy(How = How.Id, Using = "search-input-location")]
        private IWebElement _searchLocationInputElement;

        [FindsBy(How = How.Id, Using = "rent_price_min_per_month")]
        private IWebElement _minimumPriceElement;

        [FindsBy(How = How.Id, Using = "rent_price_max_per_month")]
        private IWebElement _maximumPriceElement;

        [FindsBy(How = How.Id, Using = "beds_min")]
        private IWebElement _miniumBedsElement;

        [FindsBy(How = How.Id, Using = "search-submit")]
        private IWebElement _searchSubmitElement;

        public void AcceptCookies() => _acceptCookiesElement.Click();
        private void SelectToRent() => _toRentSelectionElement.Click();

        private void TypeAreaToSearchFor(string area)
        {
            _searchLocationInputElement.Clear();
            _searchLocationInputElement.SendKeys(area);
            System.Threading.Thread.Sleep(3000);
            _searchLocationInputElement.Click();
            _searchLocationInputElement.SendKeys(Keys.ArrowDown);
            
            //_deleteAutoSuggestionElement.Click();
            _searchLocationInputElement.SendKeys(Keys.Tab);
        }
        private void SelectMinimumPrice(string minPrice)
        {
            var selectElement = new SelectElement(_minimumPriceElement);
            selectElement.SelectByText(minPrice);
        }

        private void SelectMaximumPrice(string maxPrice)
        {
            var selectElement = new SelectElement(_maximumPriceElement);
            selectElement.SelectByText(maxPrice);
        }

        private void SelectMinimumBeds(string minBeds)
        {
            var selectElement = new SelectElement(_miniumBedsElement);
            selectElement.SelectByText(minBeds);
        }
        private void SubmitSearch() => _searchSubmitElement.Click();
        public void SearchToRentProperty(Dictionary<string,string> searchParameters)
        {
            //testcase,TypeOfSearch,SearchArea,MinPrice,MaxPrice,PropertyType
            //AcceptCookies();
            SelectToRent();
            TypeAreaToSearchFor(searchParameters["SearchArea"]);
            SelectMinimumPrice(searchParameters["MinPrice"]);
            SelectMaximumPrice(searchParameters["MaxPrice"]);
            SelectMinimumBeds(searchParameters["Bedrooms"]);
            SubmitSearch();
        }
        public void SearchForSaleProperty()
        {
            // Code for searching property for Buy
        }
    }
}
