

using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.Home;
using SDBISAutomationSolution.Utils;

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
        private By Email = By.CssSelector("input[data-test=email]");
        private IWebElement TxtEmail =>
            driver.FindElement(Email);
        //password textbox
        private IWebElement TxtPassword => driver.FindElement(By.XPath("//input[@placeholder='Password']"));
        //login button
        private IWebElement BtnLogin => driver.FindElement(By.Name("commit"));
        //login fail error label
        private IWebElement LblErrorMessage => driver.FindElement(By.XPath("/html/body/div/div[1]"));

        public HomePage LoginApplication(string email, string password)
        {
            driver.WaitForElement(Email);
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnLogin.Click();
            return new HomePage(driver);
        }

        public string ErrorMessage => LblErrorMessage.Text;
    }


}
