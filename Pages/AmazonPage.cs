using FLS.AmazonPurchase.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;

        private IWebElement LanguageDropdown => fluentWait.Until(x => x.FindElement(By.Id("icp-nav-flyout")));
        ///html/body/div[1]/header/div //html/body/div/header/div/div[1]/div[3]
        private IWebElement EnglishLanguageOption => fluentWait.Until(x => x.FindElement(By.XPath("//input[@type='radio' and contains(@value, 'en_GB')]//following-sibling::i")));
        private IWebElement SaveLanguageChanges => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='icp-save-button']/span/input")));
        private IWebElement SearchInput => fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
        private IWebElement CurrentLanguage => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-nav-flyout']//span/div")));
        private IWebElement CookieAccept => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='sp-cc-accept']")));
        private IWebElement AddToBasketButton => fluentWait.Until(x => x.FindElement(By.XPath("//input[@id='add-to-cart-button' and contains(@value, 'Add to Basket')]")));
        private IWebElement LocationSelector => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='contextualIngressPtLabel_deliveryShortLine']")));
        private IWebElement CountryDropdown => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='GLUXCountryListDropdown']")));
        private IWebElement UnitedStatesOption => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='GLUXCountryList_227']")));
        private IWebElement SaveLocationChangeButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.Name("glowDoneButton")));
        private IReadOnlyCollection<IWebElement> AddToCartButtons => fluentWait.Until(x => x.FindElements(By.XPath("//input[@id='add-to-cart-button']")));
        private IWebElement ProductPrice => fluentWait.Until(x => x.FindElement(By.XPath("//span[@id='attach-accessory-cart-subtotal']")));
        private IWebElement ProductId => fluentWait.Until(x => x.FindElement(By.XPath("//input[@id='ASIN']")));
        private IWebElement ShoppingBasketButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='attach-sidesheet-view-cart-button']/span/input")));
        private IWebElement CurrentLocation => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='glow-ingress-line2']")));
        private IWebElement ProductPriceFromBasket => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='sc-subtotal-amount-activecart']/span")));
        private IWebElement ProductHrefFromBasket => fluentWait.Until(x => x.FindElement(By.XPath("//*[contains(@id,'sc-active')]//span[contains(@class,'a-list-item')]/a")));
        private IReadOnlyCollection<IWebElement> ProductsInFirstSearchPage => fluentWait
                .Until(x => x.FindElements(
                    By.XPath("//div[contains(@data-component-type, 's-search-result')]/div/div/div/div/div/div/div/div[2]/div/div/div/h2/a")));
        ////span[@data-component-type='s-search-results']//div[contains(@class, 's-title-instructions-style')]/h2/a
        // Почему этот XPath не работает ?  




        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait;
        }

        public bool IsOrderableCurrentProduct()
        {
            return AddToCartButtons.Count > 0;
        }
        public void ClickLanguageDropdown()
        {
            LanguageDropdown.Click();
        }
        public void SelectEnglishLanguage()
        {
            EnglishLanguageOption.Click();
        }
        public void ClickSaveLanguageButton()
        {
            SaveLanguageChanges.Click();
        }
        public void AcceptCookie()
        {
            CookieAccept.Click();
        }
        public void ClickOnSearchInput()
        {
            SearchInput.Click();
        }
        public void TextInput(string productName)
        {
            SearchInput.SendKeys(productName);
        }
        public void StartASearch()
        {
            SearchInput.Submit();
        }
        public void OpenFirstProduct()
        {
            ProductsInFirstSearchPage.First().Click();
        }
        public bool ProductsInSearchExist()
        {
            return ProductsInFirstSearchPage.Count > 0;
        }        
        public void AddProductToBasket()
        {            
            AddToBasketButton.Click();
        }
        public Product GetProductFromBasket()
        {
            var product = new Product()
            {
                Price = ProductPriceFromBasket.Text,
                Href = ProductHrefFromBasket.GetAttribute("href")
            };
            return product;
        }
        public void ClickOnLocationSelector()
        {
            LocationSelector.Click();
        }
        public void ClickOnCountryDropdown()
        {
            CountryDropdown.Click();
        }
        public void SelectUnitedStatesOption()
        {
            UnitedStatesOption.Click();
        }
        public void ClickSaveLocationButton()
        {
            SaveLocationChangeButton.Click();
        }
        public void Close()
        {
            PressEsc();
        }
        public string GetCurrentLanguage()
        {
            return CurrentLanguage.Text;
        }
        public string GetProductPrice()
        {
            return ProductPrice.Text;
        }
        public string GetProductId()
        {
            return ProductId.GetAttribute("value");
        }
        public void GoToShoppingBasket()
        {
            ShoppingBasketButton.Click();
            WaitPageReady();
        }
        public string GetCurrentLocation()
        {
            return CurrentLocation.Text;
        }
    }
}
