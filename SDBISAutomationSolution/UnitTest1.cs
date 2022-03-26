using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SDBISAutomationSolution
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserShouldLoginSuccessfully ()
        {
            //open browser
            var driver = new ChromeDriver();
            //maximize window
            driver.Manage().Window.Maximize();
            //navigate to app URL
            driver.Navigate().GoToUrl("http://a.testaddressbook.com/");
            //click sign in button
            var btnSignIn = driver.FindElement(By.Id("sign-in"));
            btnSignIn.Click();
            Thread.Sleep(2000);
            //fill email
            driver.FindElement(By.CssSelector("input[data-test=email]")).SendKeys("test@test.test");
            //fill password
            driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("test");
            //click signin button
            driver.FindElement(By.Name("commit")).Click();
            //assert logged in email
            Assert.IsTrue(driver.FindElement(By.XPath("//span[@data-test='current-user']")).Text.Equals("test@test.test"));
            //quit browser
            driver.Quit();
        }
    }
}
