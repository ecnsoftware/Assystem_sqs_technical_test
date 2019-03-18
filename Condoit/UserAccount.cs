using Common;
using Model;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condoit
{
   public class UserAccount :PageHelper
    {
        private readonly IWebDriver _driver;

        public UserAccount(IWebDriver webDriver) => _driver = webDriver;
  
        private IWebElement YourFeedsTab => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div.container.page>div>div.col-md-9>div>ul>li:nth-child(1)>a"), WAIT_TIMEOUT_SECONDS);
        private IWebElement UserName => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>app-header>nav>div>ul:nth-child(3)>li:nth-child(4)>a"), WAIT_TIMEOUT_SECONDS);

        public void VerifyUserAccountPage()
        {
            var assert = new TestAssertions();
            assert.VerifyPage(YourFeedsTab);
        }

        public void VerifyUserName(Customer customer)
        {
            var assert = new TestAssertions();
            assert.VerifyText(UserName.Text, customer.UserName);
        }

    }
}
