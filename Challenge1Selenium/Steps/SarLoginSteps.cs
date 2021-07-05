using Challenge1Selenium.Helpers;
using Challenge1Selenium.Pages;
using TechTalk.SpecFlow;

namespace Challenge1Selenium.Steps
{
    [Binding]
    public class SarLoginSteps
    {
        private DriverHelper _driverHelper;
        private SarLoginPage sarLoginPage;

        public SarLoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            sarLoginPage = new SarLoginPage(_driverHelper.Driver);
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://www.bunnings.com.au/");
        }

        [Then(@"I click Account link")]
        public void ThenIClickAccountLink()
        {
            sarLoginPage.ClickAccountLink();
        }

        [Then(@"I click SignIn link")]
        public void ThenIClickSignInLink()
        {
            sarLoginPage.ClickSignIn();
        }
    }
}