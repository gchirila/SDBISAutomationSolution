using OpenQA.Selenium;

namespace SDBISAutomationSolution.Shared.MenuItemControl
{
    public class MenuItemControlCommon
    {
        public IWebDriver driver;

        public MenuItemControlCommon(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement BtnHome =>
            driver.FindElement(By.CssSelector(""));
    }
}