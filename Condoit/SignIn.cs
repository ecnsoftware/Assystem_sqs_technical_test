using Common;
using Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condoit
{
   public class SignIn : PageHelper
    {
        private readonly IWebDriver _driver;
        private const string TITLE = "Sign In";
        public SignIn(IWebDriver webDriver)
        {
            _driver = webDriver;
        }
        private IWebElement YourFeedTab => WebdriverExtension.FindElement(_driver, By.XPath("/html/body/div/div/div/div[2]/div/div[1]/div/ul/li[1]/a"), WAIT_TIMEOUT_SECONDS);
        private IWebElement Email => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>fieldset:nth-child(2)>input"), WAIT_TIMEOUT_SECONDS);
        private IWebElement Password => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>fieldset:nth-child(3)>input"), WAIT_TIMEOUT_SECONDS);
        private IWebElement SignInButton => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>button"), WAIT_TIMEOUT_SECONDS);

        public void SignInToAccount(Customer customer)
        {
            Email.SendKeys(customer.Email);
            Password.SendKeys(customer.Password);
            SignInButton.Click();
            var assert = new TestAssertions();
            assert.VerifyPage(YourFeedTab);
            var user = new UserAccount(driver);
            user.VerifyUserName(customer);
        }

    }
}
