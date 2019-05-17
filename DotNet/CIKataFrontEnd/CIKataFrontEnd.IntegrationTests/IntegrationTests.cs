using System;
using System.Threading;
using OpenQA.Selenium.Chrome;
using Xunit;
using Shouldly;


namespace CIKataFrontEnd.IntegrationTests
{
    public class IntegrationTests
    {
        private string _driverFile = SetChromeDriver();

        private static string SetChromeDriver()
        {
            var envVariable = Environment.GetEnvironmentVariable("ChromeDriverFile");

            if (envVariable != null)
            {
                return envVariable;
            }

            return "chromedrivermac";
        }

        [Fact]
        public void HomePageIsCorrect()
        {
            var service = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory, _driverFile);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            var webDriver = new ChromeDriver(service, chromeOptions);
            
            webDriver.Navigate().GoToUrl("http://localhost:5000/");
            
            webDriver.FindElementByTagName("button").Click();
            
            Thread.Sleep(5000);
            
            var div = webDriver.FindElementByTagName("div");

            try
            {
                div.Text.ShouldBe("This is a successful call!");
            }
            finally
            {
                webDriver.Quit();
            }

        }
    }
}