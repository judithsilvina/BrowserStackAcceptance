using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserStackAcceptance.Helpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BrowserStackAcceptance.PageObjects
{
    public class OrdersPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"checkout-app\"]/div/div/aside/article/section[2]/div/div/span[2]/span")]
        public IWebElement TxtTotalPrice;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]/div/div[2]/div")]
        public IWebElement TxtPrice;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]/div/div[1]/h5")]
        public IWebElement TxtProductName;

        [FindsBy(How = How.Id, Using = "firstNameInput")]
        public IWebElement TxtFirstName;

        [FindsBy(How = How.Id, Using = "lastNameInput")]
        public IWebElement TxtLastName;

        [FindsBy(How = How.Id, Using = "addressLine1Input")]
        public IWebElement TxtAddress;

        [FindsBy(How = How.Id, Using = "provinceInput")]
        public IWebElement TxtState;

        [FindsBy(How = How.Id, Using = "postCodeInput")]
        public IWebElement TxtPostCode;

        [FindsBy(How = How.Id, Using = "checkout-shipping-continue")]
        public IWebElement BtnSubmit;

        public OrdersPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public  string GetProductName()
        {
            string productName = TxtProductName.Text;
            Console.WriteLine(productName);
            return productName;
        }
        public string getPrice()
        {
            string productPrice = TxtPrice.Text;
            Console.WriteLine(productPrice);
            return productPrice;
        }

        public string getTotalPrice()
        {
            string totalPrice = TxtTotalPrice.Text;
            Console.WriteLine(totalPrice);
            return totalPrice;
        }

        public OrderHistoryPage SubmitShippingAddress()
        {
            TxtFirstName.SendKeys("Judith");
            TxtLastName.SendKeys("Silvina");
            TxtAddress.SendKeys("13, starling st");
            TxtState.SendKeys("Vic");
            TxtPostCode.SendKeys("3125");
            BtnSubmit.Click();
            return new OrderHistoryPage();
        }
    }
}




