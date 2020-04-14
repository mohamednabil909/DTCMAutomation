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

namespace DTCM_Automation.project
{
    [TestFixture]
    public class AllTestByID
    {
        // string driversDirectory = Environment.GetEnvironmentVariable("ChromeWebDriver");
       public IWebDriver _currentBrowser = new ChromeDriver("D:\\atomation\\DTCMAutomationSolution\\DTCM Automation.project\\bin\\Debug");
    }
        [TestFixture]
        [Parallelizable]
        public class CheckSearch
        {
            AllTestByID newCopy = new AllTestByID();

            [Test]
            [Parallelizable]
            public void DownloadReport()
            {
                newCopy._currentBrowser.Navigate().GoToUrl("https://www.google.com/");
                newCopy._currentBrowser.FindElement(By.XPath("//input[@id='lst-ib']")).SendKeys("Find something");
            }
              }

        [TestFixture]
        [Parallelizable]
        public class CheckSearch2
        {
            AllTestByID newCopy = new AllTestByID();

            [Test]
        [Parallelizable]
        public void DownloadReport()
            {
                newCopy._currentBrowser.Navigate().GoToUrl("https://www.google.com/");
                newCopy._currentBrowser.FindElement(By.XPath("//input[@id='lst-ib']")).SendKeys("Find something");
            }
        }
    
        [TestClass]
    public class Demo
    {

        private readonly SecureString _username = Properties.Settings.Default.OnlineUsername.ToSecureString(); //["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = Properties.Settings.Default.OnlinePassword.ToSecureString(); //["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(Properties.Settings.Default.OnlineCrmUrl.ToString()); //["OnlineCrmUrl"].ToString());


        [TestMethod]
        [Parallelizable]
        public void Login()
        {

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                xrmBrowser.Driver.WaitForPageToLoad();
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

                xrmBrowser.Dialogs.CloseWarningDialog(2);


                //companyform field = new Common.companyform();
                //field.Addnewcompany(xrmBrowser);



                POIcompany poiform = new POIcompany();
                poiform.companypoiform(xrmBrowser);


                Addbrand brand = new Addbrand();
                brand.addnewbrand(xrmBrowser);


                Addbranch branch = new Addbranch();
                branch.addnewbranch(xrmBrowser);

            }
        }

             [TestMethod]
        [Parallelizable]
        public void Login2()
        {

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                xrmBrowser.Driver.WaitForPageToLoad();
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

                xrmBrowser.Dialogs.CloseWarningDialog(2);


                //companyform field = new Common.companyform();
                //field.Addnewcompany(xrmBrowser);



                POIcompany poiform = new POIcompany();
                poiform.companypoiform(xrmBrowser);


                Addbrand brand = new Addbrand();
                brand.addnewbrand(xrmBrowser);


                Addbranch branch = new Addbranch();
                branch.addnewbranch(xrmBrowser);

            }

        }
    }
}
