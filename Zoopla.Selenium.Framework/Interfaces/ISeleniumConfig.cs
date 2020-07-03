﻿namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumConfig
    {
        string RegisterUserUrl { get; set; }
        string Browser { get; set; }
        string MyAccountUrl { get; set; }
        string ToRentUrl { get; set; }
        string ForSaleUrl { get; set; }
        string HousePrices { get; set; }

    }
}
