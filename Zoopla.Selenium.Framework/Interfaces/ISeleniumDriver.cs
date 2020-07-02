using OpenQA.Selenium;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumDriver
    {
        public IWebDriver GetWebDriver { get; }

        public void NavigateToUrl(string url);
        public void CloseWebDriverInstance();
    }
}
