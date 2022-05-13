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

        private IList<IWebElement> LstAddresses =>
            driver.FindElements(By.CssSelector("tbody tr"));

        private IWebElement BtnNewAddress =>
            driver.FindElement(By.XPath("//a[@data-test='create']"));

        private IWebElement BtnEdit(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-test*=edit]"));

        private IWebElement BtnDelete(string addressName) =>
            LstAddresses.FirstOrDefault(element => element.Text.Contains(addressName))
                .FindElement(By.CssSelector("a[data-method=delete]"));

        public void DeleteAddress(string addressName)
        {
            BtnDelete(addressName).Click();
            driver.SwitchTo().Alert().Dismiss();
        }

        public AddEditAddressPage NavigateToEditAddressPage(string addressName)
        {
            BtnEdit(addressName).Click();
            return new AddEditAddressPage(driver);
        }


        public AddEditAddressPage NavigateToAddAddressPage()
        {
            BtnNewAddress.Click();
            return new AddEditAddressPage(driver);
        }
    }
}
