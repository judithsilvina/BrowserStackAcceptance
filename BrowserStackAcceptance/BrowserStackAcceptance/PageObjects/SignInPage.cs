using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace BrowserStackAcceptance.PageObjects
{
    public class SignInPage : BasePage
    {
        
   
        
        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement TxtUserName;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement TxtPassword;

        [FindsBy(How = How.Id, Using = "login-btn")]
        public IWebElement BtnSubmit;

        public SignInPage()

        {
            PageFactory.InitElements(Driver, this);
        }

        public SignInPage EnterUserNameAndPassword()
        {
            //TxtUserName = driver.FindElement(By.CssSelector("div.css-1hwfws3"));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(TxtUserName);
            actions.ClickAndHold();
            actions.SendKeys("demouser");
            actions.SendKeys(Keys.Enter);
            actions.Build().Perform();
            //Driver.FindElement(By.Id("react-select-2-input")).SendKeys( Keys.ArrowDown);
            actions.MoveToElement(TxtPassword);
            actions.ClickAndHold();
            actions.SendKeys("testingisfun99");
            actions.SendKeys(Keys.Enter);
            actions.Build().Perform();
            //TxtPassword.SendKeys("testingisfun99");
            return this;
        }

        public ProductsPage ClickOnSubmit()
        {
            BtnSubmit.Click();
            return new ProductsPage();
        }
    }
}
