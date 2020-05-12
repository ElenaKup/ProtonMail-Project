using NUnit.Framework;
using NUnitTestProject2.Pages;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace ProtonmailProject.Pages
{
    class FoldersAndLabelsPage:BasePage
    {
        public FoldersAndLabelsPage (IWebDriver driver) : base(driver) { }
        private IWebElement FoldersAndLabelsPageTitle => Driver.FindElement(By.ClassName("sticky-title"));
        private IWebElement CreateFolderButton => Driver.FindElement(By.XPath("//button[contains(.,'Add folder')]"));
        private IWebElement EditThirdFolderButton => Driver.FindElement(By.XPath("//tr[3]/td[4]/div/button"));
        private IWebElement FolderOptions => Driver.FindElement(By.XPath("//tr[3]/td[4]/div/button[2]"));
        private IWebElement DeleteFolder => Driver.FindElement(By.XPath("/html/body/div[12]/div/ul/li/button"));
        private By DeleteFolderWait => By.XPath("/html/body/div[12]/div/ul/li/button");
        private IWebElement ConfirmDeletionOfFolderButton => Driver.FindElement(By.XPath("//button[contains(.,'Confirm')]"));
        private IWebElement AccountMenuButton => Driver.FindElement(By.ClassName("dropDown-logout-text"));
        private IWebElement LogoutButton => Driver.FindElement(By.ClassName("navigationUser-logout"));
        private IWebElement TableHeader => Driver.FindElement(By.ClassName("orderableTableHeader"));
        private IWebElement SecondFolder => Driver.FindElement(By.CssSelector("tr:nth-child(2) .cursor-row-resize"));
        private IWebElement FirstFoldersName => Driver.FindElement(By.CssSelector("tr:nth-child(1) .ellipsis"));
        private IWebElement SecondFoldersName => Driver.FindElement(By.CssSelector("tr:nth-child(2) .ellipsis"));
        private IWebElement NewFolder
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.XPath("//tr[3]/td[2]/div/span"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            }
        }

        public void AssertFoldersAndLabelsPageIsVisible()
        {
            Assert.AreEqual("Folders/labels", FoldersAndLabelsPageTitle.Text);
        }

        public CreateNewFolderModalPage ClickAddNewFolder()
        {
            CreateFolderButton.Click();
            return new CreateNewFolderModalPage(Driver);
        }

        public void AssertNewFoldersIsCreated(string foldersName)
        {
            Assert.AreEqual(foldersName, NewFolder.Text);
        }

        public EditFolderModalPage EditThirdFolder()
        {
            EditThirdFolderButton.Click();
            return new EditFolderModalPage(Driver);
        }

        public void AssertNewFoldersIsEdited(string editedfoldersName)
        {
            Thread.Sleep(500);
            Assert.AreEqual(editedfoldersName, NewFolder.Text);
        }

        public FoldersAndLabelsPage DeleteThirdFolder()
        {
            FolderOptions.Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(DeleteFolderWait));
            DeleteFolder.Click();
            ConfirmDeletionOfFolderButton.Click();
            return this;
        }

        public FoldersAndLabelsPage Logout()
        {
            AccountMenuButton.Click();
            Thread.Sleep(500);
            LogoutButton.Click();
            return this;
        }
        
        public void AssertNewFoldersIsDeleted()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            wait.Until(d => NewFolder == null);
            Assert.IsNull(NewFolder);
        }

        public FoldersAndLabelsPage DragAndDropSecondFolder()
        {
            var builder = new Actions(Driver);
            builder.DragAndDrop(SecondFolder, TableHeader);
            builder.Build().Perform();
            return this;
        }

        public void AssertFoldersOrderIsChanged()
        {
            Assert.AreEqual("SecondFolder", FirstFoldersName.Text);
            Assert.AreEqual("FirstFolder", SecondFoldersName.Text);
        }
    }

}
