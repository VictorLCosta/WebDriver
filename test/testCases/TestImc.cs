using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using test.classes;
using Xunit;

namespace test.testCases
{
    public class TestImc : BaseTest
    {
        public TestImc() {}

        [Fact]
        public void TestFireFox()
        {
            ExecuteTestIMC(Browser.FireFox, 50, 1.75, 16.33, "Muito abaixo do peso");
        }

        [Fact]
        public void TestChrome()
        {
            ExecuteTestIMC(Browser.Chrome, 50, 1.75, 16.33, "Muito abaixo do peso");
        }

        private void ExecuteTestIMC(Browser browser, double weight, double height, 
            double expectedValue, string expectedMessage)
        {
            Imc imc = new(_config, browser);
            imc.LoadPage();

            imc.FillIMC(weight, height);
            imc.CalculateIMC();
            var result = imc.GetIMC();

            Assert.NotNull(result);
            Assert.Equal(expectedValue, result);

            var message = imc.GetMessage();

            Assert.NotNull(message);
            Assert.Equal(expectedMessage, message);

            imc.ClosePage();
        }
    }
}