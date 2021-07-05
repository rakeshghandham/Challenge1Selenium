using Challenge1Selenium.Helpers;
using Challenge1Selenium.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Challenge1Selenium.Steps
{
    [Binding]
    public class SarSignInSteps
    {
        private DriverHelper _driverHelper;

        // private SarHomePage sarHomePage;
        private SarSignInPage sarSignInPage;

        public SarSignInSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            //sarHomePage = new SarHomePage(_driverHelper.Driver);
            sarSignInPage = new SarSignInPage(_driverHelper.Driver);
        }

        [Then(@"I should see the Sign in to your account Page")]
        public void ThenIShouldSeeTheSignInToYourAccountPage()
        {
            Assert.IsTrue(sarSignInPage.IsAt(), "Login Test Failed, wrong URL");
        }

        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            sarSignInPage.EnterUserNameAndPassword(data.UserName, data.Password);
        }

        [Then(@"I click Signin button on Signin Page")]
        public void ThenIClickSigninButtonOnSigninPage()
        {
            sarSignInPage.ClickSignIn();
        }
    }
}