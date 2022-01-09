using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace test
{
    public class GoogleTest
    {
        private IConfiguration _config;
        private Browser _browser;
        private IWebDriver _driver;

        public GoogleTest(IConfiguration config, Browser browser)
        {
            _config = config;
            _browser = browser;

            string pathDriver = null;

            if(_browser == Browser.FireFox)
            {
                pathDriver = _config.GetSection("Selenium:PathDriverFirefox").Value;
            }
            else if(_browser == Browser.Chrome)
            {
                pathDriver = _config.GetSection("Selenium:PathDriverChrome").Value;
            }
            else 
            {
                pathDriver = _config.GetSection("Selenium:PathDriverOpera").Value;
            }

            _driver = WebDriverFactory.CreateWebDriver(browser, pathDriver);

        }

        public void LoadPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("http://www.google.com.br");
        }

        public ReadOnlyCollection<IWebElement> SearchGoogle(string query)
        {
            var webElement = _driver.FindElement(By.Name("q"));
            webElement.SendKeys(query);
            webElement.SendKeys(Keys.Enter);

            var resultSearch = _driver.FindElement(By.Id("search"));
            var results = resultSearch.FindElements(By.XPath(".//a"));

            return results;
        }

        public void ClosePage()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}