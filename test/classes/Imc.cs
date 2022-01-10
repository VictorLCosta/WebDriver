using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
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

        /*public void PreencherIMC(double peso, double altura)
        {
            _driver.A(By.Id("id_Peso"), peso.ToString());
            _driver.AtribuirValor(By.Name("Altura"), altura.ToString());
        }

        public void CalcularIMC()
        {
            _driver.Enviar(By.Id("id_btnCalcular"));
            _driver.Esperar(By.Id("ResultImc"), TimeSpan.FromSeconds(10));
        }

        public double ObterIMC()
        {
            return Convert.ToDouble(_driver.ObterValor(By.Id("ResultImc")));
        }

        public string ObterMensagem()
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