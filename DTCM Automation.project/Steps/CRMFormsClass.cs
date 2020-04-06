using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
namespace DTCM_Automation.project.Steps
{
    public class CRMFormsClass
    {
        internal void CompanyCreationDecision(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision)
        {

            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = "Approve".ToLower()});
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_accounttypecode", Value = "Retailer" });
            xrmBrowser.Entity.SelectLookup("ldv_clusterid");
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();
            Thread.Sleep(5000);
            xrmBrowser.CommandBar.ClickCommand("Save");
            //throw new NotImplementedException();
        }


        public void cancelrequest(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision)
        {
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = "Cancel".ToLower()});
            xrmBrowser.Entity.SetValue("ldv_cancelreason","Cancelled");
            xrmBrowser.CommandBar.ClickCommand("Save");

        }

        public void Sendbackrequest(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision)
        {
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = "Send Back".ToLower()});
            xrmBrowser.Entity.SetValue("ldv_sendbackreason", "Send back test1234");
            xrmBrowser.CommandBar.ClickCommand("Save");

        }


    }
}
