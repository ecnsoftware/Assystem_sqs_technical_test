using Common;
using Condoit;
using Model;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specflow
{
    [Binding]
    public class Step_Definiiton : TestHelper
    {
        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            var homePage = new Home(driver);
            homePage.VerifyTitle();          
        }

        [When(@"I complete the sign up form:")]
        public void WhenICompleteTheSignUpForm(Table table)
        {
            //CustomerList object can be made into a list, that way we can have list of customers and loop through to be registered.
            CustomerList = table.CreateInstance<Customer>();
            var homePage = new Home(driver);
            var signUp = new SignUp(driver);
            homePage.GoToSignUpPage();
            signUp.CreateAnAccount(CustomerList);
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            var userAccount = new UserAccount(driver);
            userAccount.VerifyUserAccountPage();
        }

        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
            var userAccount = new UserAccount(driver);
            userAccount.VerifyUserName(CustomerList);
        }

    }
}
