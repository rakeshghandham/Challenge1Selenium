using Challenge1Selenium.Helpers;
using Challenge1Selenium.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Challenge1Selenium.Steps
{
    [Binding]
    public class SarSearchSteps
    {
        private DriverHelper _driverHelper;
        private SarSearchPage sarSearchPage;

        public SarSearchSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            sarSearchPage = new SarSearchPage(_driverHelper.Driver);
        }

        [When(@"I  click on Searh box")]
        [Then(@"I  click on Searh box")]
        public void WhenIClickOnSearhBox()
        {
            sarSearchPage.ClickSearch();
        }

        [Then(@"I should be able to view Popular Searches")]
        public void ThenIShouldBeAbleToViewPopularSearches()
        {
            Assert.IsTrue(sarSearchPage.PopularSearches(), "Recent Search box is not displayed");
        }

        [Then(@"I should be able to view popular right now products")]
        public void ThenIShouldBeAbleToViewPopularRightNowProducts()
        {
            Assert.IsTrue(sarSearchPage.PopularProducts(), "Popular Right Now Products Search box is not displayed");
        }

        [Then(@"I click on Close Search Results Box")]
        public void ThenIClickOnCloseSearchResultsBox()
        {
            sarSearchPage.ClickCloseSearchResultsBox();
        }

        [Then(@"I search for a Product ""(.*)""")]
        public void ThenISearchForAProductSaw(string ProductName)
        {
            sarSearchPage.ProductSearch(ProductName);
        }

        [Then(@"I click on Search Icon")]
        public void ThenIClickOnSearchIcon()
        {
            sarSearchPage.ProductSearchClick();
        }

        [Then(@"I click on clear recent searches link")]
        public void ThenIClickOnClearRecentSearchesLink()
        {
            sarSearchPage.ClearRecentSearches();
        }
    }
}