using System;
using System.Collections.Generic;
using System.Text;

namespace ProtonmailProject.Pages
{
    class TestData
    {
        public static TestData Data = new TestData ("elena.kupryte_test", "testpassword", "NewTestFolder", "NewTestFolderEdited");

        public string UserName;
        public string Password;
        public string FoldersName;
        public string EditedFoldersName;

        public TestData(string userName, string password, string foldersName, string editedFoldersName)
        {
            UserName = userName;
            Password = password;
            FoldersName = foldersName;
            EditedFoldersName = editedFoldersName;
        }
    }
}
