namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumConfig
    {
        string RegisterUserUrl { get;}
        string Browser { get;}
        string MyAccountUrl { get; }
        string ToRentUrl { get; }
        string ForSaleUrl { get; }
        string HousePrices { get;}

    }
}
