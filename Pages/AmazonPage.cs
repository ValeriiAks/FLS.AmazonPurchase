using FLS.AmazonPurchase.Models;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;

        private IWebElement LanguageDropdown => fluentWait.Until(x => x.FindElement(By.Id("icp-nav-flyout")));
        private IWebElement EnglishLanguageOption => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i")));
        private IWebElement SaveLanguageChanges => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-save-button']/span/input")));
        private IWebElement SearchInput => fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
        private IWebElement CurrentLanguage => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-nav-flyout']//span/div")));
        private IWebElement CookieAccept => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sp-cc-accept\"]")));
        //private IWebElement FirstProduct => fluentWait.Until(x => x.FindElement(By.CssSelector(".sg-col-inner h2 a")));
        private IWebElement AddToBasketButton => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"add-to-cart-button\"]")));
        private IWebElement LocationSelector => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"contextualIngressPtLabel_deliveryShortLine\"]")));
        private IWebElement CountryDropdown => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"GLUXCountryListDropdown\"]")));
        private IWebElement UnitedStatesOption => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"GLUXCountryList_227\"]")));
        private IWebElement SaveLocationChangeButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.Name("glowDoneButton")));
        private IReadOnlyCollection<IWebElement> AddToCartButtons => fluentWait.Until(x => x.FindElements(By.XPath("//input[@id='add-to-cart-button']")));
        private IWebElement ProductPrice => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"apex_offerDisplay_desktop\"]")));
        private IWebElement ProductId => fluentWait.Until(x => x.FindElement(By.XPath("//input[@id='ASIN']")));
        //private IWebElement ShoppingBasketButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"nav-cart\"]")));
        private IWebElement ShoppingBasketButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"attach-sidesheet-view-cart-button\"]/span/input")));

        private IWebElement CurrentLocation => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"glow-ingress-line2\"]")));
        private IReadOnlyCollection<IWebElement> FirstProduct => fluentWait
                .Until(x => x.FindElements(
                    By.XPath("//*[@id=\"search\"]/div[1]/div[1]/div/span[1]/div[1]/div[4]/div/div/div/div/div/div/div/div[2]/div/div/div[1]/h2/a")));



        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait;
        }

        public bool IsOrderableCurrentProduct()
        {
            try
            {
                return AddToCartButtons.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ChangeLanguage()
        {
            LanguageDropdown.Click();
            EnglishLanguageOption.Click();
            ClickFromJs(SaveLanguageChanges);           
        }
        public void AcceptCookie()
        {            
            CookieAccept.Click();
        }
        public void FindProduct(string productName)
        {
            SearchInput.Click();
            SearchInput.SendKeys(productName);
            SearchInput.Submit();
        }
        public bool FirstProductExist()
        {
            return FirstProduct.Count > 0;
        }
        public void GoToFirstProduct()
        {
            FirstProduct.First().Click();
        }
        public void AddProductToBasket()
        {            
            AddToBasketButton.Click();
        }
        public Product CountProductBeenAdded()
        {
            var price = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sc-subtotal-amount-activecart\"]/span")));
            var productInBasket = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sc-active-C0fdcfd7a-7e2a-446b-92ca-0154e8f11fd2\"]/div[4]")));
            var product = new Product()
            {
                Price = price.Text,
                Id = productInBasket.GetAttribute("value")
            };
            return product;
        }
        public void ChangeLocationToUS()
        {            
            LocationSelector.Click();
            CountryDropdown.Click();
            UnitedStatesOption.Click();
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
