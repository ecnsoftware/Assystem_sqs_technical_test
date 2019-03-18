using Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TestHelper
    {
        public static IWebDriver driver;  
        public Customer CustomerList { get; set; }

        public void InitialiseBrowser(Environment environment)
        {
            var url = GetUrl(environment);
            driver = new ChromeDriver();            
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        private string GetUrl(Environment environment)
        {
            switch (environment)
            {
                case Environment.Test:
                    return Endpoints.TestURL;                     
                case Environment.Prod:
                    return Endpoints.ProdURL;
                default:
                    throw new Exception($"{environment} is not a valid environment!");
            }
        }
    }
}
