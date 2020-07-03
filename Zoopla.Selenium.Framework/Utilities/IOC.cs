using System.Data;
using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using Zoopla.Selenium.Framework.Common.Config;
using Zoopla.Selenium.Framework.Driver;
using Zoopla.Selenium.Framework.Interfaces;
using IDataReader = Zoopla.Selenium.Framework.Interfaces.IDataReader;

namespace Zoopla.Selenium.Framework.Utilities
{
    public class IOC
    {
        public static void Register(IObjectContainer container)
        {
            RegisterConfig(container);
            container.RegisterTypeAs<SeleniumDriver, ISeleniumDriver>();
            container.RegisterTypeAs<TestData, ITestData>();
            container.RegisterTypeAs<CSVReader, IDataReader>();
            container.RegisterTypeAs<TestCaseParser, ITestCaseParser>();
            
        }

        public static T Resolve<T>(IObjectContainer container)
        {
            return container.Resolve<T>();
        }
        private static void RegisterConfig(IObjectContainer container)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();
            var configuration = builder.Build();

            var seleniumConfig = new SeleniumConfig();
            configuration.Bind("TestParameters", seleniumConfig);
            container.RegisterInstanceAs(seleniumConfig, typeof(ISeleniumConfig));
        }
    }
}