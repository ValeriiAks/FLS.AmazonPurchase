using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FLS.AmazonPurchase.Pages
{
    public class CommonPage
    {
        private readonly IWebDriver driver;
        private readonly DefaultWait<IWebDriver> wait;

        public CommonPage(DefaultWait<IWebDriver> wait, IWebDriver driver)
        {
            this.wait = wait;
            this.driver = driver;
        }
        public string GetUrl()
        {
            return driver.Url;
        }
        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            WaitPageReady();
        }
        public void WaitPageReady()
        {
            wait.Until(d => ((IJavaScriptExecutor)d)
                .ExecuteScript("return document.readyState")
                .Equals("complete"));
        }
        public void PressEsc()
        {
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Escape);
        }
        public void Refresh()
        {
            driver.Navigate().Refresh();
            WaitPageReady();
        }
    }
}
