namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumConfig
    {
        string RegisterUserUrl { get; set; }
        string Browser { get; set; }
        string MyZooplaUrl { get; set; }
        string ToRentUrl { get; set; }
        string ForSaleUrl { get; set; }
        string HousePrices { get; set; }

    }
}
