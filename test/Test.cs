using Microsoft.Extensions.Configuration;
using selenium;
using System;
using System.IO;
using Xunit;

namespace test
{
    public class Test
    {
        private IConfiguration _config;

        public Test()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        }
        
        [Fact]
        public void TestFirefox()
        {
            ExecuteGoogleTest(Browser.FireFox);
        }

        [Fact]
        public void TestChrome()
        {
            ExecuteGoogleTest(Browser.Chrome);
        }

        private void ExecuteGoogleTest(Browser browser)
        {
            GoogleTest googleTest = new(_config, browser);
            
            googleTest.LoadPage();
            googleTest.ClosePage();
        }
    }
}