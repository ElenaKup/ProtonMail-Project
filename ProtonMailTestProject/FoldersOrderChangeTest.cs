using NUnit.Framework;
using ProtonmailProject.Pages;


namespace ProtonmailProject
{
    class FoldersOrderChangeTest : BaseTest
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
        }

        [Test]
        public void ChangeOrderOfFoldersTest()
        {
            foldersAndLabelsPage
                .DragAndDropSecondFolder()
                .AssertFoldersOrderIsChanged();
        }

        [TearDown]
        public void ChnageOrderOfFoldersBackAndLogOut()
        {
            DoScreenshot();
            foldersAndLabelsPage
                .DragAndDropSecondFolder()
                .Logout();
        }
    }


}
