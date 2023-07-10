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
    }
}
