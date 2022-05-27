using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SDBISAutomationSolution.Utils
{
    public static class WaitUtils
    {
        public static bool IsAvailable(IWebElement element) =>
            element != null && element.Displayed && element.Enabled;

        public static void WaitForElement(this IWebDriver driver, By by, int duration = 20)
        {
            var wait = 
                new WebDriverWait(driver, new TimeSpan(0, 0, duration))
                {
                    PollingInterval = TimeSpan.FromMilliseconds(30),
                    Timeout = TimeSpan.FromSeconds(duration)
                };

            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            wait.Until(condition =>
                {
                    try
                    {
                        var element = driver.FindElement(by);
                        if (IsAvailable(element))
                        {
                            return element;
                        }

                        return null;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return null;
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                });
        }
    }
}
