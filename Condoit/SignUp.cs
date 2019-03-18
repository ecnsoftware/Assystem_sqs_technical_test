using Common;
using Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condoit
{
    public class SignUp : PageHelper
    {
        public readonly IWebDriver _driver;
        private const string PAGE_TITLE = "Sign Up";
        private const string EMAIL_EXISTS_ERROR_TEXT = "email has already been taken";
        public SignUp(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        
        private IWebElement Title => WebdriverExtension.FindElement(_driver, By.TagName("h1"), WAIT_TIMEOUT_SECONDS);
        private IWebElement UserName => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>fieldset:nth-child(1)>input"), WAIT_TIMEOUT_SECONDS);
        private IWebElement Email => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>fieldset:nth-child(2)>input"), WAIT_TIMEOUT_SECONDS);
        private IWebElement Password => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>fieldset:nth-child(3)>input"), WAIT_TIMEOUT_SECONDS);
        private IWebElement SignUpButton => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>div>div>div>div>div>form>fieldset>button"), WAIT_TIMEOUT_SECONDS);
        private IWebElement SignInButton => WebdriverExtension.FindElement(_driver, By.CssSelector("body>div>app-header>nav>div>ul:nth-child(2)>li:nth-child(2)>a"), WAIT_TIMEOUT_SECONDS);

        public void CreateAnAccount(Customer customer)
        {
            var assert = new TestAssertions();
            assert.VerifyText(Title.Text.ToString(), PAGE_TITLE.ToString());

            UserName.SendKeys(customer.UserName);
            Email.SendKeys(customer.Email);
            Password.SendKeys(customer.Password);
            SignUpButton.Click();

            if (IsTextPersent(By.TagName("body"), EMAIL_EXISTS_ERROR_TEXT)) //This can be handled alot better. We could use a JS method to locate the error element.
            {
                SignInButton.Click();
                var signIn = new SignIn(driver);
                signIn.SignInToAccount(customer);

            }
        }
    }
}
