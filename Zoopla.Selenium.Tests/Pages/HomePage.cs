﻿using System.Collections.Generic;
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

        [FindsBy(How = How.Id, Using = "price_frequency")]
        private IWebElement _priceFrequencyElement;

        [FindsBy(How = How.Id, Using = "furnished_state")]
        private IWebElement _furnishedStateElement;

        [FindsBy(How = How.Id, Using = "keywords")]
        private IWebElement _typeKeywordElement;

        [FindsBy(How = How.Id, Using = "radius")]
        private IWebElement _radiusElement;

        [FindsBy(How = How.Id, Using = "added")]
        private IWebElement _addedElement;

        [FindsBy(How = How.Id, Using = "sort_by")]
        private IWebElement _sortByElement;

        [FindsBy(How = How.Id, Using = "include_shared_accommodation")]
        private IWebElement _sharedAccomdationElement;

        [FindsBy(How = How.Id, Using = "include_rented")]
        private IWebElement _letAgreedElement;


        [FindsBy(How = How.Id, Using = "search-submit")]
        private IWebElement _searchSubmitElement;



        public void AcceptCookies() => _acceptCookiesElement.Click();
        private void SelectToRent() => _toRentSelectionElement.Click();

        private void SelectAdvanceSearchOptions() => _advanceSearchOptionsElement.Click();
        private void TypeAreaToSearchFor(string area)
        {
            if (area.IsNullOrEmpty()) return;
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

        private void TypeKeywords(string keyword)
        {
            if (keyword.IsNullOrEmpty()) return;
            _typeKeywordElement.Clear();
            _typeKeywordElement.SendKeys(keyword);
            System.Threading.Thread.Sleep(3000);
            _typeKeywordElement.Click();
            _typeKeywordElement.SendKeys(Keys.ArrowDown);
            _typeKeywordElement.SendKeys(Keys.Tab);

        }
        private void SelectPriceForPeriod(string priceForPeriod)
        {
            if (priceForPeriod.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_priceFrequencyElement);
            selectElement.SelectByText(priceForPeriod);
        }
        private void SelectFurniture(string furniture)
        {
            if (furniture.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_furnishedStateElement);
            selectElement.SelectByText(furniture);
        }

        private void SelectSortBy(string sortBy)
        {
            if (sortBy.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_sortByElement);
            selectElement.SelectByText(sortBy);
        }

        private void SelectDistanceFromLocation(string distanceFromLocation)
        {
            if (distanceFromLocation.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_radiusElement);
            selectElement.SelectByText(distanceFromLocation);
        }

        private void SelectAdded(string added)
        {
            if (added.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_addedElement);
            selectElement.SelectByText(added);
        }

        private void SelectLetAgreed(string letAgreed)
        {
            if (letAgreed.IsNullOrEmpty()) return;
            _letAgreedElement.Click();
        }

        private void SelectSharedAcc(string sharedAcc)
        {
            if (sharedAcc.IsNullOrEmpty()) return;
            _sharedAccomdationElement.Click();
        }

        private void SubmitSearch() => _searchSubmitElement.Click();
        public void SearchToRentProperty(Dictionary<string,string> searchParameters)
        {
            SelectToRent();
            TypeAreaToSearchFor(searchParameters["SearchArea"]);
            SelectMinimumPrice(searchParameters["MinPrice"]);
            SelectMaximumPrice(searchParameters["MaxPrice"]);
            SelectMinimumBeds(searchParameters["Bedrooms"]);
            TypeKeywords(searchParameters["Keywords"]);
            SelectPriceForPeriod(searchParameters["PriceFrequency"]);
            SelectFurniture(searchParameters["Furniture"]);
            SelectDistanceFromLocation(searchParameters["DistanceFromLocation"]);
            SelectAdded(searchParameters["Added"]);
            SelectSortBy(searchParameters["SortBy"]);
            SelectSharedAcc(searchParameters["SharedAcc"]);
            SelectLetAgreed(searchParameters["LetAgreed"]);
            SelectAdvanceSearchOptions();
            SubmitSearch();
        }
        
        public void SearchForSaleProperty()
        {
            // Code for searching property for Buy
        }
    }
}
