using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private IWebDriver driver;

        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.driver = driver;
        }
        public string GetCurrentUrl()
        {
            var route = driver.Url;
            return route;
        }

        public void ChangeLanguage()
        {
            var fluentWait = GetDefaultWait();

            var languageDropdown = driver.FindElement(By.Id("icp-nav-flyout"));
            languageDropdown.Click();

            var englishLanguageOption = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"icp-language-settings\"]/div[3]/div/label/i")));
            englishLanguageOption.Click();
            var saveChanges = driver.FindElement(By.XPath("//*[@id='icp-save-button']/span/input"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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
            var searchInput = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchInput.SendKeys(productName);
            searchInput.Submit();
        }

        public void AddProductToCart()
        {
            var firstProduct = driver.FindElement(By.CssSelector(".sg-col-inner h2 a"));
            firstProduct.Click();
             
            //TODO проверка на наличие на складе 

            var addToCartButton = driver.FindElement(By.Id("add-to-cart-button"));
            addToCartButton.Click();
        }
        public string CountProductBeenAdded()
        {
            var cartCount = driver.FindElement(By.Id("nav-cart-count")).Text;
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
