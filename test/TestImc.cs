using System.IO;
using Microsoft.Extensions.Configuration;
using selenium;
using test.classes;
using Xunit;

namespace test
{
    public class TestImc
    {
        private IConfiguration _config;

        public TestImc()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        }

        [Fact]
        public void TestChrome()
        {
            ExecuteTestIMC(Browser.Chrome);
        }

        private void ExecuteTestIMC(Browser browser)
        {
            Imc imc = new(_config, browser);
            imc.LoadPage();

            imc.ClosePage();
        }
    }
}