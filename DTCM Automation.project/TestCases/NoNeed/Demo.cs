using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using DTCM_Automation.project.CommonFunctions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using DocumentFormat.OpenXml.CustomProperties;

namespace DTCM_Automation.project
{
   
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;

        [SetUp]
        public void CreateDriver()
        {
            this.driver = new TWebDriver();
        }

        [Test]
        public void GoogleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Bread" + Keys.Enter);

            Thread.Sleep(2000);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("bread - Google Search", driver.Title);
            driver.Quit();
        }
    }
}
//[TestClass]
//    public class Demo
//    {

//        private readonly SecureString _username = Properties.Settings.Default.OnlineUsername.ToSecureString(); //["OnlineUsername"].ToSecureString();
//        private readonly SecureString _password = Properties.Settings.Default.OnlinePassword.ToSecureString(); //["OnlinePassword"].ToSecureString();
//        private readonly Uri _xrmUri = new Uri(Properties.Settings.Default.OnlineCrmUrl.ToString()); //["OnlineCrmUrl"].ToString());


//        [TestMethod]
//        [Parallelizable]
//        public void Login()
//        {

//            using (var xrmBrowser = new Browser(TestSettings.Options))
//            {
//                xrmBrowser.Driver.WaitForPageToLoad();
//                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

//                xrmBrowser.Dialogs.CloseWarningDialog(2);


//                //companyform field = new Common.companyform();
//                //field.Addnewcompany(xrmBrowser);

               // companyform field = new Common.companyform();
                //field.Addnewcompany(xrmBrowser);


//                POIcompany poiform = new POIcompany();
//                poiform.companypoiform(xrmBrowser);


//                Addbrand brand = new Addbrand();
//                brand.addnewbrand(xrmBrowser);


//                Addbranch branch = new Addbranch();
//                branch.addnewbranch(xrmBrowser);

//            }
//        }

//             [TestMethod]
//        [Parallelizable]
//        public void Login2()
//        {

//            using (var xrmBrowser = new Browser(TestSettings.Options))
//            {
//                xrmBrowser.Driver.WaitForPageToLoad();
//                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

//                xrmBrowser.Dialogs.CloseWarningDialog(2);


//                //companyform field = new Common.companyform();
//                //field.Addnewcompany(xrmBrowser);



//                POIcompany poiform = new POIcompany();
//                poiform.companypoiform(xrmBrowser);


//                Addbrand brand = new Addbrand();
//                brand.addnewbrand(xrmBrowser);


//                Addbranch branch = new Addbranch();
//                branch.addnewbranch(xrmBrowser);

//            }

//        }
//    }

