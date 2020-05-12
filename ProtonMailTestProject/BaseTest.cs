using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using ProtonmailProject.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProtonmailProject
{
    class BaseTest
    {
        protected IWebDriver Driver;
        protected LoginPage loginPage;
        protected MainInboxPage mainInboxPage;
        protected FoldersAndLabelsPage foldersAndLabelsPage;
        protected CreateNewFolderModalPage createNewFolderModalPage;
        protected EditFolderModalPage editFolderModalPage;

        [SetUp]
        public void InitDriver()
        {
            Driver = MyDriver.InitDriver(Browser.Chrome);
            Driver.Url = "https://beta.protonmail.com/login";
            Driver.Manage().Window.Maximize();
            InitPages();
        }

        private void InitPages()
        {
            loginPage = new LoginPage(Driver);
        }
        
        public void Login()
        {
            loginPage.EnterUserEmail(TestData.Data.UserName);
            loginPage.EnterUserPassword(TestData.Data.Password);
            loginPage.clickLogin();
        }

        [TearDown]
        public void QuitDriver()
        {
            Driver.Close();
        }
        protected byte[] DoScreenshot()
        {
            Screenshot screenshot = Driver.TakeScreenshot();
            string screenshotPath = $"{TestContext.CurrentContext.WorkDirectory}/Screenshots";
            Directory.CreateDirectory(screenshotPath);
            string screenshotFile = Path.Combine(screenshotPath, $"{TestContext.CurrentContext.Test.Name}.png");

            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine("screenshot: file://" + screenshotFile);

            // Add that file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            return screenshot.AsByteArray;
        }
    }
}

