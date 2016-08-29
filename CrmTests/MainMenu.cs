using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace CrmTests
{
    class MainMenu
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "Tab1")]
        private IWebElement mainTile;
        [FindsBy(How = How.Id, Using = "Tab1")]
        private IWebElement mainTileCheck;

        [FindsBy(How = How.Id, Using = "CS")]
        private IWebElement caseTile;
        [FindsBy(How = How.Id, Using = "TabCS")]
        private IWebElement caseTileCheck;

        [FindsBy(How = How.Id, Using = "CRE_area")]
        private IWebElement creConfigTile;
        [FindsBy(How = How.Id, Using = "TabCRE_area")]
        private IWebElement creConfigTileCheck;

        [FindsBy(How = How.Id, Using = "Settings")]
        private IWebElement settingsTile;
        [FindsBy(How = How.Id, Using = "TabSettings")]
        private IWebElement settingsTileCheck;

        [FindsBy(How = How.Id, Using = "HLP")]
        private IWebElement helpTile;
        [FindsBy(How = How.Id, Using = "TabHLP")]
        private IWebElement helpTileCheck;

        public enum MainTiles { MAIN, CASE, CONFIG, SETTINGS, HELP };
        private Dictionary<MainTiles, IWebElement> tiles;
        private Dictionary<MainTiles, IWebElement> tilesCheck;

        public MainMenu(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            this.tiles = new Dictionary<MainTiles, IWebElement>
            {
                { MainTiles.MAIN, mainTile },
                { MainTiles.CASE, caseTile },
                { MainTiles.CONFIG, creConfigTile },
                { MainTiles.SETTINGS, settingsTile },
                { MainTiles.HELP, helpTile },
            };
            this.tilesCheck = new Dictionary<MainTiles, IWebElement>
            {
                { MainTiles.MAIN, mainTileCheck },
                { MainTiles.CASE, caseTileCheck },
                { MainTiles.CONFIG, creConfigTileCheck },
                { MainTiles.SETTINGS, settingsTileCheck },
                { MainTiles.HELP, helpTileCheck },
            };
        }

        public void clickTile(MainTiles theTile)
        {
            setWaitInSeconds(10);
            // Hover over main tile so that subtiles becommes visible and clickable
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainTile).Perform();
            // click the now visible tile
            this.tiles[theTile].Click();
            setWaitInSeconds(15);
            bool xx = this.tilesCheck[theTile].Displayed;
        }
        /*
        public void clickCaseTile()
        {
            setWaitInSeconds(10);
            // Hover over main tile so that subtiles becommes visible and clickable
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainTile).Perform();
            // click the now visible tile
            caseTile.Click();
        }
        public void clickCreConfigTile()
        {
            setWaitInSeconds(10);
            // Hover over main tile so that subtiles becommes visible and clickable
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainTile).Perform();
            // click the now visible tile
            creConfigTile.Click();
        }
        public void clickSettingsTile()
        {
            setWaitInSeconds(10);
            // Hover over main tile so that subtiles becommes visible and clickable
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainTile).Perform();
            // click the now visible tile
            settingsTile.Click();
        }
        public void clickHelpTile()
        {
            setWaitInSeconds(10);
            // Hover over main tile so that subtiles becommes visible and clickable
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainTile).Perform();
            // click the now visible tile
            helpTile.Click();
        }
        */

        private void setWaitInSeconds(int nbrOfSec)
        {
            System.TimeSpan waitTime = new System.TimeSpan(0, 0, nbrOfSec);
            driver.Manage().Timeouts().ImplicitlyWait(waitTime);
        }
    }
}
