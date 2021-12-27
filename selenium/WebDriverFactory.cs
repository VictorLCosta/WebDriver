using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;

namespace selenium
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string pathDriver = null)
        {
            IWebDriver webDriver = null;

            switch (browser)
            {
                case Browser.FireFox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(pathDriver);
                    webDriver = new FirefoxDriver(service);
                    break;

                case Browser.Chrome:
                    webDriver = new ChromeDriver(pathDriver);
                    break;

                case Browser.Opera:
                    webDriver = new OperaDriver(pathDriver);
                    break;
            }

            return webDriver;
        }
    }
}