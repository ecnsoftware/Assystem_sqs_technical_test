using Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condoit
{
   public class PageHelper : TestHelper
    {
        public const int WAIT_TIMEOUT_SECONDS = 20;

       public bool IsTextPersent(By by, string text)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS));
                wait.Until(w => w.FindElement(by)).Text.ToLower().Contains(text.ToLower());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                return false;
            }
        }

        //public bool IsTextVisible(string text)
        //{
        //    try
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
