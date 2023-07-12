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

        [Given("Amazon I accept cookie")]
        public void AcceptCookie()
        {
            amazonPage.AcceptCookie();
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
            amazonPage.ChangeLocationToUS();
            amazonPage.Refresh();
            var currentLocation = amazonPage.GetCurrentLocation();
            var isUnitedStates = currentLocation.Contains("United States");
            Assert.True(isUnitedStates, "The location of the site has not changed to United States");
        }

        [Given("Amazon I find some product")]
        
        public void GivenFindProduct()
        {
            var productName = config["ProductName"];
            amazonPage.FindProduct(productName);
            var firstProductExist = amazonPage.FirstProductExist();
            Assert.True(firstProductExist, "The result doesnt have any results");
        }

        [Given("Amazon I go to the first product page")]
        public void GivenGoToTheFirstProduct()
        {
            amazonPage.GoToFirstProduct();
        }

        [Given("Amazon I check current product ready to order")]
        public void GivenCheckProductReadyToOrder()
        {
            var isOrderable = amazonPage.IsOrderableCurrentProduct();
            Assert.True(isOrderable, "Product cannot be ordered");
        }

        [Given("Amazon I add the first product to basket")]
        public void GivenAddFirstProductToBasket()
        {
            amazonPage.AddProductToBasket();
            scenarioContext["LastProductPrice"] = amazonPage.GetProductPrice();
            scenarioContext["LastProductId"] = amazonPage.GetProductId();
            amazonPage.WaitPageReady();
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
            var price = scenarioContext["LastProductPrice"] as string;
            var id = scenarioContext["LastProductId"] as string;
            var product = amazonPage.CountProductBeenAdded();
            Assert.Equal(product.Id, id);
            Assert.Equal(product.Price, price);

        }

        [Given("Amazon i go to the shopping basket")]
        public void GoToShoppingBasket()
        {
            amazonPage.GoToShoppingBasket();
        }
    }
}
