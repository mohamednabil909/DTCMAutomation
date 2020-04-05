using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using DTCM_Automation.project.CommonFunctions;

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
