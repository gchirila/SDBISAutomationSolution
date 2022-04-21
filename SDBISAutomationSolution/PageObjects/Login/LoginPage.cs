

using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.Home;

namespace SDBISAutomationSolution.PageObjects.Login
{
    public class LoginPage
    {

        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        //email textbox
        private IWebElement TxtEmail => driver.FindElement(By.CssSelector("input[data-test=email]"));
        //password textbox
        private IWebElement TxtPassword => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        //login button
        private IWebElement BtnLogin => driver.FindElement(By.Name("commit"));
        //login fail error label
        private IWebElement LblErrorMessage => driver.FindElement(By.XPath("/html/body/div/div[1]"));

        public HomePage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new HomePage(driver);
        }

        public string ErrorMessage => LblErrorMessage.Text;
    }


}
