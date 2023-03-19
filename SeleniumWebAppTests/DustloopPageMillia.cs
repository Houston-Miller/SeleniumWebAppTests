using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebAppTests
{
    internal class DustloopPageMillia
    {
        internal string Url = "https://www.dustloop.com/w/GGST/Millia_Rage";

        string tandemTopTooltipXPath = "//*[@id='home-content']//*[contains(@href, '#Tandem_Top')]";
        internal By TandemTopTooltip { get => By.XPath(tandemTopTooltipXPath); }
        
    }
}
