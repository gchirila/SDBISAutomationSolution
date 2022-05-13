using OpenQA.Selenium;
using SDBISAutomationSolution.PageObjects.AddressesOverview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDBISAutomationSolution.Shared.MenuItemControl;

namespace SDBISAutomationSolution.PageObjects.Home
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public MenuItemControlLoggedIn menuItemControlLoggedIn =>
            new MenuItemControlLoggedIn(driver);
    }
}
