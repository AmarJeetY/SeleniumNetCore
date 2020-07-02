using OpenQA.Selenium;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumDriver
    {
        public static IWebDriver GetWebDriver { get; }
    }
}
