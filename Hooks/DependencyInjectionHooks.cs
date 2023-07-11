using BoDi;
using FLS.AmazonPurchase.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace FLS.AmazonPurchase.Hooks
{
    [Binding]
    public class DependencyInjectionHooks
    {
        private readonly IObjectContainer container;

        public DependencyInjectionHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void DependencyRegister()
        {
            ChromeDriver driver = new ChromeDriver();
            container.RegisterInstanceAs<IWebDriver>(driver);
            container.RegisterTypeAs<GooglePage, GooglePage>();
            container.RegisterTypeAs<AmazonPage, AmazonPage>();
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            var driver = container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
