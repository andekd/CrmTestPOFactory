using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CrmTests
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                //wait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.StaleElementReferenceException)); // ignore stale exception issues
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds, bool elementThere)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                //wait.IgnoreExceptionTypes(typeof(OpenQA.Selenium.StaleElementReferenceException)); // ignore stale exception issues
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
