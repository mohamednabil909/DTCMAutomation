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
    class Addbranch
    {
        public void addnewbranch(Browser xrmBrowser)

        {
            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");
            Thread.Sleep(10000);
            xrmBrowser.CommandBar.ClickCommand("New", "branch");
            xrmBrowser.Driver.WaitForPageToLoad();
            Thread.Sleep(10000);
            xrmBrowser.Entity.SetValue(new OptionSet() {Name= "ldv_branchtypecode", Value= "Mall" });

            xrmBrowser.Entity.SelectLookup("ldv_mallid");
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue("ldv_licenseno", "148det");

            xrmBrowser.Entity.SelectLookup("parentaccountid");
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();

            xrmBrowser.CommandBar.ClickCommand("Save");

        }

    }
}
