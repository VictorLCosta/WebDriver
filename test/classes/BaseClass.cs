using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using selenium;

namespace test.classes
{
    public class BaseClass
    {
        private IConfiguration _config;
        private Browser _browser;
        protected IWebDriver _driver;

        public BaseClass(IConfiguration config, Browser browser)
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
    }
}