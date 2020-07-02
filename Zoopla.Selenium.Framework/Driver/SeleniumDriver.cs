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

        public static string Title
        {
            get { return Instance.Title; }
        }

        public static string Url
        {
            get { return Instance.Url; }
        }

        public static IWebDriver Instance
        {
            get { return WebDriver ??= CreateWebDriver(); }
        }

        public static ISearchContext SearchContextDriver
        {
            get { return Instance; }
        }

        private static IWebDriver CreateWebDriver()
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

        public static void Goto(string url)
        {
            //Instance.Url = url != null && url.Trim() == "//" ? BaseUrl : BaseUrl + url;
        }

        public static void Close()
        {
            if (WebDriver == null) return;
            Instance.Quit();
            WebDriver = null;
        }
    }
}

