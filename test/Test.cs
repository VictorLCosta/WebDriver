using Microsoft.Extensions.Configuration;
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
        public void Test1()
        {
            var pathDriver = _config.GetSection("Selenium:PathDriverFirefox").Value;
        }
    }
}