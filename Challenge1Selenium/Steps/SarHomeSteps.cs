using Challenge1Selenium.Helpers;
using Challenge1Selenium.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Challenge1Selenium.Steps
{
    [Binding]
    public class SarHomeSteps
    {
        private DriverHelper _driverHelper;
        private SarHomePage sarHomePage;

        public SarHomeSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            sarHomePage = new SarHomePage(_driverHelper.Driver);
        }

        [Then(@"I click Account link on Home Page")]
        public void ThenIClickAccountLinkOnHomePage()
        {
            sarHomePage.ClickAccountLink();
        }

        [Then(@"I Verify User is logged on to his account")]
        [Given(@"I Verify User is logged on to his account")]
        public void ThenIVerifyUserIsLoggedOnToHisAccount()
        {
            Assert.IsTrue(sarHomePage.UserNameIsVisible(), "Home Page failed Loading");
        }

        [Then(@"I click logout")]
        public void ThenIClickLogout()
        {
            sarHomePage.ClickSignOutLink();
        }
    }
}