using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Common.Config
{
    public class SeleniumConfig : ISeleniumConfig
    {
        public string RegisterUserUrl { get;}
        public string Browser { get;}
        public string MyAccountUrl { get;}
        public string ToRentUrl { get;}
        public string ForSaleUrl { get; }
        public string HousePrices { get;}
    }
}
