using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebAppTests.PageObjectModels
{
    internal class DustloopMilliaCombosPage
    {
        internal string Url = "https://www.dustloop.com/w/GGST/Millia_Rage/Combos";

        //contents link - Beginner Combo List
        string comboListXPath = "//*[@id='Beginner_Combo_List']";
        internal By ComboList { get => By.XPath(comboListXPath); }

        //Badge png on page
        string BeginnerbadgeXPath = "//img[contains(@alt,'Beginner.png')]";
        internal By BeginnerBadge { get => By.XPath(BeginnerbadgeXPath); }
    }
}
