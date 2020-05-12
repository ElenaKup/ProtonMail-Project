using NUnit.Framework;
using ProtonmailProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProtonmailProject
{
    class FolderDeleteTest : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            Login();
            mainInboxPage = new MainInboxPage(Driver);
            mainInboxPage.CloseWelcomeModal();
            foldersAndLabelsPage = new FoldersAndLabelsPage(Driver);
            createNewFolderModalPage = new CreateNewFolderModalPage(Driver);
            mainInboxPage.ClickFoldersLabelsSettings();
            foldersAndLabelsPage.ClickAddNewFolder();
            createNewFolderModalPage.EnterFoldersName(TestData.Data.FoldersName);
            createNewFolderModalPage.SubmitFolderCreation();
        }

        [Test]
        public void DeleteFolderTest()
        {
            foldersAndLabelsPage.AssertNewFoldersIsCreated(TestData.Data.FoldersName);
            foldersAndLabelsPage.DeleteThirdFolder();
            foldersAndLabelsPage.AssertNewFoldersIsDeleted();
        }

        [TearDown]
        public void LogOut()
        {
            DoScreenshot();
            foldersAndLabelsPage.Logout();
        }
    }


}
