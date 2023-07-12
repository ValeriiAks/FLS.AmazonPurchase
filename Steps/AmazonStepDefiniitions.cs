using FLS.AmazonPurchase.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace FLS.AmazonPurchase.Steps
{
    [Binding]
    public class AmazonStepDefiniitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly AmazonPage amazonPage;

        public AmazonStepDefiniitions(ScenarioContext scenarioContext, AmazonPage amazonPage)
        {
            this.scenarioContext = scenarioContext;
            this.amazonPage = amazonPage;
        }

        [Given("Amazon I check the site domain")]
        public void GivenCheckingTheSiteDomain()
        {
            var route = amazonPage.GetCurrentUrl();

            var correctRoute = "https://www.amazon.de/";

            Assert.Equal(route, correctRoute);
        }

        [Given("Amazon I accept ckookie")]
        public void AcceptCkookie()
        {
            amazonPage.AcceptCoockie();
        }

        [Given("Amazon I change the language to English")]
        public void GivenChangeTheLanguageToEnglish()
        {
            amazonPage.ChangeLanguage();
        }

        [Given("Amazon I change delivery location")]
        public void GivenChangeDeliveryLocation()
        {
            amazonPage.ChangeLocation();
        }

        [Given("Amazon I find product")]
        public void GivenFindProduct()
        {
            amazonPage.FindProduct();
        }

        [Given("Amazon I add the first product to cart")]
        public void GivenAddFirstProductToCart()
        {
            amazonPage.AddProductToCart();
        }
        [Given("Amazon I close popup")]
        public void ClosePopup()
        {
            amazonPage.Close();
        }

        [Given("Amazon I check the number of added products")]
        public void GivenCheckingTheNumberOfAddedProducts()
        {
            var countProduct = amazonPage.CountProductBeenAdded();
            Assert.Equal("1", countProduct);
        }
    }
}
