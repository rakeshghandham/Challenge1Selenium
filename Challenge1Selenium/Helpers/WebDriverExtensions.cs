using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace Challenge1Selenium.Helpers
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 60);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        //public static IWebElement FindById(this RemoteWebDriver remoteWebDriver, string element)
        //{
        //    try
        //    {
        //        if (remoteWebDriver.FindElementById(element).IsElementPresent())
        //        {
        //            return remoteWebDriver.FindElementById(element);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new ElementNotVisibleException($"Element not found : {element}");
        //    }
        //    return null;
        //}

        //public static IWebElement FindByClassName(this RemoteWebDriver remoteWebDriver, string element)
        //{
        //    try
        //    {
        //        if (remoteWebDriver.FindByClassName(element).IsElementPresent())
        //        {
        //            return remoteWebDriver.FindByClassName(element);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new ElementNotVisibleException($"Element not found : {element}");
        //    }
        //    return null;
        //}

        //public static IWebElement FindByXpath(this RemoteWebDriver remoteWebDriver, string element)
        //{
        //    try
        //    {
        //        if (remoteWebDriver.FindElementByXPath(element).IsElementPresent())
        //        {
        //            return remoteWebDriver.FindElementByXPath(element);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        e.GetBaseException();
        //        throw new ElementNotVisibleException($"Element not found : {element}");
        //    }
        //    return null;
        //}

        //public static IWebElement FindByCss(this RemoteWebDriver remoteWebDriver, string element)
        //{
        //    try
        //    {
        //        if (remoteWebDriver.FindElementByCssSelector(element).IsElementPresent())
        //        {
        //            return remoteWebDriver.FindElementByCssSelector(element);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new ElementNotVisibleException($"Element not found : {element}");
        //    }
        //    return null;
        //}

        //public static IWebElement FindByLinkText(this RemoteWebDriver remoteWebDriver, string element)
        //{
        //    try
        //    {
        //        if (remoteWebDriver.FindElementByLinkText(element).IsElementPresent())
        //        {
        //            return remoteWebDriver.FindElementByLinkText(element);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new ElementNotVisibleException($"Element not found : {element}");
        //    }
        //    return null;
        //}

        ////public static void WaitForElementClickable(IWebElement elementClickable, IWebDriver driver)
        ////{
        ////    WebDriverWait clickableWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        ////    clickableWait.Until(EC.ElementToBeClickable(elementClickable));
        ////}

        //internal static object JaveExecution(this RemoteWebDriver remoteWebDriver, string script)
        //{
        //    return ((IJavaScriptExecutor)remoteWebDriver).ExecuteScript(script);
        //}

        //public static IWebElement GetElementAndScrollTo(this RemoteWebDriver driver, By by)
        //{
        //    var js = (IJavaScriptExecutor)driver;
        //    try
        //    {
        //        var element = driver.FindElement(by);
        //        if (element.Location.Y > 200)
        //        {
        //            js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
        //        }
        //        return element;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}