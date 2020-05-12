using NUnit.Framework;
using NUnitTestProject2.Pages;
using OpenQA.Selenium;
using System.Threading;

namespace ProtonmailProject.Pages
{
    class CreateNewFolderModalPage : BasePage
    {
        public CreateNewFolderModalPage (IWebDriver driver) : base(driver) { }
        private IWebElement CreateFolderModalTitle => Driver.FindElement(By.ClassName("pm-modalTitle"));
        private IWebElement FolderNameInputField => Driver.FindElement(By.Id("accountName"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[contains(.,'Submit')]"));

        public void AssertCreateFolderModalIsVisible()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Create a new folder", CreateFolderModalTitle.Text);
        }

        public CreateNewFolderModalPage EnterFoldersName(string foldersName)
        {
            FolderNameInputField.Click();
            FolderNameInputField.SendKeys(foldersName);
            return this;
        }

        public void AssertFolderNameIsFilledIn(string foldersName)
        {
          Assert.AreEqual(foldersName, FolderNameInputField.GetAttribute("value"));
        }
        
        public FoldersAndLabelsPage SubmitFolderCreation()
        {
            SubmitButton.Click();
            return new FoldersAndLabelsPage(Driver);
        }

    }
}
    