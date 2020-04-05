using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;


namespace DTCM_Automation.project.Common
{
    class POIcompany
    {
       public void companypoiform(Browser xrmBrowser) 
        {

            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Accounts");
            Thread.Sleep(10000);
            xrmBrowser.CommandBar.ClickCommand("New", "POI");
            xrmBrowser.Entity.SetValue("ldv_tradename_en","POI Comapny new");

            xrmBrowser.Entity.SelectLookup("parentaccountid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(4);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_attractionpointtiercode", Value = "1" });

            xrmBrowser.Entity.SetValue("ldv_briefdescription_en","Test 123456");

            xrmBrowser.Entity.SelectLookup("ldv_poitypeid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(4);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SelectLookup("ldv_poisubtypelevel1id");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(0);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SelectLookup("ldv_poisubtypelevel2id");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(0);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "ldv_poitimeofdaycode", Values = new string[] { "Off" } });

            

            //xrmBrowser.Entity.SetValue("ldv_poiarchetypemsc", "foodie");

            //xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_poitimerequired", Value = "1" });

            //xrmBrowser.Entity.SetValue(new OptionSet() { Name= "ldv_poitimeofdaycode", Value="2"});

            //xrmBrowser.Entity.SetValue("ldv_poipricerangemscode", "luxury");

            //xrmBrowser.Entity.SetValue("ldv_poioptimummonthmscode", "March");


            //xrmBrowser.Entity.SetValue("ldv_poiicgegroupmscode", "18-24");

            // xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = " ",Values[0] });

            //xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "preferredcontactmethodcode", Values = 1}).ToString();
            xrmBrowser.Entity.SetValue(new MultiValueOptionSet() { Name = "preferredcontactmethodcode", Values = new string[] { "Email" } });
        }


    }
}
