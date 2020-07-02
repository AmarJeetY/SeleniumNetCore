namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumConfig
    {
        string BaseUrl { get; set; }
        string RegisterUserUrl { get; set; }
        string Browser { get; set; }
    }
}
