﻿using FLS.AmazonPurchase.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace FLS.AmazonPurchase.Steps
{
    [Binding]
    public sealed class AmazonPurchaseStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly GooglePage googlePage;
        private readonly AmazonPage amazonPage;

        public AmazonPurchaseStepDefinitions(ScenarioContext scenarioContext, GooglePage googlePage, AmazonPage amazonPage)
        {
            this.scenarioContext = scenarioContext;
            this.googlePage = googlePage;
            this.amazonPage = amazonPage;
        }

        [Given("the google page")]
        public void GivenTheGooglePage()
        {
            googlePage.OpenGoogle();
        }

        [Given("i search (.*)")]
        public void GivenISearch(string searchQuery)
        {
            googlePage.SearchPage(searchQuery);
        }

        [Given("go to the page")]
        public void GivenGoToThePage()
        {
            googlePage.GoToThePage();
        }

        [Given("checking the site domain")]
        public void GivenCheckingTheSiteDomain()
        {
            var route = amazonPage.GetCurrentUrl();

            var correctRoute = "https://www.amazon.de/";

            Assert.Equal(route, correctRoute);
        }

        [Given("accept ckookie")]
        public void AcceptCkookie()
        {
            amazonPage.AcceptCoockie();
        }

        [Given("change the language to English")]
        public void GivenChangeTheLanguageToEnglish()
        {
            amazonPage.ChangeLanguage();
        }

        [Given("chnge delivery location")]
        public void GivenChangeDeliveryLocation()
        {
            amazonPage.ChangeLocation();
        }

        [Given("find product (.*)")]
        public void GivenFindProduct(string productName)
        {
            amazonPage.FindProduct(productName);
        }

        [Given("add first product to cart")]
        public void GivenAddFirstProductToCart()
        {
            amazonPage.AddProductToCart();
        }
        [Given("close popup")]
        public void ClosePopup()
        {
            amazonPage.Close();
        }

        [Given("checking the number of added products")]
        public void GivenCheckingTheNumberOfAddedProducts()
        {
            var countProduct = amazonPage.CountProductBeenAdded();
            Assert.Equal("1", countProduct);
        }

    }
}
