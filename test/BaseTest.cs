using System.IO;
using Microsoft.Extensions.Configuration;

namespace test
{
    public class BaseTest
    {
        protected IConfiguration _config;

        public BaseTest()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}