using FLS.AmazonPurchase.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

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

        [Given("I search (.*)")]
        public void GivenISearch(string name)
        {
            googlePage.SearchPage(name);
        }
    }
}
