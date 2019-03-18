using Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condoit
{
    public class Home : PageHelper
    {
        private readonly IWebDriver _driver;
        public Home(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        private const string TITLE = "Conduit";

        private IWebElement Title => WebdriverExtension.FindElement(_driver, By.TagName("h1"), WAIT_TIMEOUT_SECONDS);
        private IWebElement SignUpButton => WebdriverExtension.FindElement(_driver, By.CssSelector("body > div > app-header > nav > div > ul:nth-child(2) > li:nth-child(3) > a"), WAIT_TIMEOUT_SECONDS);

        public void VerifyTitle()
        {
            
            var pageHelper = new PageHelper();
            var assert = new TestAssertions();
            if (Title.Displayed)
            {
                assert.VerifyText(Title.Text, TITLE);
            }
            
        }

        public void GoToSignUpPage()
        {
            SignUpButton.Click();
        }


    }
}
