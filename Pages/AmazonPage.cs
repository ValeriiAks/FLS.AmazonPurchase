using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLS.AmazonPurchase.Pages
{
    public class AmazonPage : CommonPage
    {
        private IWebDriver driver;

        public AmazonPage(IWebDriver driver, DefaultWait<IWebDriver> fluentWait) : base(fluentWait, driver)
        {
            this.driver = driver;
        }

        public void ChangeLocation()
        {
            var fluentWait = GetDefaultWait();
            // Найдите элемент, представляющий выбор локации
            var locationSelector = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"nav-global-location-data-modal-action\"]")));
            // Выполните клик на элементе выбора локации
            locationSelector.Click();
            ////*[@id="GLUXCountryListDropdown"]
            var dropdown = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"GLUXCountryListDropdown\"]")));
            dropdown.Click();

            // Найдите и выберите локацию "United States"
            ////*[@id="GLUXCountryList_227"]
            var unitedStatesOption = fluentWait.Until(x => x.FindElement(By.XPath("//*[@id=\"GLUXCountryList_227\"]")));
            unitedStatesOption.Click();

            // Сохраните изменения
            var saveChangesButton = fluentWait.Until(x => x.FindElement(By.Name("glowDoneButton")));
            saveChangesButton.Click();
        }
    }
}
