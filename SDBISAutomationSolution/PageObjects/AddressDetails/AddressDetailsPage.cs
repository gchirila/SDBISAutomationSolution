using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDBISAutomationSolution.PageObjects.AddressDetails
{
    public class AddressDetailsPage
    {
        private IWebDriver driver;

        public AddressDetailsPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        private IWebElement LblNotice =>
            driver.FindElement(By.CssSelector("div[data-test=notice]"));


        public string NoticeText => LblNotice.Text;

    }
}
