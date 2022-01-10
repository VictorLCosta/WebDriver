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
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl("https://localhost:5001");
        }

        public void FillIMC(double peso, double altura)
        {
            var elPeso = _driver.FindElement(By.Id("id_Peso"));
            elPeso.SendKeys(peso.ToString());

            var elHeight = _driver.FindElement(By.Name("Altura"));
            elHeight.SendKeys(altura.ToString());
        }

        public void CalculateIMC()
        {
            var btn = _driver.FindElement(By.Id("id_btnCalcular"));
            btn.Submit();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(x => x.FindElement(By.Id("ResultImc")) != null);
        }

        public double GetIMC()
        {
            var elResult = _driver.FindElement(By.Id("ResultImc"));

            return Convert.ToDouble(elResult.Text);
        }

        /*public string ObterMensagem()
        {
            return _driver.ObterValor(By.ClassName("alert"));
        }*/

        public void ClosePage()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}