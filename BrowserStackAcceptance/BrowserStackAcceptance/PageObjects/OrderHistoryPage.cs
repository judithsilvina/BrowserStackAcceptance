using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BrowserStackAcceptance.Helpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BrowserStackAcceptance.PageObjects
{
    public class OrderHistoryPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//*[@id=\"checkout-app\"]/div/div/div/div/a/button")]
        public IWebElement BtnContinueShopping;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div/div[2]/div/div[1]/div/div/span")]
        public IWebElement TxtDate;

        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div[2]/div[1]")]
        public IWebElement TxtTitle;

        [FindsBy(How = How.XPath,
            Using = "/html/body/div/main/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div[2]/div[2]")]
        public IWebElement TxtDescription;

        [FindsBy(How = How.XPath,
            Using = " /html/body/div/main/div/div/div/div[2]/div/div[2]/div/div/div/div/div/div[2]/div[3]/span")]
        public IWebElement TxtPrice;


        public OrderHistoryPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public void ContinueShopping()
        {
            BtnContinueShopping.Click();
        }

        public void AssertOrderHistory(JToken ProductDetails)
        {
            string actualDate = TxtDate.Text;
            DateTime localDate = DateTime.Now;
            string expectedDate = "Delivered " + localDate.ToString("MMMM dd, yyyy");
            Assert.AreEqual(expectedDate,actualDate);
            string actualTitle = TxtTitle.Text;
            string actualDescription = TxtDescription.Text;
            string actualPrice = TxtPrice.Text;
            string expectedProductName = (string)ProductDetails.SelectToken("$..title");
            string expectedPrice = (string)ProductDetails.SelectToken("$..price");
            string expectedCurrencyFormat = (string)ProductDetails.SelectToken("$..currencyFormat");
            string expectedProductPrice = expectedCurrencyFormat + expectedPrice;
            Assert.AreEqual("Title: " + expectedProductName, actualTitle);
            Assert.AreEqual("Description: " + expectedProductName, actualDescription);
            Assert.AreEqual(expectedProductPrice +".00", actualPrice);
        }


    }
}




