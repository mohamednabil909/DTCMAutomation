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
    class Addbrand
    {
        public void addnewbrand(Browser xrmBrowser)
        {

            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");
            Thread.Sleep(10000);
            xrmBrowser.CommandBar.ClickCommand("New", "brand");
            xrmBrowser.Driver.WaitForPageToLoad();
            Thread.Sleep(10000);
            xrmBrowser.Entity.SetValue("ldv_tradename_en", "brand new");

            xrmBrowser.Entity.SelectLookup("parentaccountid");
            xrmBrowser.Lookup.SelectItem(4);
            xrmBrowser.Lookup.Add();


            xrmBrowser.Entity.SelectLookup("ldv_categoryid");
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();

            xrmBrowser.CommandBar.ClickCommand("Save");

        }




    }
}
