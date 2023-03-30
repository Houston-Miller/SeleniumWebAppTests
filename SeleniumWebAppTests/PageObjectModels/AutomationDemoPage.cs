using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebAppTests.PageObjectModels
{
    internal class AutomationDemoPage
    {
        //private readonly ChromeDriver Driver;
        
        public string Url = "https://demo.automationtesting.in/Datepicker.html";

        string DatePickerID = "datepicker2";
        internal By DatePickerField { get => By.Id(DatePickerID); }
    }
}
