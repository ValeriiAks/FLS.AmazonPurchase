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

        private IWebElement LanguageDropdown => fluentWait.Until(x => x.FindElement(By.Id("icp-nav-flyout")));
        private IWebElement EnglishLanguageOption => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i")));
        private IWebElement SaveLanguageChanges => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-save-button']/span/input")));
        private IWebElement SearchInput => fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
        private IWebElement CurrentLanguage => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-nav-flyout']//span/div")));
        private IWebElement CookieAccept => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sp-cc-accept\"]")));
        private IWebElement FirstProduct => fluentWait.Until(x => x.FindElement(By.CssSelector(".sg-col-inner h2 a")));
        private IWebElement AddToBasketButton => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"add-to-cart\"]/span")));
        private IWebElement BasketCount => fluentWait.Until(x => x.FindElement(By.Id("nav-cart-count")));
        private IWebElement LocationSelector => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"contextualIngressPtLabel_deliveryShortLine\"]")));
        private IWebElement CountryDropdown => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"GLUXCountryListDropdown\"]")));
        private IWebElement UnitedStatesOption => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"GLUXCountryList_227\"]")));
        private IWebElement SaveLocationChangeButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.Name("glowDoneButton")));
        private IReadOnlyCollection<IWebElement> AddToCartButtons => fluentWait.Until(x => x.FindElements(By.XPath("//input[@id='add-to-cart-button']")));
        private IWebElement ProductPrice => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"apex_offerDisplay_desktop\"]")));
        private IWebElement ProductId => fluentWait.Until(x => x.FindElement(By.XPath("//input[@id='ASIN']")));
        private IWebElement ShoppingBasketButton => fluentWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"nav-cart\"]")));



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
            FirstProduct.Click();
        }

        public void AddProductToBasket()
        {            
            AddToBasketButton.Click();
        }

        public string CountProductBeenAdded()
        {            
            return BasketCount.Text;
        }

        public void ChangeLocation()
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
    }
}
