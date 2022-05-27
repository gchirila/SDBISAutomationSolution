using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SDBISAutomationSolution.PageObjects.AddAddress;
using SDBISAutomationSolution.PageObjects.AddAddress.InputData;
using SDBISAutomationSolution.PageObjects.Home;
using SDBISAutomationSolution.PageObjects.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SDBISAutomationSolution.PageObjects.AddressesOverview;
using SDBISAutomationSolution.Shared.MenuItemControl;

namespace SDBISAutomationSolution
{
    [TestClass]
    public class AddAddressTests
    {
        private IWebDriver driver;
        private AddEditAddressPage addAddressPage;
        private AddressesOverviewPage addressesOverviewPage;

        [TestInitialize]
        public void TestInitialize()
        {
            //open browser
            driver = new ChromeDriver();
            //maximize window
            driver.Manage().Window.Maximize();
            //navigate to app URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //click sign in button
            var menuItemControl = new MenuItemControlLoggedOut(driver);
            var loginPage = menuItemControl.NavigateToLoginPage();
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            addressesOverviewPage = homePage.menuItemControlLoggedIn.NavigateToAddressesPage();
        }

        [TestMethod]
        public void ShouldAddAddressSuccessfully()
        {
            var inputData = new AddAddressBO
            {
                //FirstName = "SDBIS name",
                LastName = "SDBIS lastname",
                Address1 = "SDBIS address1",
                City = "SDBIS city",
                State = "California",
                ZipCode = "SDBIS zipcode",
                Country = "Canada",
                Color = "#FF0000"
            };
            addAddressPage = addressesOverviewPage.NavigateToAddAddressPage();
            var addressDetailsPage = addAddressPage.CreateEditAddress(inputData);
            Assert.AreEqual("Address was successfully created.", addressDetailsPage.NoticeText);
        }

        [TestMethod]
        public void ShouldEditAddressSuccessfully()
        {
            var inputData = new AddAddressBO
            {
                FirstName = "Pretty please don't edit/delete",
                LastName = "SDBIS lastname",
                Address1 = "SDBIS address1",
                City = "SDBIS city",
                State = "California",
                ZipCode = "SDBIS zipcode",
                Country = "Canada",
                Color = "#FF0000"
            };
            addAddressPage = addressesOverviewPage.NavigateToEditAddressPage(inputData.FirstName);
            var addressDetailsPage = addAddressPage.CreateEditAddress(inputData);
            Assert.AreEqual("Address was successfully updated.", addressDetailsPage.NoticeText);
        }

        [TestMethod]
        public void ShouldDemoAlert()
        {
            var inputData = new AddAddressBO
            {
                FirstName = "Pretty please don't edit/delete"
            };
            addressesOverviewPage.DeleteAddress(inputData.FirstName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
