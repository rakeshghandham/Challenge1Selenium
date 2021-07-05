using Challenge1Selenium.Helpers;
using OpenQA.Selenium;

namespace Challenge1Selenium.Pages
{
    public class SarLoginPage
    {
        private IWebDriver Driver;

        public SarLoginPage(IWebDriver driver) => Driver = driver;

        #region All of the elements declaration

        private IWebElement lnkAccount => Driver.FindElement(By.CssSelector("#icon-account"));
        private IWebElement lnkSignIn => Driver.FindElement(By.CssSelector("button[type='submit'][tabindex='0'][data-locator='Button_SignIn']"));

        #endregion All of the elements declaration

        #region All of the Methods  declarations

        public void ClickAccountLink()
        {
            WebDriverExtensions.WaitForPageLoaded(Driver);
            WebElementExtensions.WaitForElementToBeLoaded(Driver, lnkAccount, 2);
            lnkAccount.Click();
        }

        public void ClickSignIn()
        {
            WebDriverExtensions.WaitForPageLoaded(Driver);
            lnkSignIn.Click();
        }

        #endregion All of the Methods  declarations
    }
}