using System.IO;
using BoDi;
using Microsoft.Extensions.Configuration;
using Zoopla.Selenium.Framework.Common.Config;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities
{
    public class IOC
    {
        public static void Register(IObjectContainer container)
        {
            RegisterConfig(container);
            //container.RegisterTypeAs<QuoteEngineClient, IQuoteEngineClient>();

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
            configuration.Bind("PageUrl", seleniumConfig);
            container.RegisterInstanceAs(seleniumConfig, typeof(ISeleniumConfig));
        }
    }
}

