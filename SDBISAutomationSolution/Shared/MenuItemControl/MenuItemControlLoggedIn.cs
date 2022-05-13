using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.AddressesOverview;

namespace SDBISAutomationSolution.Shared.MenuItemControl
{
    public class MenuItemControlLoggedIn: MenuItemControlCommon
    {
        public MenuItemControlLoggedIn(IWebDriver browser) : base(browser)
        {
        }

        private IWebElement BtnAddresses =>
            driver.FindElement(By.CssSelector("a[data-test=addresses]"));

        private IWebElement BtnSignOut =>
            driver.FindElement(By.CssSelector(""));

        private IWebElement LblUserEmail =>
            driver.FindElement(By.CssSelector(""));

        public AddressesOverviewPage NavigateToAddressesPage()
        {
            BtnAddresses.Click();
            return new AddressesOverviewPage(driver);
        }
    }
}