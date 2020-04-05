using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using DTCM_Automation.project.Common;

namespace DTCM_Automation.project
{
    [TestClass]
    public class Demo
    {

        private readonly SecureString _username = Properties.Settings.Default.OnlineUsername.ToSecureString(); //["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = Properties.Settings.Default.OnlinePassword.ToSecureString(); //["OnlinePassword"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(Properties.Settings.Default.OnlineCrmUrl.ToString()); //["OnlineCrmUrl"].ToString());
        HelperFunctions Help = new HelperFunctions();
        

        [TestMethod]
        public void Login()
        {
            
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                xrmBrowser.Driver.WaitForPageToLoad();
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);

                xrmBrowser.Dialogs.CloseWarningDialog(2);

                //xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");

                //Thread.Sleep(10000);
                //xrmBrowser.CommandBar.ClickCommand("New", "Company");

                //Thread.Sleep(50000);

                //xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_accounttypecode", Value = "1" });

                ////Cluster field
                //xrmBrowser.Entity.SelectLookup("ldv_clusterid" );

                //xrmBrowser.Lookup.Search("Restaurants");
                //xrmBrowser.Lookup.Add();

                ////license type
                //xrmBrowser.Entity.SelectLookup("ldv_licensetypeid");
                //xrmBrowser.Lookup.Search("DED");
                //xrmBrowser.Lookup.Add();

                ////lisence number
                //xrmBrowser.Entity.SetValue("ldv_licenseno", "3687121");

                ////TID integration
                //xrmBrowser.CommandBar.ClickCommand("GET TID NUMBER");
                //xrmBrowser.Driver.WaitForPageToLoad();

                ////Area
                //xrmBrowser.Entity.SelectLookup("ldv_areaid");
                //Thread.Sleep(5000);
                //xrmBrowser.Lookup.Search("Test");
                //xrmBrowser.Lookup.Add();

                //xrmBrowser.CommandBar.ClickCommand("Save");

                //companyform field = new Common.companyform();
                //field.Addnewcompany(xrmBrowser);


                POIcompany poiform = new POIcompany();
                poiform.companypoiform(xrmBrowser);


            }

        }
    }
}
