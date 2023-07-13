using FLS.AmazonPurchase.Pages;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using Xunit;

namespace FLS.AmazonPurchase.Steps
{
    [Binding]
    public class GoogleStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly GooglePage googlePage;
        private IConfiguration config;

        public GoogleStepDefinitions(ScenarioContext scenarioContext, GooglePage googlePage, IConfiguration config)
        {
            this.scenarioContext = scenarioContext;
            this.googlePage = googlePage;
            this.config = config;
        }

        [Given("Google I open the google page")]
        public void GivenTheGooglePage()
        {
            var googleUrl = config["GoogleUrl"];
            googlePage.GoToUrl(googleUrl);
            var currentUrl = googlePage.GetUrl();
            Assert.True(currentUrl.Contains(googleUrl), "The current page is not google");
        }

        [Given("Google I search (.*)")]
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
