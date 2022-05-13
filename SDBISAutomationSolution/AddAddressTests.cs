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
            var btnSignIn = driver.FindElement(By.Id("sign-in"));
            btnSignIn.Click();
            Thread.Sleep(2000);
            var loginPage = new LoginPage(driver);
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            addressesOverviewPage = homePage.menuItemControlLoggedIn.NavigateToAddressesPage();
            Thread.Sleep(2000);
            
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
            Thread.Sleep(2000);
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
            Thread.Sleep(4000);
            var addressDetailsPage = addAddressPage.CreateEditAddress(inputData);
            Thread.Sleep(2000);
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
