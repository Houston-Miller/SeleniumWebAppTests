using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebAppTests.PageObjectModels
{
    internal class DustloopPageMillia
    
    {

        public string Url = "https://www.dustloop.com/w/GGST/Millia_Rage";
        public string CombosUrl = "https://www.dustloop.com/w/GGST/Millia_Rage/Combos";


        //tooltip info
        string frameDataTooltipXPath = "//table[@class='wikitable frame-chart-key']//span[@class='tooltip'][contains(text(),'Startup')]";
        internal By FrameDataTooltip { get => By.XPath(frameDataTooltipXPath); }

        //Millia Portrait
        string MilliaPortraitXPath = "//*[contains(@href, '/w/File:GGST_Millia_Rage_Portrait.png')]";
        internal By MilliaPortrait { get => By.XPath(MilliaPortraitXPath); }

        //Reasons to pick list
        string picklistXPath = "//*[@id='picklist']/ul/li[3]";
        internal By Picklist { get => By.XPath(picklistXPath); }

        //Combos link
        string combosXPath = "//*[@class = 'home-link__button']//*[contains(@href, '/w/GGST/Millia_Rage/Combos')]";
        internal By CombosLink { get => By.XPath(combosXPath); }

        //FrameData link
        string FrameDataXPath = "//*[@class = 'home-link__button']//*[contains(@href, '/w/GGST/Millia_Rage/Frame_Data')]";
        internal By FrameDataLink { get => By.XPath(FrameDataXPath); }

        //Hitbox info Tab
        string HitboxesID = "tab-Hitboxes-2";
        internal By HitboxTab2 { get => By.Id(HitboxesID); }

        //Hitbox Tab Frame Data Displayed
        string HitboxFramedataXPath = "//*[@class='gallerytext']//*[contains(text(),'1st Hit (frame 7-9)')]";
        internal By HitboxFrameData1 { get => By.XPath(HitboxFramedataXPath); }

        //Gridded Link Container
        string HomeLinkGridXPath = "//*[@class='home-card-container']/div[1][@class='home-link home-grid--col4']";
        internal By HomeCardContainer { get => By.XPath(HomeLinkGridXPath); }

        //frame data table legend
        internal By FrameDataTableLegend(string Entry)
        {
          return By.XPath($"//table[@class='wikitable frame-chart-key']//span[@class='tooltip'][contains(text(),'{Entry}')]");
        }
        //Frame Data Table Element
        string FrameTableXPath = "//table[@class='wikitable frame-chart-key']";
        internal By FrameTable { get => By.XPath(frameDataTooltipXPath); }

        //contents link - Beginner Combo List
        string comboListXPath = "//*[@id='Beginner_Combo_List']";
        internal By ComboList { get => By.XPath(comboListXPath); }

        //Badge png on page
        string BeginnerbadgeXPath = "//img[contains(@alt,'Beginner.png')]";
        internal By BeginnerBadge { get => By.XPath(BeginnerbadgeXPath); }

        //reveal search bar
        string SearchOptionID = "citizen-search__buttonCheckbox";
        internal By OpenSearch { get => By.Id(SearchOptionID); }

        //Search bar input
        string SearchBarOpenedXPath = "//*[@title='Search Dustloop Wiki [alt-shift-f]']";
        internal By SearchWiki { get => By.XPath(SearchBarOpenedXPath); }

        //Search bar Negative Output
        string SearchResultsNegativeXPath = "//*[@class='mw-search-nonefound']";
        internal By NoResults { get => By.XPath(SearchResultsNegativeXPath); }

        //Frame Data info link
        string HowToLinkXPath = "//*[contains(@href, '/w/Using_Frame_Data')]";
        internal By FrameDataExplained { get => By.XPath(HowToLinkXPath); }

    }
}
