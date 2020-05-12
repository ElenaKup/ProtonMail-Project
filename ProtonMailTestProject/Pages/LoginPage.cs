using NUnitTestProject2.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtonmailProject.Pages
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        private IWebElement UserNameInputField => Driver.FindElement(By.Id("username"));
        private IWebElement PasswordInputField => Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => Driver.FindElement(By.Id("login_btn"));

        public LoginPage EnterUserEmail(string userName)
        {
            UserNameInputField.Click();
            UserNameInputField.SendKeys(userName);
            return this;
        }
        public LoginPage EnterUserPassword(string password)
        {
            PasswordInputField.Click();
            PasswordInputField.SendKeys(password);
            return this;
        }
        public MainInboxPage clickLogin()
        {
            LoginButton.Click();
            return new MainInboxPage(Driver);
        }
    }

}
