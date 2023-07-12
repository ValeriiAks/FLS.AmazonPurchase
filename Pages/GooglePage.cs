using Microsoft.Extensions.Configuration;
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
        private IWebElement SearchBox => fluentWait.Until(x => x.FindElement(By.Name("q")));
        private IWebElement FirstLink => fluentWait.Until(x => x.FindElement(By.CssSelector("a[href*='amazon.de']")));

        public GooglePage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait;
        }
        public void SearchPage(string searchQuery)
        {
            SearchBox.SendKeys(searchQuery);
            SearchBox.Submit();
        }
        public void GoToThePage()
        {
            FirstLink.Click();
            WaitPageReady();
        }
    }
}
