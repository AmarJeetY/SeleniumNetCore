using System.Collections.Generic;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class HomePage
    {
        [FindsBy(How = How.ClassName, Using = "ui-button-secondary")]
        private IWebElement _acceptCookiesElement;

        [FindsBy(How = How.XPath, Using = "(//span[contains(.,'To rent')])[1]")]
        private IWebElement _toRentSelectionElement;

        [FindsBy(How = How.CssSelector, Using = ".search-advanced-toggle > span")]
        private IWebElement _advanceSearchOptionsElement;

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

        private void SelectAdvanceSearchOptions() => _advanceSearchOptionsElement.Click();
        private void TypeAreaToSearchFor(string area)
        {
            _searchLocationInputElement.Clear();
            _searchLocationInputElement.SendKeys(area);
            System.Threading.Thread.Sleep(3000);
            _searchLocationInputElement.Click();
            _searchLocationInputElement.SendKeys(Keys.ArrowDown);
            _searchLocationInputElement.SendKeys(Keys.Tab);
        }
        private void SelectMinimumPrice(string minPrice)
        {
            if (minPrice.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_minimumPriceElement);
            selectElement.SelectByText(minPrice);
        }

        private void SelectMaximumPrice(string maxPrice)
        {
            if (maxPrice.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_maximumPriceElement);
            selectElement.SelectByText(maxPrice);
        }

        private void SelectMinimumBeds(string minBeds)
        {
            if (minBeds.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_miniumBedsElement);
            selectElement.SelectByText(minBeds);
        }
        private void SubmitSearch() => _searchSubmitElement.Click();
        public void SearchToRentProperty(Dictionary<string,string> searchParameters)
        {
            SelectToRent();
            TypeAreaToSearchFor(searchParameters["SearchArea"]);
            SelectMinimumPrice(searchParameters["MinPrice"]);
            SelectMaximumPrice(searchParameters["MaxPrice"]);
            SelectMinimumBeds(searchParameters["Bedrooms"]);
            SelectAdvanceSearchOptions();
            SubmitSearch();
        }
        public void SearchForSaleProperty()
        {
            // Code for searching property for Buy
        }
    }
}
