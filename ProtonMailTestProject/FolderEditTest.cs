using NUnit.Framework;
using ProtonmailProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProtonmailProject
{
    class FolderEditTest:BaseTest
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
            editFolderModalPage = new EditFolderModalPage(Driver);
        }

        [Test]
        public void EditFolderTest()
        {
            foldersAndLabelsPage.EditThirdFolder();
            editFolderModalPage.AssertEditFolderModalIsVisible();
            editFolderModalPage.EditFoldersName(TestData.Data.EditedFoldersName);
            editFolderModalPage.AssertFolderNameIsFilledIn(TestData.Data.EditedFoldersName);
            editFolderModalPage.SubmitFolderChange();
            foldersAndLabelsPage.AssertNewFoldersIsEdited(TestData.Data.EditedFoldersName);
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
