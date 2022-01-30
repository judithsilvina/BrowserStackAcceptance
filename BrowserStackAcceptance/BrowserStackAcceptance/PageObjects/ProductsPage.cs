using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserStackAcceptance.Helpers;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BrowserStackAcceptance.PageObjects
{
    public class ProductsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]/div[4]")]
        public IWebElement BtnAddToCart;

        [FindsBy(How = How.ClassName, Using = "buy-btn")]
        public IWebElement BtnCheckout;

        public ProductsPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public JToken getProductsAsync(int id)
        {
            HttpContent responseContent;
            string responseString = null;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://bstackdemo.com/api/products?userName=demouser").Result;

                if (response.IsSuccessStatusCode)
                {
                    responseContent = response.Content;

                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }

            JToken JsonData = JToken.Parse(responseString);
            JToken iphoneData = JsonData.SelectToken("$..[?(@.id == 1)]");
            Console.WriteLine(iphoneData);
            return iphoneData;
        }
        public OrdersPage AddToCart()
        {
           // BrowserDemopage.Click();
            
            BtnAddToCart.Click();
            ValidateOrderHistory.SleepFor10Sec();
            BtnCheckout.Click();

            return new OrdersPage();
                    
        }

        
    }
}
