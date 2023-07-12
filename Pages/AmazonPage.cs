using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;
        private readonly IConfiguration config;

        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait; 
        }
        public string GetCurrentUrl()
        {
            var route = config["AmazonPage"];
            return route;
        }

        public void ChangeLanguage()
        {
            var languageDropdown = fluentWait.Until(x => x.FindElement(By.Id("icp-nav-flyout")));
            languageDropdown.Click();

            var englishLanguageOption = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i")));
            englishLanguageOption.Click();

            var saveChanges = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-save-button']/span/input")));
            base.ClickFromJs(saveChanges);

            var searchInput = fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
            fluentWait.Until(ExpectedConditions.StalenessOf(searchInput));
        }

        public void AcceptCoockie()
        {
            var accept = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sp-cc-accept\"]")));
            accept.Click();
        }

        public void FindProduct()
        {            
            var searchInput = fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
            searchInput.Click();
            searchInput.SendKeys(config["ProductName"]);
            searchInput.Submit();

            var firstProduct = fluentWait.Until(x => x.FindElement(By.CssSelector(".sg-col-inner h2 a")));
            firstProduct.Click();
        }

        public void AddProductToCart()
        {
            var addToCartButton = fluentWait.Until(x=>x.FindElement(By.Id("add-to-cart-button")));
            addToCartButton.Click();
        }
        public string CountProductBeenAdded()
        {
            var cartCount = fluentWait.Until(x => x.FindElement(By.Id("nav-cart-count")).Text);
            return cartCount;
        }

        public void ChangeLocation()
        {
            var locationSelector = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"contextualIngressPtLabel_deliveryShortLine\"]")));
            locationSelector.Click();

            var dropdown = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"GLUXCountryListDropdown\"]")));
            dropdown.Click();

            var unitedStatesOption = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"GLUXCountryList_227\"]")));
            unitedStatesOption.Click();

            var saveChangesButton = fluentWait.Until(x => x.FindElement(By.Name("glowDoneButton")));
            saveChangesButton.Click();
        }
        public void Close()
        {
            base.PressEsc();
        }
    }
}
