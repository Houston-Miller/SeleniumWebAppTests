using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebAppTests.Tests
{
    public class BaseTest : IDisposable
    {
        public ChromeDriver Driver { get; private set; }
        protected readonly WebDriverWait _wait;
        protected readonly Actions _actions;

        public BaseTest()
        {
            var driver = new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            _wait = wait;

            Actions actions = new Actions(Driver);
            _actions = actions;

        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
