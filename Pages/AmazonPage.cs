using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage
    {
        private IWebDriver driver;

        public AmazonPage(IWebDriver driver)
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
            var languageDropdown = driver.FindElement(By.Id("icp-nav-flyout"));
            languageDropdown.Click();
            var englishLanguageOption = driver.FindElement(By.XPath("//*[@id=\"icp - language - settings\"]/div[3]/div/label/i"));
            englishLanguageOption.Click();
            var savechanges = driver.FindElement(By.Id("icp-save-button"));
            savechanges.Click();
        }
        public void AddProductToCart()
        {
            var searchInput = driver.FindElement(By.Id("twotabsearchtextbox"));
            searchInput.SendKeys("waschies");
            searchInput.Submit();

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
    }
}
