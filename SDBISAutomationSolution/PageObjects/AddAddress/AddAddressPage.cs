using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBISAutomationSolution.PageObjects.AddAddress
{
    public class AddAddressPage
    {
        private IWebDriver driver;

        public AddAddressPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement TxtFirstName =>
            driver.FindElement(By.Id("address_first_name"));

        private IWebElement TxtLastName =>
            driver.FindElement(By.Id("address_last_name"));

        private IWebElement TxtAddress1 =>
            driver.FindElement(By.Id("address_street_address"));

        private IWebElement TxtCity =>
            driver.FindElement(By.Id("address_city"));

        private IWebElement TxtZipCode =>
            driver.FindElement(By.Id("address_zip_code"));

        private IWebElement BtnCreateAddress =>
            driver.FindElement(By.CssSelector("input[name=commit]"));

        public void CreateAddress(string firstName, string lastName, string address1, string city, string zipcode)
        {
            TxtFirstName.SendKeys(firstName);
            TxtLastName.SendKeys(lastName);
            TxtAddress1.SendKeys(address1);
            TxtCity.SendKeys(city);
            TxtZipCode.SendKeys(zipcode);
            BtnCreateAddress.Click();
        }
    }
}
