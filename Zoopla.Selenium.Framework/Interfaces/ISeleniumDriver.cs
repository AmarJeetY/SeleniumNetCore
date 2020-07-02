using OpenQA.Selenium;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumDriver
    {
        public IWebDriver GetWebDriver { get; }
        public void CloseWebDriverInstance();
    }
}
