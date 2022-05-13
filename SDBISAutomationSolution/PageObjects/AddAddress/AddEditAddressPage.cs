using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SDBISAutomationSolution.PageObjects.AddAddress.InputData;
using SDBISAutomationSolution.PageObjects.AddressDetails;
using System.Collections.Generic;
using System.Linq;

namespace SDBISAutomationSolution.PageObjects.AddAddress
{
    public class AddEditAddressPage
    {
        private IWebDriver driver;

        public AddEditAddressPage(IWebDriver _driver)
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

        private IWebElement DdlStates =>
            driver.FindElement(By.Id("address_state"));

        private IWebElement TxtZipCode =>
            driver.FindElement(By.Id("address_zip_code"));

        private IList<IWebElement> LstCountries =>
            driver.FindElements(By.CssSelector("label[for^=address_country]"));

        private IWebElement TxtColor =>
            driver.FindElement(By.Id("address_color"));

        private IWebElement BtnCreateAddress =>
            driver.FindElement(By.CssSelector("input[name=commit]"));

        public AddressDetailsPage CreateEditAddress(AddAddressBO inputData)
        {
            TxtFirstName.Clear();
            TxtFirstName.SendKeys(inputData.FirstName);
            TxtLastName.Clear();
            TxtLastName.SendKeys(inputData.LastName);
            TxtAddress1.SendKeys(inputData.Address1);
            TxtCity.SendKeys(inputData.City);

            var state = new SelectElement(DdlStates);
            state.SelectByText(inputData.State);

            TxtZipCode.SendKeys(inputData.ZipCode);

            LstCountries[0].Click();

            LstCountries.FirstOrDefault(element => element.Text.Contains(inputData.Country)).Click();

            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", TxtColor, inputData.Color);

            BtnCreateAddress.Click();
            return new AddressDetailsPage(driver);
        }
    }
}
