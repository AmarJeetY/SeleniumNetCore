using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Zoopla.Selenium.Framework.Common.Page;

namespace Zoopla.Selenium.PageObjects.Pages
{
    public class RegisterUserPage : BasePage
    {
        #region Properties

        protected override string PageName
        {
            get { return "Home Page"; }
        }

        protected override string RelativeUrl
        {
            get { return "/"; }
        }

        protected override string Title
        {
            get { return "ASOS | Shop the Latest Clothes and Fashion Online"; }
        }

        #endregion

        #region Elements

        [FindsBy(How = How.CssSelector, Using = ".search-dropdown #search-query")]
        private IWebElement SearchQuery { get; set; }

        [FindsBy(How = How.Id, Using = "search-submit")]
        private IWebElement SearchSubmit { get; set; }

        #endregion

        #region Methods

        public void SearchForItem()
        {
            //SeleniumHelper.SendKeys(SearchQuery, "Jeans");
            //SeleniumHelper.Click(SearchSubmit);
        }
        #endregion
    }
}

