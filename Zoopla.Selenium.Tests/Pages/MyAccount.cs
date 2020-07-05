using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Zoopla.Selenium.Tests.Pages
{
    internal class MyAccount
    {
        [FindsBy(How = How.ClassName, Using = "myaccount-tile-header")]
        private IWebElement _recentSearchesElement;

        [FindsBy(How = How.XPath, Using = "//a[@class='myaccount-alert-action'][contains(.,'View')]")]
        private IWebElement _viewSavedSearchElement;

        [FindsBy(How = How.XPath, Using = "//i[contains(@class,'icon icon-star')])[1]")]
        private IWebElement _firstPropertySaveElement;
        
        private void SelectRecentSearch() => _recentSearchesElement.Click();
        private void ViewRecentSearch() => _viewSavedSearchElement.Click();
        private void UniquePropertySave() => _firstPropertySaveElement.Click();
        public void RetrieveSavedSearchResults()
        {
            SelectRecentSearch();
            ViewRecentSearch();
        }

        public void SaveUniqueProperty()
        {
            //SelectRecentSearch();
            //ViewRecentSearch();
            UniquePropertySave();
        }


    }
}
