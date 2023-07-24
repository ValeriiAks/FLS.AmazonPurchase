using FLS.AmazonPurchase.Pages;
using Microsoft.Extensions.Configuration;
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

        [Given("I check the site domain")]
        public void GivenCheckingTheSiteDomain()
        {
            var url = amazonPage.GetUrl();
            var correctUrl = config["AmazonUrl"];
            Assert.Equal(url, correctUrl);
        }

        [Given("I accept cookie")]
        public void GivenAcceptCookie()
        {
            amazonPage.AcceptCookie();
        }

        [Given("I click on laguage dropdown")]
        public void GivenIClickOnLanguageDropdown()
        {
            amazonPage.ClickLanguageDropdown();
        }

        [Given("I select english language")]
        public void GivenISelectEnglishLanguage()
        {
            amazonPage.SelectEnglishLanguage();
        }

        [Given("I save language chnges")]
        public void GivenIClickSaveLanguageButton()
        {
            amazonPage.ClickSaveLanguageButton();
        }

        [Given("I click on search input")]
        public void GivenClickOnSearchInput()
        {
            amazonPage.ClickOnSearchInput();
        }

        [Given("I type in the search bar")]
        public void GivenTextInput()
        {
            amazonPage.TextInput(config["ProductName"]);
        }

        [Given("I start a search product")]
        public void GivenStartASearch()
        {
            amazonPage.StartASearch();
            var firstProductExist = amazonPage.ProductsInSearchExist();
            Assert.True(firstProductExist, "The result doesnt have any results");
        }

        [Given("I go to the first product page")]
        public void GivenGoToTheFirstProduct()
        {
            amazonPage.OpenFirstProduct();
        }

        [Given("I click on location selector")]
        public void GivenClickOnLocationSelector()
        {
            amazonPage.ClickOnLocationSelector();
        }

        [Given("I click on country dropdown")]
        public void GivenClickOnCountryDropdown()
        {
            amazonPage.ClickOnCountryDropdown();
        }

        [Given("I select united states option")]
        public void GivenSelectUnitedStatesOption()
        {
            amazonPage.SelectUnitedStatesOption();
        }

        [Given("I click save location button")]
        public void GivenClickSaveLocationButton()
        {
            amazonPage.ClickSaveLocationButton();
        }

        [Given("I check current product ready to order")]
        public void GivenCheckProductReadyToOrder()
        {
            var isOrderable = amazonPage.IsOrderableCurrentProduct();
            Assert.True(isOrderable, "Product cannot be ordered");
        }

        [Given("I add the first product to basket")]
        public void GivenAddFirstProductToBasket()
        {
            amazonPage.AddProductToBasket();
            scenarioContext["LastProductPrice"] = amazonPage.GetProductPrice();
            scenarioContext["LastProductId"] = amazonPage.GetProductId();
            amazonPage.WaitPageReady();
        }

        [Given("I close popup")]
        public void ClosePopup()
        {
            amazonPage.Close();
        }

        [Given("I check the correctness of the added product")]
        public void GivenCheckingTheNumberOfAddedProducts()
        {
            var price = scenarioContext["LastProductPrice"] as string;
            var id = scenarioContext["LastProductId"] as string;
            var product = amazonPage.GetProductFromBasket();
            Assert.Contains(id, product.Href);
            Assert.NotNull(price);
            Assert.Contains(price, product.Price);

        }

        [Given("I go to the shopping basket")]
        public void GoToShoppingBasket()
        {
            amazonPage.GoToShoppingBasket();
        }
    }
}
