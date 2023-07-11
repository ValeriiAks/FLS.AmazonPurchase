using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class GooglePage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;

        public GooglePage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait;
        }

        public void OpenGoogle(string url)
        {
            base.GoToUrl(url);
        }
        public void SearchPage(string searchQuery)
        {
            var searchBox = fluentWait.Until(x => x.FindElement(By.Name("q")));
            searchBox.SendKeys(searchQuery);
            searchBox.Submit();
        }
        public void GoToThePage()
        {
            var amazonLink = fluentWait.Until(x => x.FindElement(By.CssSelector("a[href*='amazon.de']")));
            amazonLink.Click();
        }        
    }
}
