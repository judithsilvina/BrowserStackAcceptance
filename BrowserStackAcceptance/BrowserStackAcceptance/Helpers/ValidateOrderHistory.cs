using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserStackAcceptance.PageObjects;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace BrowserStackAcceptance.Helpers
{

    public class ValidateOrderHistory : MainPage
    {
        public static ProductsPage GetProd = new ProductsPage();
        public static OrdersPage orders = new OrdersPage();
        public static MainPage main = new MainPage();
        public static OrderHistoryPage OrderConfirmation = new OrderHistoryPage();
        public static void signIn()
        {
            SignInPage signIn = new SignInPage();
            main.ClickOnSignIn();
            SleepFor10Sec();
            signIn.EnterUserNameAndPassword();
            signIn.ClickOnSubmit();
        }

        public static void SleepFor10Sec()
        {
            Thread.Sleep(1000);
        }

        public static JToken GetProductDetails()
        {
            
            return GetProd.getProductsAsync(1);
        }

        public static void AddToCart()
        {
            SleepFor10Sec();
            SleepFor10Sec();
            GetProd.AddToCart();
            SleepFor10Sec();
            SleepFor10Sec();
        }
        public static void ValidateOrderDetailsinSummarypage(JToken expectedProductDetails)
        {
            string actualProductName = orders.GetProductName();
            string actualProductPrice = orders.getPrice();
            string actualTotalPrice = orders.getTotalPrice();
            string expectedProductName = (string)expectedProductDetails.SelectToken("$..title") ;
            string expectedPrice = (string)expectedProductDetails.SelectToken("$..price");
            string expectedCurrencyFormat = (string)expectedProductDetails.SelectToken("$..currencyFormat");
            string expectedProductPrice = expectedCurrencyFormat+expectedPrice;
            Assert.AreEqual(expectedProductName, actualProductName);
            Assert.AreEqual(expectedProductPrice, actualProductPrice);
        }

        public static void SubmitShippingAddressAndContinueSopping()
        {
            orders.SubmitShippingAddress();
            SleepFor10Sec();
            SleepFor10Sec();
            OrderConfirmation.ContinueShopping();
            SleepFor10Sec();
            main.ClickOnOrders();
            SleepFor10Sec();
        }

        public static void VerifyOrderHistory(JToken productDetails)
        {
            OrderConfirmation.AssertOrderHistory(productDetails);
 
        }




    }
}
