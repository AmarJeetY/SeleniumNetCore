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
        public static IWebDriver WebDriver;
        private static string baseURL = ConfigurationManager.AppSettings["url"];
        private static string browser = ConfigurationManager.AppSettings["browser"];
        
        private void InitialiseWebDriver()
        {
            WebDriver = browser.ToLower() switch
            {
                "chrome" => (IWebDriver) new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "ie" => new InternetExplorerDriver(),
                _ => new ChromeDriver()
            };
            
            // Adding implicit wait of 10 seconds based on page loading times
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriver.Manage().Window.Maximize();
            NavigateToUrl(baseURL);
        }
        public IWebDriver GetWebDriver => WebDriver;

        public static void NavigateToUrl(string url)
        {
            WebDriver.Url = url;
        }

        public string Title => WebDriver.Title;

        public void CloseWebDriverInstance()
        {
            if (WebDriver == null) return;
            WebDriver.Quit();
            WebDriver = null;
        }
    }
}