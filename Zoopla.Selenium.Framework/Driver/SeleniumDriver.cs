using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Driver
{
    public class SeleniumDriver : ISeleniumDriver
    {
        private IWebDriver _webDriver;
        private string browser = "chrome";

        private IWebDriver InitialiseWebDriver()
        {
            _webDriver = browser.ToLower() switch
            {
                "chrome" => (IWebDriver) new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "ie" => new InternetExplorerDriver(),
                _ => new ChromeDriver()
            };

            // Adding implicit wait of 10 seconds based on page loading times
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Window.Maximize();

            return _webDriver;
        }

        public IWebDriver GetWebDriver => InitialiseWebDriver();

        public void NavigateToUrl(string url)
        {
            GetWebDriver.Url = url;
        }

        //public string Title => GetWebDriver.Title;

        public void CloseWebDriverInstance()
        {
            if (_webDriver == null) return;
            _webDriver.Quit();
            _webDriver = null;
        }
    }
}