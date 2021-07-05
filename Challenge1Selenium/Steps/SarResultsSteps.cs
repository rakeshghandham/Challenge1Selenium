using Challenge1Selenium.Helpers;
using Challenge1Selenium.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Challenge1Selenium.Steps
{
    [Binding]
    public class SarResultsSteps
    {
        private DriverHelper _driverHelper;
        private SarResultsPage sarResultsPage;

        public SarResultsSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            sarResultsPage = new SarResultsPage(_driverHelper.Driver);
        }

        [Then(@"I should be able to view ""(.*)"" on results Page")]
        public void ThenIShouldBeAbleToViewSawOnResultsPage(string SearchTerm)
        {
            Assert.IsTrue(sarResultsPage.SearchTermVisible(), "Home Page failed Loading");
        }
    }
}