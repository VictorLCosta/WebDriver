using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using selenium;

namespace test.classes
{
    public class Imc
    {
        private IConfiguration _config;
        private Browser _browser;
        private IWebDriver _driver;

        public Imc(IConfiguration config, Browser browser)
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
            _driver.OpenBrowserPage(TimeSpan.FromSeconds(5), "https://localhost:5001");
        }

        public void FillIMC(double peso, double altura)
        {
            _driver.InputValue(By.Id("id_Peso"), peso.ToString());

            _driver.InputValue(By.Id("Altura"), altura.ToString());
        }

        public void CalculateIMC()
        {
            _driver.Submit(By.Id("id_btnCalcular"));

            _driver.Wait(By.Id("ResultImc"), TimeSpan.FromSeconds(10));
        }

        public double GetIMC()
        {
            return Convert.ToDouble(_driver.GetValue(By.Id("SelectImc")));
        }

        public string GetMessage()
        {
            return _driver.GetValue(By.Id("alert"));
        }

        public void ClosePage()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}