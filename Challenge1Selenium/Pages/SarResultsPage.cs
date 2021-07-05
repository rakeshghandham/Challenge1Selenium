using Challenge1Selenium.Helpers;
using OpenQA.Selenium;

namespace Challenge1Selenium.Pages
{
    public class SarResultsPage
    {
        private IWebDriver Driver;

        public SarResultsPage(IWebDriver driver) => Driver = driver;

        #region All the elements declaration

        private IWebElement searchTerm => Driver.FindElement(By.CssSelector(".searchTermContainer"));



        #endregion All the elements declaration

        #region All the Methods  declarations


        public bool SearchTermVisible()
        {
            WebElementExtensions.WaitForElementClickable(searchTerm, Driver);
            return (searchTerm.IsElementLoaded()) ? true : false;
        }

  
    }

    #endregion All the Methods  declarations
}