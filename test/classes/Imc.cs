using System;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using selenium;

namespace test.classes
{
    public class Imc : BaseClass
    {
        public Imc(IConfiguration config, Browser browser)
            : base(config, browser)
        {
        }

        public void LoadPage()
        {
            _driver.OpenBrowserPage(TimeSpan.FromSeconds(5), "https://localhost:5001");
        }

        public void FillIMC(double peso, double altura)
        {
            _driver.InputValue(By.Id("id_Peso"), peso.ToString());

            _driver.InputValue(By.Id("id_Altura"), altura.ToString());
        }

        public void CalculateIMC()
        {
            _driver.Submit(By.Id("id_btnCalcular"));

            _driver.Wait(By.Id("ResultImc"), TimeSpan.FromSeconds(10));
        }

        public double GetIMC()
        {
            return Convert.ToDouble(_driver.GetValue(By.Id("ResultImc")));
        }

        public string GetMessage()
        {
            return _driver.GetValue(By.ClassName("alert"));
        }

        public void ClosePage()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}