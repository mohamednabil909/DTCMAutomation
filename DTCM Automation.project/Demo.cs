using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;

namespace DTCM_Automation.project
{
    [TestClass]
    public class Demo
    {

        private readonly SecureString _username = Properties.Settings.Default.OnlineUsername.ToSecureString(); //["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = Properties.Settings.Default.OnlinePassword.ToSecureString(); //["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(Properties.Settings.Default.OnlineCrmUrl.ToString()); //["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void Login()
        {
            
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                xrmBrowser.Driver.WaitForPageToLoad();
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                Thread.Sleep(5000);
                xrmBrowser.Dialogs.CloseWarningDialog(2);
                xrmBrowser.ThinkTime(500);
                xrmBrowser.Navigation.OpenSubArea("Profile Managment", "Accounts");

            }

        }
    }
}
