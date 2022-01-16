using Microsoft.Extensions.Configuration;
using selenium;
using System;
using System.IO;
using test.classes;
using Xunit;

namespace test.testCases
{
    public class TestGoogle : BaseTest
    {
        public TestGoogle() {}
        
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
            Google google = new(_config, browser);
            
            google.LoadPage();
            var results = google.SearchGoogle("mrinfo");
            Assert.True(results.Count > 0);

            google.ClosePage();
        }
    }
}