using NUnit.Framework;
using ProtonmailProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtonmailProject
{
    class FolderCreateTest : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            Login();
            mainInboxPage = new MainInboxPage(Driver);
            mainInboxPage.CloseWelcomeModal();
            foldersAndLabelsPage = new FoldersAndLabelsPage(Driver);
            createNewFolderModalPage = new CreateNewFolderModalPage(Driver);
        }

        [Test]
        public void CreateFolderTest()
        {
            mainInboxPage.ClickFoldersLabelsSettings();
            foldersAndLabelsPage.AssertFoldersAndLabelsPageIsVisible();
            foldersAndLabelsPage.ClickAddNewFolder();
            createNewFolderModalPage.AssertCreateFolderModalIsVisible();
            createNewFolderModalPage.EnterFoldersName(TestData.Data.FoldersName);
            createNewFolderModalPage.AssertFolderNameIsFilledIn(TestData.Data.FoldersName);
            createNewFolderModalPage.SubmitFolderCreation();
            foldersAndLabelsPage.AssertNewFoldersIsCreated(TestData.Data.FoldersName);
        }

        [TearDown]
        public void DeleteFolderAndLogOut()
        {
            DoScreenshot();
            foldersAndLabelsPage
                .DeleteThirdFolder()
                .Logout();
        }
    }


}
