using FLS.AmazonPurchase.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FLS.AmazonPurchase.Steps
{
    [Binding]
    public class GoogleStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly GooglePage googlePage;

        public GoogleStepDefinitions(ScenarioContext scenarioContext, GooglePage googlePage)
        {
            this.scenarioContext = scenarioContext;
            this.googlePage = googlePage;
        }

        [Given("Google I open the google page")]
        public void GivenTheGooglePage()
        {
            googlePage.OpenGoogle();
        }

        [Given("Google I search")]
        public void GivenISearch(string searchQuery)
        {
            googlePage.SearchPage(searchQuery);
        }

        [Given("Google i open the page from search")]
        public void GivenGoToThePage()
        {
            googlePage.GoToThePage();
        }
    }
}
