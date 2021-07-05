using Challenge1Selenium.Helpers;
using OpenQA.Selenium;

namespace Challenge1Selenium.Pages
{
    public class SarHomePage
    {
        private IWebDriver Driver;

        public SarHomePage(IWebDriver driver) => Driver = driver;

        #region All the elements declaration

        private IWebElement lnkAccount => Driver.FindElement(By.CssSelector("#icon-account"));

        private IWebElement signedInUser => Driver.FindElement(By.CssSelector("div.title"));

        private IWebElement lnkSignOut => Driver.FindElement(By.CssSelector("a[data-locator='my_account_toolbar_sign_out_link']"));

        private IWebElement loggedinTickIcon => Driver.FindElement(By.CssSelector("svg[data-locator='loggedin-tick-icon']"));

        #endregion All the elements declaration

        #region All the Methods  declarations

        public void ClickAccountLink()
        {
            WebElementExtensions.WaitForElementClickable(loggedinTickIcon, Driver);
            lnkAccount.CheckElementAndClick();
        }

        public bool UserNameIsVisible()
        {
            WebElementExtensions.WaitForElementClickable(signedInUser, Driver);
            return (signedInUser.IsElementLoaded()) ? true : false;
        }

        public void ClickSignOutLink()
        {
            WebElementExtensions.WaitForElementClickable(lnkSignOut, Driver);
            lnkSignOut.Click();
        }
    }

    #endregion All the Methods  declarations
}