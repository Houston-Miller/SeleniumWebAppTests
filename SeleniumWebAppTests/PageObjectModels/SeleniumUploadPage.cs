using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebAppTests.PageObjectModels
{
    internal class SeleniumUploadPage
    {
        private readonly ChromeDriver Driver;

        public string Url = "https://the-internet.herokuapp.com/upload";

        string ChooseFileID = "file-upload";
        internal By ChooseFileButton { get => By.Id(ChooseFileID); }

        string FileSubmitID = "file-submit";
        internal By UploadButton { get => By.Id(FileSubmitID); }

        string UploadBannerXPath = "//h3[contains(text(),'File Uploaded!')]";
        internal By FileUploadedHeader { get => By.XPath(UploadBannerXPath); }

        string UploadedFilesNameID = "uploaded-files";
        internal By UploadedFileName { get => By.Id(UploadedFilesNameID); }

        string ForkMeXPath = "//*[@alt='Fork me on GitHub']";
        internal By ForkMeBanner { get => By.XPath(ForkMeXPath); }

        public SeleniumUploadPage(ChromeDriver driver)
        {
            Driver = driver;
        }

        public void UploadMemeImage(string filePath)
        {
            Driver.FindElement(ChooseFileButton).SendKeys(filePath);
            Driver.FindElement(UploadButton).Click();
        }
    }
}
