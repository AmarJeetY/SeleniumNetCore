using Zoopla.Selenium.PageObjects.Pages;

namespace Zoopla.Selenium.PageObjects.PageFactory
{
    public class Pages
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
           // PageFactory.InitElements(SeleniumDriver.GetWebDriver, page);
            return page;
        }


        public static RegisterUserPage RegisterUserUserPage
        {
            get { return GetPage<RegisterUserPage>(); }
        }

    }
}
