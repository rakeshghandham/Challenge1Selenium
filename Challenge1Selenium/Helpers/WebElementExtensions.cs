using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Challenge1Selenium.Helpers
{
    public static class WebElementExtensions
    {
        public static void WaitForElementClickable(this IWebElement elementClickable, IWebDriver driver)
        {
            WebDriverWait clickableWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            clickableWait.Until(EC.ElementToBeClickable(elementClickable));
        }

        public static void WaitForOverlay(this IWebElement element, IWebDriver driver, String attributeName, String attributeValue)
        {
            WebDriverWait overlayWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            try
            {
                overlayWait.Until<IWebElement>((d) =>
            {
                if (element.GetAttribute(attributeName) == attributeValue)
                {
                    return element;
                }
                return null;
            });
            }
            catch (NoSuchElementException e)
            {
                e.GetBaseException();
            }
        }


        public static IWebElement ElementEnabled(IWebElement element, int timeout = 10000)
        {
            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                if (element.Enabled)
                {
                    return element;
                }
            }
            s.Stop();
            return null;
        }

        //todo: Check if the element is enabled or not 
        public static bool IsElementEnabled(IWebElement element, int timeout = 10000)
        {
            if (element == null)
                return false;

            var s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(timeout))
            {
                if (element.Enabled)
                {
                    return element.Enabled;
                }
            }
            s.Stop();

            return false;
        }


        public static IWebElement WaitForElement(IWebDriver driver, IWebElement element, int timeout = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(driver =>
            {
                try
                {
                    return element.IsElementPresent();
                }
                catch (Exception)
                {
                    return false;
                }

            });
            return null;
        }

        // todo: Wait for 1 min to load the element.
        // todo: If the element fails to load then return false(Stating the element was not loaded)
        public static IWebElement WaitForElementToBeLoaded(IWebDriver driver, IWebElement element, int timeout = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(driver =>
            {
                try
                {
                    return element.IsElementPresent();
                }
                catch (Exception)
                {
                    return false;
                }

            });
            return null;
        }


        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
            ddl.SelectByText(value);
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present exception"));
        }

        public static void CheckAndClickElement(this IWebElement element)
        {
            try
            {
                AssertElementPresent(element);
                ElementEnabled(element, 20000);

                element.Click();
            }
            catch (NoSuchElementException e)
            {
                e.GetBaseException();
            }
        }

        //todo: Check if the element is present and click it 
        public static void CheckElementAndClick(this IWebElement element)
        {
            if (!IsElementLoaded(element))
                throw new Exception("Element not present");

            if (!IsElementEnabled(element))
                throw new Exception("Element not enabled");

            element.Click();
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // todo: Use the IsElementLoaded instead of the isElementPresent for deleteLead Feature
        public static bool IsElementLoaded(this IWebElement element)
        {
            if (element != null)
                return element.Displayed;

            return false;
        }

        //public static void EnterValueInTextBox(IWebElement element, string textToEnter)
        //{
        //    element.Click();
        //    try
        //    {
        //        element.Clear();
        //        Driver.Wait(TimeSpan.FromMilliseconds(300));
        //        element.SendKeys(textToEnter);
        //    }
        //    catch (OpenQA.Selenium.InvalidElementStateException e)
        //    {
        //        e.GetBaseException();
        //    }
        //}

        public static void EnterValueInTextBox(IWebElement element, int textToEnter)
        {
            element.Click();
            try
            {
                element.Clear();
                element.SendKeys(textToEnter.ToString());
            }
            catch (OpenQA.Selenium.InvalidElementStateException e)
            {
                e.GetBaseException();
            }
        }

        public static bool VerifyToastMessage(this IWebElement element, string message)
        {
            bool result = false;
            try
            {
                string toastmessage = element.Text;

                if (toastmessage == message)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }

            return result;
        }
    }
}