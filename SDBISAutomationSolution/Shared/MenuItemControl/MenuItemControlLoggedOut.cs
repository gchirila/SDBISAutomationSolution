using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.Login;

namespace SDBISAutomationSolution.Shared.MenuItemControl
{
    public class MenuItemControlLoggedOut: MenuItemControlCommon
    {
        public MenuItemControlLoggedOut(IWebDriver browser) : base(browser)
        { 
        }

        private IWebElement BtnSignIn 
            => driver.FindElement(By.Id("sign-in"));

        public LoginPage NavigateToLoginPage()
        {
            BtnSignIn.Click();
            return new LoginPage(driver);
        }
    }
}