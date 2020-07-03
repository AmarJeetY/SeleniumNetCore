using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class RegisterUserPage
    {
        [FindsBy(How = How.ClassName, Using = "ui-button-secondary")]
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
        private IWebElement closeSocialMediaChoicesElement;

        private void AcceptCookies() => acceptCookiesElement.Click();
        private void TypeEmailAddress(string email) => emailElement.SendKeys(email);
        private void TypePassword(string password) => passwordElement.SendKeys(password);

        private void SelectUserProfile(string userProfile)
        {
            var selectElement = new SelectElement(requiredPropertyElement);
            selectElement.SelectByText(userProfile);
        }
        private void ClickSubmitRegistration() => submitRegistrationRequestElement.Click();
        private void SelectSocialMediaChoicesPopup() => closeSocialMediaChoicesElement.Click();
        public void RegisterAsNewUser(string email, string password, string userProfile)
        {
            AcceptCookies();
            TypeEmailAddress(email);
            TypePassword(password);
            SelectUserProfile(userProfile);
            ClickSubmitRegistration();
            SelectSocialMediaChoicesPopup();
        }
    }
}