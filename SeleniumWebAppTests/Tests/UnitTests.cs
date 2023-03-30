using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumWebAppTests.PageObjectModels;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;
using System.Linq;

namespace SeleniumWebAppTests.Tests
{
    public class UnitTests : BaseTest
    {
        SeleniumUploadPage _seleniumUploadPage;
        DustloopPageMillia _dustloopPageMillia;
        AutomationDemoPage _autoQAPage;

        public UnitTests()
        {
            _seleniumUploadPage = new SeleniumUploadPage(Driver);
            _dustloopPageMillia = new DustloopPageMillia();
            _autoQAPage = new AutomationDemoPage();

        }

        [Fact]
        public void PageTitleTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act (kinda - Look I started off real simple)
            string Title = "GGST - Millia Rage Overview";

            Driver.Title.Should().Be(Title);
        }

        [Fact]
        public void ComboPageLinkTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act (I promise they get better)
            string Title = "GGST - Millia Rage Combos";
            var CombosLinkPage = Driver.FindElement(_dustloopPageMillia.CombosLink);
            CombosLinkPage.Click();
            
            //Assert
            Driver.Title.Should().Be(Title);

        }

        //
        [Fact]
        public void FrameDataExplainerElementTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var frameDataLinkPage = Driver.FindElement(_dustloopPageMillia.FrameDataLink);
            frameDataLinkPage.Click();
            var howToRead = Driver.FindElement(_dustloopPageMillia.FrameDataExplained);

            //Assert
            howToRead.Displayed.Should().BeTrue();
        }


        //Required Feature - open new tab and ontinue test
        //Force open page in new tab - navigate to that tab and ensure a specific page element is there
        [Fact]
        public void ComboLinkNewTab()
        {
            //Arrange
            Actions actions = new Actions(Driver);

            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            actions.KeyDown(Keys.LeftControl).Build().Perform();
            var CombosLinkPage = Driver.FindElement(_dustloopPageMillia.CombosLink);
            CombosLinkPage.Click();
            actions.KeyUp(Keys.LeftControl).Build().Perform();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.WindowHandles.Count == 2);

            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            var BeginnerBadgeImage = Driver.FindElement(_dustloopPageMillia.BeginnerBadge);
            actions.MoveToElement(BeginnerBadgeImage).Perform();

            //Assert - this is a page element only found on the "combos" page
            BeginnerBadgeImage.Displayed.Should().BeTrue();


        }

        [Fact]
        public void DustloopSearchbarVisiblityTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var SearchOpen = Driver.FindElement(_dustloopPageMillia.OpenSearch);
            SearchOpen.Click();
            var Searchbar = Driver.FindElement(_dustloopPageMillia.SearchWiki);

            //Assert
            Searchbar.Displayed.Should().BeTrue();
        }

        [Fact]
        public void DustloopSearchbarPositiveTest()
        {

            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var SearchOpen = Driver.FindElement(_dustloopPageMillia.OpenSearch);
            SearchOpen.Click();
            var Searchbar = Driver.FindElement(_dustloopPageMillia.SearchWiki);

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_dustloopPageMillia.SearchWiki).Displayed);
            Searchbar.Click();
            Searchbar.SendKeys("Ky Kiske" + Keys.Enter);


            //Assert
            Driver.Title.Should().Be("Ky Kiske - Dustloop Wiki");

        }

        //Required feature - Negative Test
        [Fact]
        public void DustloopSearchbarNegativeTest()
        {

            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var SearchOpen = Driver.FindElement(_dustloopPageMillia.OpenSearch);
            SearchOpen.Click();
            var Searchbar = Driver.FindElement(_dustloopPageMillia.SearchWiki);

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_dustloopPageMillia.SearchWiki).Displayed);
            Searchbar.Click();
            Searchbar.SendKeys("Yoshimitsu" + Keys.Enter);

            wait.Until(c => Driver.FindElement(_dustloopPageMillia.NoResults).Displayed);
            var noResultsFound = Driver.FindElement(_dustloopPageMillia.NoResults);

            //Assert - No results found from entered search query
            noResultsFound.Text.Should().Contain("There were no results matching the query.");


        }

        // Required feature - Calendar Date Picker
        [Fact]
        public void CalendarDatePickerTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_autoQAPage.Url);
            Driver.Manage().Window.Maximize();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_autoQAPage.DatePickerField).Displayed);
            var SelectDate = Driver.FindElement(_autoQAPage.DatePickerField);
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            
            //Act - input today's date into calandar picker
            SelectDate.Click();
            SelectDate.SendKeys(currentDate);

            var inputFieldText = Driver.FindElement(_autoQAPage.DatePickerField).GetAttribute("value");

            //assert - input field should have current Date
            inputFieldText.Should().Be(currentDate);

        }

        [Fact]
        public void ForkMeBannerTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_seleniumUploadPage.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var forkMeBanner = Driver.FindElement(_seleniumUploadPage.ForkMeBanner);

            //Assert
            forkMeBanner.Displayed.Should().BeTrue();
        }

        // Required Feature - File Upload
        [Fact]
        public void UploadFileTest()
        {
            
            Actions actions = new Actions(Driver);

            Driver.Navigate().GoToUrl(_seleniumUploadPage.Url);
            Driver.Manage().Window.Maximize();
            
            var ChooseFile = Driver.FindElement(_seleniumUploadPage.ChooseFileButton);
            string fileExtention = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            _seleniumUploadPage.UploadMemeImage(fileExtention+"/Upload/DaShareZone.jpg");
            

            //Assert - Site displays banner with uploaded image name + 'File Uploaded!' Header
            using (new AssertionScope())
            {
                Driver.FindElement(_seleniumUploadPage.FileUploadedHeader).Displayed.Should().BeTrue();
                Driver.FindElement(_seleniumUploadPage.UploadedFileName).Text.Should().Be("DaShareZone.jpg");
            }
        }

        //Required Feature - hover over tooptip
        [Fact]
        public void TooltipHoverOverTest()
        {
            //Arrange
            Actions actions = new Actions(Driver);
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();
            var tooltipTarget = Driver.FindElement(_dustloopPageMillia.FrameDataTooltip);
            //Act

            actions.MoveToElement(tooltipTarget).Perform();
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(c => Driver.FindElement(_dustloopPageMillia.FrameDataTooltip).Displayed);
            
            //Assert - That is so much text
            tooltipTarget.Text.Should().Be("Startup\r\nThe time before an attack is active including the first active frame. For example, an attack with 10F startup means the attack will do nothing for 9 frames, then hit the opponent on the 10th frame.");

        }

        //Operate tab within page to display new elements
        [Fact]
        public void HitboxesTabTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();
            var hitboxesTab = Driver.FindElement(_dustloopPageMillia.HitboxTab2);

            //Act
            hitboxesTab.Click();
            var hitboxFrameData = Driver.FindElement(_dustloopPageMillia.HitboxFrameData1);

            //Assert
            using (new AssertionScope())
            {
                hitboxFrameData.Displayed.Should().BeTrue();
                hitboxFrameData.Text.Should().Contain("1st Hit (frame 7-9)");
            }
        }

        //
        [Fact]
        public void MilliaPortraitImageTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var milliaPortrait = Driver.FindElement(_dustloopPageMillia.MilliaPortrait);

            //Assert - Character Portrait is visibile
            milliaPortrait.Displayed.Should().BeTrue();


        }

        [Fact]
        public void PickListTextTest()
        {
            //Arrange
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //Act
            var picklistText = Driver.FindElement(_dustloopPageMillia.Picklist);

            //Assert
            picklistText.Text.Should().Be("Forcing coinflips and multi layered mixups, especially with meter.");

        }

        [Fact]
        public void TableContentsListTest()
        {
            //arrange - go to Url of Page
            Driver.Navigate().GoToUrl(_dustloopPageMillia.Url);
            Driver.Manage().Window.Maximize();

            //act - navigate to table element on page, capture info displayd there
            List<string> FrameDataTable = new List<string>(Driver.FindElements(_dustloopPageMillia.FrameTable).Select(iw => iw.Text));

            //assert - table has 7 items in it
            FrameDataTable.Should().Contain("Startup", "Active", "Inactive", "Recovery", "Special Recovery", "Projectile", "Cancel");

        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}