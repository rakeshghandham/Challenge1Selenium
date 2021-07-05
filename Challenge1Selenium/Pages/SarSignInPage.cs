using Challenge1Selenium.Helpers;
using OpenQA.Selenium;

namespace Challenge1Selenium.Pages
{
    public class SarSignInPage
    {
        private IWebDriver Driver;

        public SarSignInPage(IWebDriver driver) => Driver = driver;

        #region All of the elements declaration

        private IWebElement signInUsername => Driver.FindElement(By.CssSelector("#okta-signin-username"));
        private IWebElement signInPassword => Driver.FindElement(By.CssSelector("#okta-signin-password"));
        private IWebElement btnSignIn => Driver.FindElement(By.CssSelector("#okta-signin-submit"));
        private IWebElement lnkAccount => Driver.FindElement(By.CssSelector("#icon-account"));

        #endregion All of the elements declaration

        #region All of the Methods  declarations

        public bool IsAt()
        {
            WebElementExtensions.WaitForElementToBeLoaded(Driver, signInUsername, 5);
            string signInPageUrl = Driver.Url;
            return signInPageUrl.Contains("?redirectUri") ? true : false;
        }

        public void EnterUserNameAndPassword(string userName, string password)
        {
            WebElementExtensions.WaitForElementToBeLoaded(Driver, signInUsername, 5);
            signInUsername.SendKeys(userName);
            signInPassword.SendKeys(password);
        }

        public void ClickSignIn()
        {
            btnSignIn.CheckElementAndClick();
            WebDriverExtensions.WaitForPageLoaded(Driver);
        }

        public void ClickAccountLink()
        {
            WebDriverExtensions.WaitForPageLoaded(Driver);
            lnkAccount.Click();
        }

        #endregion All of the Methods  declarations
    }
}