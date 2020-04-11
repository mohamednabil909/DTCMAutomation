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
    class POIcompany
    {
       public void companypoiform(Browser xrmBrowser) 
        {

            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");
            Thread.Sleep(10000);
            xrmBrowser.CommandBar.ClickCommand("New", "POI");
            xrmBrowser.Driver.WaitForPageToLoad();
            Thread.Sleep(10000);
            xrmBrowser.Entity.SetValue("ldv_tradename_en","POI Comapny new");

            xrmBrowser.Entity.SelectLookup("parentaccountid");
            Thread.Sleep(10000);
            xrmBrowser.Driver.WaitForPageToLoad();
            xrmBrowser.Lookup.SelectItem(4);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_attractionpointtiercode", Value = "1" });

            xrmBrowser.Entity.SetValue("ldv_briefdescription_en","Test 123456");

            xrmBrowser.Entity.SelectLookup("ldv_poitypeid");
            Thread.Sleep(10000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Driver.WaitForPageToLoad();
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SelectLookup("ldv_poisubtypelevel1id");
            Thread.Sleep(10000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Driver.WaitForPageToLoad();
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poitimeofdaycode", Values = new string[] { "Off" } });

            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poiarchetypemsc", Values = new string[] { "4" } });

            

            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_poitimerequired", Value = "1" });

            xrmBrowser.Entity.SetValue(new OptionSet() { Name= "ldv_poitimeofdaycode", Value="2"});

            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poipricerangemscode", Values = new string[] { "6" } });

            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poioptimummonthmscode", Values = new string[] { "3" } });

            
            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poiicgegroupmscode", Values = new string[] { "3" } });


            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poitravelpartytyp", Values = new string[] { "1" } });


            xrmBrowser.CommandBar.ClickCommand("Save");
        }


    }
}
