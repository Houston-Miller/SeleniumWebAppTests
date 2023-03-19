using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace SeleniumWebAppTests
{
    public class UnitTests
    {
        private ITestOutputHelper _logger;
        public UnitTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void Test1()
        {
            ChromeDriver driver = new();
            driver.Navigate().GoToUrl("https://www.nps.gov/bibe/planyourvisit/basin_campground.htm");
            var AccordianElement = driver.FindElement(By.XPath("//span[contains(text(), 'Select Dates...')]//ancestor::button"));
            var CalendarDate = driver.FindElement(By.XPath("//td[contains(@aria-label, 'July 20, 2023')]"));

            //Set Desired Date on Callendar
            AccordianElement.Click();
            CalendarDate.Click();

            //Assert

            driver.Quit();
        }

        [Fact]
        public void UpLoadMemeBackgroundTest()
        {
            ChromeDriver driver = new();
            driver.Navigate().GoToUrl("https://meme-creator.com/editor");
            var BackgroundElement = driver.FindElement(By.XPath("//span[contains(text(),'Background')]"));
            BackgroundElement.Click();

            //Click on "Choose" button to upload custom background
            var ChooseBackgroundUpload = driver.FindElement(By.XPath("//Button[@class='btn btn-light']"));
            ChooseBackgroundUpload.Click();

            //Assert

            driver.Quit();
           
        }

        [Fact]
        //hover over tooptip element, confirm displayed tooltip text
        public void TooltipHoverOverTest()
        {
            ChromeDriver driver = new();
            driver.Navigate().GoToUrl(DustloopPageMillia.Url);
            driver.FindElement();
            

        }
    }
}