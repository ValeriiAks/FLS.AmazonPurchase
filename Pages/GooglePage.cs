using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class GooglePage
    {
        private IWebDriver driver;

        public GooglePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
        }
        public void SearchPage(string searchQuery)
        {
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchQuery);
            searchBox.Submit();
        }
    }
}
