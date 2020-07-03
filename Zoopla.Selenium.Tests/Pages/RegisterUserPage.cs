
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    public class RegisterUserPage 
    {

        //driver.FindElement(By.ClassName("ui-button-secondary")).Click();
        //driver.FindElement(By.Id("register_email")).SendKeys(RandomString(5));
        //driver.FindElement(By.Id("register_password")).SendKeys("Password123!");
        //var dropdownselection = driver.FindElement(By.Id("sender_property_status"));
        //var selectElement = new SelectElement(dropdownselection);
        //selectElement.SelectByText("I am looking to rent");
        //driver.FindElement(By.Id("register_submit")).Click();
        //driver.FindElement(By.Id("fancybox-close")).Click();

        [FindsBy(How = How.ClassName,Using = "ui-button-secondary")]
        private IWebElement acceptCookiesElement;

        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement emailElement;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement passwordElement;

        [FindsBy(How = How.Id, Using = "sender_property_status")]
        private IWebElement requiredPropertyElement;

        [FindsBy(How = How.Id, Using = "register_submit")]
        private IWebElement submitRegistrationRequestElement;

        [FindsBy(How = How.Id, Using = "fancybox-close")]
        private IWebElement closeSocialMediaElement;

        private void AcceptCookies()
        {
            acceptCookiesElement.Click();
        }

        private void TypeEmailAddress(string email) => emailElement.SendKeys(email);

        private void TypePassword(string password) => passwordElement.SendKeys(password);

        private void SelectRequiredProperty()
        {
            var selectElement = new SelectElement(requiredPropertyElement);
            selectElement.SelectByText("I am looking to rent");
        }

        private void ClickSubmitRegistration() => submitRegistrationRequestElement.Click();

        private void SelectSocialMediaChoicesPopup() => closeSocialMediaElement.Click();
        
        public void RegisterAsNewUser(string email, string password)
        {
            AcceptCookies();
            TypeEmailAddress(email);
            TypePassword(password);
            SelectRequiredProperty();
            ClickSubmitRegistration();
            SelectSocialMediaChoicesPopup();
        }
    }

}

