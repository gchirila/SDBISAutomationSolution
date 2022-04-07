using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.AddAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBISAutomationSolution.PageObjects.AddressesOverview
{
    public class AddressesOverviewPage
    {
        private IWebDriver driver;

        public AddressesOverviewPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement BtnNewAddress =>
            driver.FindElement(By.XPath("//a[@data-test='create']"));

        public AddAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddAddressPage(driver);
        }
    }
}
