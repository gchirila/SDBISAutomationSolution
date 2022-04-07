using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.AddressesOverview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBISAutomationSolution.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement BtnAddresses => 
            driver.FindElement(By.CssSelector("a[data-test=addresses]"));

        public AddressesOverviewPage NavigateToAddressesPage()
        {
            BtnAddresses.Click();
            return new AddressesOverviewPage(driver);
        }
    }
}
