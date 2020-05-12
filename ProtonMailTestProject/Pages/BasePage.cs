using OpenQA.Selenium;

namespace NUnitTestProject2.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        { 
            Driver = driver;
        }
    }
}
