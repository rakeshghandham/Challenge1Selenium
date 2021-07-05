using Challenge1Selenium.Helpers;
using OpenQA.Selenium;

namespace Challenge1Selenium.Pages
{
    public class SarSearchPage
    {
        private IWebDriver Driver;

        public SarSearchPage(IWebDriver driver) => Driver = driver;

        #region All the elements declaration

        private IWebElement bxSearch => Driver.FindElement(By.CssSelector("#custom-css-outlined-input"));

        private IWebElement bxSearchIcon => Driver.FindElement(By.CssSelector("#crossIcon"));

        private IWebElement recentSearches => Driver.FindElement(By.CssSelector("p[data-locator='Recent searches']"));

        private IWebElement popularSearches => Driver.FindElement(By.CssSelector("p[data-locator='Popular searches']"));

        private IWebElement popularRightNow => Driver.FindElement(By.CssSelector("p[data-locator='Popular right now']"));

        private IWebElement clearRecentSearches => Driver.FindElement(By.XPath("//p[contains(text(),'Clear Recent Searches')]"));

        private IWebElement closeSearchResults => Driver.FindElement(By.CssSelector("#typeahead-clear-btn"));

        #endregion All the elements declaration

        #region All the Methods  declarations

        public void ClickSearch()
        {
            WebElementExtensions.WaitForElementClickable(bxSearch, Driver);
            bxSearch.CheckElementAndClick();
        }

        public bool RecentSearches()
        {
            WebElementExtensions.WaitForElementToBeLoaded(Driver, recentSearches, 5);
            return (recentSearches.IsElementLoaded()) ? true : false;
        }

        public bool PopularSearches()
        {
            WebElementExtensions.WaitForElementToBeLoaded(Driver, popularSearches, 5);
            return (popularSearches.IsElementLoaded()) ? true : false;
        }

        public bool PopularProducts()
        {
            WebElementExtensions.WaitForElementToBeLoaded(Driver, popularRightNow, 5);
            return (popularRightNow.IsElementLoaded()) ? true : false;
        }

        public void ClickCloseSearchResultsBox()
        {
            WebElementExtensions.WaitForElementClickable(closeSearchResults, Driver);
            closeSearchResults.CheckElementAndClick();
        }

        public void ProductSearch(string productName)
        {
            WebElementExtensions.WaitForElementClickable(bxSearch, Driver);
            bxSearch.SendKeys(productName);
        }

        public void ProductSearchClick()
        {
            WebElementExtensions.WaitForElementClickable(bxSearchIcon, Driver);
            bxSearchIcon.CheckElementAndClick();
        }

        public void ClearRecentSearches()
        {
            WebElementExtensions.WaitForElementClickable(clearRecentSearches, Driver);
            clearRecentSearches.CheckElementAndClick();
        }
    }

    #endregion All the Methods  declarations
}