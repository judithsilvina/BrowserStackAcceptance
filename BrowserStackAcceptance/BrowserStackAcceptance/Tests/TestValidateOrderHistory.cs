using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserStackAcceptance.Helpers;
using BrowserStackAcceptance.PageObjects;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using StoryQ;

namespace BrowserStackAcceptance.Tests
{ internal class TestValidateOrderHistory : BasePage
        {
            [Test]
            public void TestValidateOrderSummary()
            {
                JToken productDetails = ValidateOrderHistory.GetProductDetails();
                new Story("Verify Order details in Order Summary page")
                    .InOrderTo("Verify Order detail")
                    .AsA("User")
                    .IWant("To login, add items to the cart, checkout the order")
                    .WithScenario("Order details are same in Order history page")
                    .Given(OpenURL)
                    .And(ValidateOrderHistory.signIn)
                    .When(ValidateOrderHistory.AddToCart)
                    .Then(ValidateOrderHistory.ValidateOrderDetailsinSummarypage, productDetails)
                    .And(ValidateOrderHistory.SubmitShippingAddressAndContinueSopping)
                    .And(ValidateOrderHistory.VerifyOrderHistory, productDetails)
                    .And(MainPage.CloseTheBrowser)
                    .Execute();
            }
        }
}


