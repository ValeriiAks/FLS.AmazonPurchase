using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FLS.AmazonPurchase.Pages
{
    public class GooglePage : CommonPage
    {
        private readonly DefaultWait<IWebDriver> fluentWait;
        private IWebElement firstElemntFromSearching;
        private IWebElement SearchBox => fluentWait.Until(x => x.FindElement(
            By.XPath("//textarea[contains(@type, 'search')]")));

        private IReadOnlyCollection<IWebElement> SearchResults => fluentWait.Until(x => x.FindElements(
            By.XPath("//div[@id='search']//div/a")));



        public GooglePage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.fluentWait = fluentWait;
        }
        public void TextInput(string searchQuery)
        {
            SearchBox.SendKeys(searchQuery);
        }
        public void StartASearch()
        {
            SearchBox.Submit();
        }
        public void SelectFirstSearchElement()
        {
            firstElemntFromSearching = SearchResults.First();
        }
        public void ClickFirstSearchElement()
        {
            firstElemntFromSearching.Click();
        }
    }
}
