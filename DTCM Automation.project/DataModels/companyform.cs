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
   public class companyform
    {
        public string ldv_accounttypecode= "Retailer";
        
        

        public void Addnewcompany(Browser xrmBrowser)
        {

            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");
            Thread.Sleep(10000);
            xrmBrowser.CommandBar.ClickCommand("New", "Company");
            xrmBrowser.Entity.SetValue(new OptionSet() {Name= "ldv_accounttypecode", Value=ldv_accounttypecode});

            //Cluster field
            xrmBrowser.Entity.SelectLookup("ldv_clusterid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.Search("Restaurants");
            xrmBrowser.Lookup.Add();

            //license type
            xrmBrowser.Entity.SelectLookup("ldv_licensetypeid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.Search("DED");
            xrmBrowser.Lookup.Add();

            //lisence number
            xrmBrowser.Entity.SetValue("ldv_licenseno", "3687121");

            //TID integration
            xrmBrowser.CommandBar.ClickCommand("GET TID NUMBER");
            xrmBrowser.Driver.WaitForPageToLoad();
            Thread.Sleep(5000);
            //Area
            xrmBrowser.Entity.SelectLookup("ldv_areaid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.Search("Test");
            xrmBrowser.Lookup.Add();

            xrmBrowser.CommandBar.ClickCommand("Save");
        }

    }
}
