using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrowserStackAcceptance.PageObjects
{
    public class MainPage : BasePage
    {

        [FindsBy(How = How.Id, Using = "signin")]
        public IWebElement? LinkSignIn;

        [FindsBy(How = How.Id, Using = "orders")]
        public IWebElement LinkOrders;

        public MainPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public SignInPage ClickOnSignIn()
        {
            LinkSignIn.Click();
            return new SignInPage();
        }

        public OrderHistoryPage ClickOnOrders()
        {
            LinkOrders.Click();
            return new OrderHistoryPage();
        }

    }
}