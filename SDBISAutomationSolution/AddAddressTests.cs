using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SDBISAutomationSolution.PageObjects.AddAddress;
using SDBISAutomationSolution.PageObjects.Home;
using SDBISAutomationSolution.PageObjects.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDBISAutomationSolution
{
    [TestClass]
    public class AddAddressTests
    {
        private IWebDriver driver;
        private AddAddressPage addAddressPage;

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
            loginPage.LoginApplication("test@test.test", "test");
            var homePage = new HomePage(driver);
            var addressesOverviewPage = homePage.NavigateToAddressesPage();
            Thread.Sleep(2000);
            addAddressPage = addressesOverviewPage.NavigateToAddAddressPage();
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void ShouldAddAddressSuccessfully()
        {

            addAddressPage.CreateAddress("SDBIS name", "SDBIS lastname", "SDBIS address1", "SDBIS city", "SDBIS zipcode");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
