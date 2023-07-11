using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        public void ClickFromJs(IWebElement button)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", button);
        }
        public void PressEsc()
        {
            Actions action = new Actions(driver);
            action.SendKeys(OpenQA.Selenium.Keys.Escape);
        }
    }
}
