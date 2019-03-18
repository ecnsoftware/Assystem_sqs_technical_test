using Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow
{
    [Binding]
    public class Hook : TestHelper
    {

        [BeforeScenario]
        public void SetUp()
        {
            var env = (Common.Environment)Enum.Parse(typeof(Common.Environment), ConfigurationManager.AppSettings["Environment"], true);
            InitialiseBrowser(env);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
