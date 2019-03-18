using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class WebdriverExtension
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
               return wait.Until(e => e.FindElement(by));
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Could not find element, you are not on the right page!");
                throw new TimeoutException($"Could not find element, you are not on the right page! {ex.Message}");
            }
        }
    }
}
