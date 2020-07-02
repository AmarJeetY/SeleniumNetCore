using System;
using System.Collections.Generic;
using System.Text;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Common.Config
{
    public class SeleniumConfig : ISeleniumConfig
    {
        public string BaseUrl { get; set; }
        public string RegisterUserUrl { get; set; }
        public string Browser { get; set; }
    }
}
