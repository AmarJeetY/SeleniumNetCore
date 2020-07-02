using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Zoopla.Selenium.Framework.Driver
{
    class SeleniumDriver
    {
        public static string Browser { get; set; }
        public static IWebDriver WebDriver;

        public static IWebDriver CreateWebDriver()
        {
            WebDriver = Browser.ToLower() switch
            {
                "chrome" => (IWebDriver) new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "ie" => new InternetExplorerDriver(),
                _ => new ChromeDriver()
            };
            
            // Adding implicit wait of 10 seconds based on page loading times
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriver.Manage().Window.Maximize();

            return WebDriver;
        }
    }
}

