using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SDBISAutomationSolution.PageObjects.Login;
using System;
using System.Threading;

namespace SDBISAutomationSolution
{
    [TestClass]
    public class UnitTest1
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
            var btnSignIn = driver.FindElement(By.Id("sign-in"));
            btnSignIn.Click();
            Thread.Sleep(2000);
            loginPage = new LoginPage(driver);
        }

        [TestMethod]
        public void UserShouldLoginSuccessfully ()
        {
            //fill email
            driver.FindElement(By.CssSelector("input[data-test=email]")).SendKeys("test@test.test");
            //fill password
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("test");
            //click signin button
            driver.FindElement(By.Name("commit")).Click();
            //assert logged in email
            Assert.IsTrue(driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text.Equals("test@test.test"));
        }

        [TestMethod]
        public void UserShouldFailLoginWithWrongEmail()
        {
            //fill email
            driver.FindElement(By.CssSelector("input[data-test=email]")).SendKeys("wrongEmail@test.test");
            //fill password
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("test");
            //click signin button
            driver.FindElement(By.Name("commit")).Click();
            //assert logged in email
            Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div/div[1]")).Text.Equals("Bad email or password."));
        }

        [TestMethod]
        public void UserShouldFailLoginWithWrongPassword()
        {
            //fill email
            driver.FindElement(By.CssSelector("input[data-test=email]")).SendKeys("test@test.test");
            //fill password
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("wrongPassword");
            //click signin button
            driver.FindElement(By.Name("commit")).Click();
            //assert logged in email
            Assert.IsTrue(driver.FindElement(By.XPath("/html/body/div/div[1]")).Text.Equals("Bad email or password."));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
