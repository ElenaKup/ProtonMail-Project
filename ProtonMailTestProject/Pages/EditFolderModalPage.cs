using OpenQA.Selenium;
using NUnit.Framework;
using NUnitTestProject2.Pages;
using OpenQA.Selenium.Interactions;
using System.Threading;


namespace ProtonmailProject.Pages
{
    class EditFolderModalPage : BasePage
    {
        public EditFolderModalPage (IWebDriver driver) : base(driver) { }
        private IWebElement EditFolderModalTitle => Driver.FindElement(By.ClassName("pm-modalTitle"));
        private IWebElement FolderNameInputField => Driver.FindElement(By.Id("accountName"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[contains(.,'Submit')]"));
        
        public void AssertEditFolderModalIsVisible()
        {
            Thread.Sleep(1000);
            Assert.AreEqual("Edit folder", EditFolderModalTitle.Text);
        }

        public EditFolderModalPage EditFoldersName(string editedFoldersName)
        {
            var builder = new Actions(Driver);
            builder.DoubleClick(FolderNameInputField);
            builder.SendKeys(Keys.Backspace);
            builder.SendKeys(editedFoldersName);
            builder.Build().Perform();
            return this;
        }

        public void AssertFolderNameIsFilledIn(string editedfoldersName)
        {
          Assert.AreEqual(editedfoldersName, FolderNameInputField.GetAttribute("value"));
        }
        
        public FoldersAndLabelsPage SubmitFolderChange()
        {
            SubmitButton.Click();
            return new FoldersAndLabelsPage(Driver);
        }

    }
}
    