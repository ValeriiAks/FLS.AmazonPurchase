using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class GooglePage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;
        private IWebElement SearchBox => fluentWait.Until(x => x.FindElement(By.XPath("//*[@id='APjFqb']")));
        private IReadOnlyCollection<IWebElement> SearchResults => fluentWait.Until(x => x.FindElements(By.XPath("//div[contains(@class, 'yuRUbf')]/a")));


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
            var firstResult = SearchResults.First();
            firstResult.Click();
            WaitPageReady();
        }
    }
}
