using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SDBISAutomationSolution.PageObjects.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SDBISAutomationSolution.Shared.MenuItemControl;

namespace SDBISAutomationSolution
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

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
            
            loginPage = menuItemControl.NavigateToLoginPage();
        }

        [TestMethod]
        public void UserShouldLoginSuccessfully()
        {
            loginPage.LoginApplication("test@test.test", "test");
            //assert logged in email
            Assert.IsTrue(driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text.Equals("test@test.test"));
        }

        [TestMethod]
        public void UserShouldFailLoginWithWrongEmail()
        {
            loginPage.LoginApplication("wrongEmail@test.test", "test");
            //assert logged in email
            Assert.IsTrue(loginPage.ErrorMessage.Equals("Bad email or password."));
        }

        [TestMethod]
        public void UserShouldFailLoginWithWrongPassword()
        {
            loginPage.LoginApplication("test@test.test", "wrongPassword");
            //assert logged in email
            Assert.IsTrue(loginPage.ErrorMessage.Equals("Bad email or password."));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
