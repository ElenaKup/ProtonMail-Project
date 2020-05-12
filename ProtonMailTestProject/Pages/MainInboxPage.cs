using NUnit.Framework;
using NUnitTestProject2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace ProtonmailProject.Pages
{
    class MainInboxPage : BasePage
             
    {
        public MainInboxPage(IWebDriver driver) : base(driver) { }
        private IWebElement WelcomeToProtonMailModalTitle => Driver.FindElement(By.Id("modalTitle"));
        private By WelcomeToProtonMailModalCloseButtonWait => By.CssSelector(".pm-modalClose");
        private IWebElement WelcomeToProtonMailModalCloseButton => Driver.FindElement(By.CssSelector(".pm-modalClose"));
        private IWebElement FoldersLabelsSettings => Driver.FindElement(By.Id("labelSettings"));

        public void AssertWelcomeModalIsVisible()
        {
            Assert.IsNotNull(WelcomeToProtonMailModalTitle, "Welcome to ProtonMail 4.0");
        }

        public MainInboxPage CloseWelcomeModal()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(WelcomeToProtonMailModalCloseButtonWait));
            WelcomeToProtonMailModalCloseButton.Click();
            return this;
        }

        public FoldersAndLabelsPage ClickFoldersLabelsSettings()
        {
            FoldersLabelsSettings.Click();
            return new FoldersAndLabelsPage(Driver);
        }
        
    }
}
