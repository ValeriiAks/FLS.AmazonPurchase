using FLS.AmazonPurchase.Pages;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration config;

        public AmazonStepDefiniitions(ScenarioContext scenarioContext, AmazonPage amazonPage, IConfiguration config)
        {
            this.scenarioContext = scenarioContext;
            this.amazonPage = amazonPage;
            this.config = config;
        }

        [Given("Amazon I check the site domain")]
        public void GivenCheckingTheSiteDomain()
        {
            var url = amazonPage.GetUrl();

            var correctUrl = config["AmazonUrl"];

            Assert.Equal(url, correctUrl);
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
            amazonPage.Refresh();
            var isCurrentLanguageEnglish = amazonPage.GetCurrentLanguage().Contains("EN");
            Assert.True(isCurrentLanguageEnglish, "The language of the site has not changed to English!");
        }

        [Given("Amazon I change delivery location")]
        public void GivenChangeDeliveryLocation()
        {
            amazonPage.ChangeLocation();
            //TODO assert check new location
        }

        [Given("Amazon I find some product")]
        public void GivenFindProduct()
        {
            var productName = config["ProductName"];
            amazonPage.FindProduct(productName);
            // Assert check result exist
        }

        [Given("Amazon I add the first product to cart")]
        public void GivenAddFirstProductToCart()
        {
            amazonPage.AddProductToCart();
            //TODO Add some information about product to scenario
        }
        [Given("Amazon I close popup")]
        public void ClosePopup()
        {
            amazonPage.Close();
            //TODO popup doesnt exist
        }

        [Given("Amazon I check the number of added products")]
        public void GivenCheckingTheNumberOfAddedProducts()
        {
            var countProduct = amazonPage.CountProductBeenAdded();
            Assert.Equal("1", countProduct);
        }
        //TODO add some check
    }
}
