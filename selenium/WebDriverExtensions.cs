using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium
{
    public static class WebDriverExtensions
    {
        public static void OpenBrowserPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Manage().Window.Maximize();

            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetValue(this IWebDriver webDriver, By by)
        {
            return webDriver.FindElement(by).Text;
        }

        public static void InputValue(this IWebDriver webDriver, By by, string text)
        {
            webDriver.FindElement(by).SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            webDriver.FindElement(by).Submit();
        }

        public static void Click(this IWebDriver webDriver, By by)
        {
            webDriver.FindElement(by).Click();
        }

        public static void Wait(this IWebDriver webDriver, By by, TimeSpan timeToWait)
        {
            WebDriverWait wait = new(webDriver, timeToWait);
            wait.Until(x => x.FindElement(by) != null);
        }

    }
}