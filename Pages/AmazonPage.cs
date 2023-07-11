﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;

        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait; 
        }
        public string GetCurrentUrl()
        {
            var route = base.GetUrl();
            return route;
        }

        public void ChangeLanguage()
        {
            var languageDropdown = fluentWait.Until(x => x.FindElement(By.Id("icp-nav-flyout")));
            languageDropdown.Click();

            var englishLanguageOption = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i")));
            englishLanguageOption.Click();
            var saveChanges = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-save-button']/span/input")));

            //((IJavaScriptExecutor)fluentWait).ExecuteScript("arguments[0].click();", fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='icp-save-button']/span/input"))));

            IJavaScriptExecutor js = (IJavaScriptExecutor)fluentWait;
            js.ExecuteScript("arguments[0].click();", saveChanges);
        }

        public void AcceptCoockie()
        {
            var fluentWait = GetDefaultWait();

            var accept = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"sp-cc-accept\"]")));
            accept.Click();
        }

        public void FindProduct(string productName)
        {
            var searchInput = fluentWait.Until(x => x.FindElement(By.Id("twotabsearchtextbox")));
            searchInput.SendKeys(productName);
            searchInput.Submit();
        }

        public void AddProductToCart()
        {
            var firstProduct = fluentWait.Until(x => x.FindElement(By.CssSelector(".sg-col-inner h2 a")));
            firstProduct.Click();
             
            //TODO проверка на наличие на складе 

            var addToCartButton = fluentWait.Until(x=>x.FindElement(By.Id("add-to-cart-button")));
            addToCartButton.Click();
        }
        public string CountProductBeenAdded()
        {
            var cartCount = fluentWait.Until(x=>x.FindElement(By.Id("nav-cart-count")).Text);
            return cartCount;
        }

        public void ChangeLocation()
        {
            var fluentWait = GetDefaultWait();

            var locationSelector = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"nav-global-location-data-modal-action\"]")));
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
            var fluent = GetDefaultWait();

            var closeButton = fluent.Until(x => x.FindElement(By.XPath("//*[@id=\"attach - sidesheet - view - cart - button\"]/span/input")));
            closeButton.Click();
        }
    }
}
