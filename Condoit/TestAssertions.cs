using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TestAssertions
    {

        public void VerifyText(string elementValue, string expectedText)
        {
            try
            {   
                Assert.That(expectedText.ToLower() == elementValue.ToLower());
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public void VerifyPage(IWebElement webElement)
        {
            try
            {
                Assert.That(webElement.Displayed);
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
            
        }
            
    }
}
