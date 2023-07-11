using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class GooglePage : CommonPage
    {
        private IWebDriver driver;

        public GooglePage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
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
        public void GoToThePage()
        {
            var amazonLink = driver.FindElement(By.CssSelector("a[href*='amazon.de']"));
            amazonLink.Click();
        }        
    }
}
