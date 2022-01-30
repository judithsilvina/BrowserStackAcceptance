using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BrowserStackAcceptance.PageObjects
{
    public class BasePage
    {
        public static IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("test-type");
            options.AddArgument("disable-web-security");
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            //driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public static void OpenURL()
        {
            Driver.Navigate().GoToUrl("https://bstackdemo.com/");
        }

        public static IWebElement ElementIsClickable(IWebElement element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1000));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            return wait.Until(drv => ElementIsClickable(element));
        }

        public static void CloseTheBrowser()
        {
            Driver.Quit();
        }
    }
}