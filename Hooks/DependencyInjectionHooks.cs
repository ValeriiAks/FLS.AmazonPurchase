﻿using BoDi;
using FLS.AmazonPurchase.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
            WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            container.RegisterInstanceAs<DefaultWait<IWebDriver>>(fluentWait);
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
