using BoDi;
using FLS.AmazonPurchase.Models.Settings;
using FLS.AmazonPurchase.Pages;
using Microsoft.Extensions.Configuration;
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
        private static IConfiguration config;

        public DependencyInjectionHooks(IObjectContainer container)
        {
            this.container = container;
        }

        private void CreateConfig()
        {
            if (config == null)
            {
                config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            }
            container.RegisterInstanceAs<IConfiguration>(config);
        }

        [BeforeScenario]
        public void DependencyRegister()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            CreateConfig();
            var webDriverWaitSettings = config.GetSection("WebDriverWait").Get<WebDriverWaitSettings>();
            container.RegisterInstanceAs<IWebDriver>(driver);
            WebDriverWait fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(webDriverWaitSettings.Timeout));
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(webDriverWaitSettings.PollingInterval);
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
