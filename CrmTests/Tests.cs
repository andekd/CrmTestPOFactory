using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;

namespace CrmTests
{
    [TestFixture("Systemtest")]
    public class Tests
    {
        public enum Envs { Systemtest, Acceptanstest };
        static Dictionary<Envs, string> urls = new Dictionary<Envs, string>
        {
            {Envs.Systemtest, "http://crmtst.riksbyggen.intra/NASTEST" },
            {Envs.Acceptanstest, "http://crmat.riksbyggen.intra/CRMAT" }
        };

        static string currentEnvString;
        static string pathToTestData;
        static Envs currentEnv;
        static IWebDriver driverFF;

        public Tests(string env)
        {
            currentEnvString = env;
            // get path to project/application
            string execPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            // get path for namespcae
            string nameSpacePath = Directory.GetParent(Directory.GetParent(execPath).FullName).FullName;
            // get path to Testdata folder
            pathToTestData = nameSpacePath + @"\TestData\";
        }
        [SetUp]
        public void generalSetUP()
        {
            currentEnv = Envs.Acceptanstest;
            if (currentEnvString == Envs.Systemtest.ToString())
            {
                currentEnv = Envs.Systemtest;
            }
        }

        [SetUp]
        public void fireFoxSetUp()
        {
            // get path to firefox profile folder
            string testProfileFolder = pathToTestData + "g2p48piz.crmsystest";
            //Create ff-profile based on a previous saved profile with saved credentials for systemtest env.
            FirefoxProfile testProfile = new FirefoxProfile(testProfileFolder);
            // Firefox 3:d party addon for auto-login for saved user, needs to be added to ff-profile.
            //testProfile.AddExtension(Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Mozilla\Firefox\Profiles\g2p48piz.crmsystest\extensions\autoauth@efinke.com.xpi");
            testProfile.AddExtension(testProfileFolder + @"\extensions\autoauth@efinke.com.xpi");
            driverFF = new FirefoxDriver(testProfile);
            driverFF.Manage().Window.Maximize();
        }

        public void goToStartPage()
        {
            // Go to startpage for crm current env
            string testUrl = urls[currentEnv];
            driverFF.Navigate().GoToUrl(testUrl);
            // Wait for top menu to be loaded
            driverFF.FindElement(By.Id("crmTopBar"), 15);
        }

        [TestCase()]
        public void checkMainTiles()
        {
            goToStartPage();
            MainMenu myMain = new MainMenu(driverFF);
            //myMain.clickCreConfigTile();
            //myMain.clickSettingsTile();
            //myMain.clickHelpTile();
            //myMain.clickCaseTile();
            myMain.clickTile(MainMenu.MainTiles.CONFIG);
            myMain.clickTile(MainMenu.MainTiles.HELP);
            myMain.clickTile(MainMenu.MainTiles.SETTINGS);
            myMain.clickTile(MainMenu.MainTiles.CASE);
        }

        [TearDown]
        public void closeResources()
        {
            driverFF.Close();
        }
    }
}
