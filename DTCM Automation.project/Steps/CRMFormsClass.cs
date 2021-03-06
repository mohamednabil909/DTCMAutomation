﻿using System;
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
        internal void CompanyCreationDecision(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision,CommonFunctions.CommonFunctions.AccountType accountType)
        {
            if (decision == CommonFunctions.CommonFunctions.Decisions.Approve)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = decision.ToString() });
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_accounttypecode", Value = accountType.ToString() });
                xrmBrowser.Entity.SelectLookup("ldv_clusterid");
                xrmBrowser.Lookup.SelectItem(2);
                xrmBrowser.Lookup.Add();
                Thread.Sleep(5000);
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else if (decision == CommonFunctions.CommonFunctions.Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = decision.ToString() });
                xrmBrowser.Entity.SetValue("ldv_cancelreason", "Cancelled");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else
            {
                xrmBrowser.Entity.SetValue("ldv_sendbackreason", "Send back test1234");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            
            //throw new NotImplementedException();
        }


        internal void CalendarCreationDecision(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision)
        {
            if (decision == CommonFunctions.CommonFunctions.Decisions.Approve)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = decision.ToString() });
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else if (decision == CommonFunctions.CommonFunctions.Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_employeedecisioncode", Value = decision.ToString()});
                xrmBrowser.Entity.SetValue("ldv_cancelreason", "Cancelled");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else
            {
                xrmBrowser.Entity.SetValue("ldv_sendbackreason", "Send back test1234");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }

            //throw new NotImplementedException();
        }


        internal void ActivatioinCreationDecision(Browser xrmBrowser, CommonFunctions.CommonFunctions.Decisions decision)
        {
            if (decision == CommonFunctions.CommonFunctions.Decisions.Approve)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_managerdecision", Value = decision.ToString() });
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else if (decision == CommonFunctions.CommonFunctions.Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_managerdecision", Value = decision.ToString() });
                xrmBrowser.Entity.SetValue("ldv_managercancelreason", "Cancelled");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }
            else
            {
                xrmBrowser.Entity.SetValue("ldv_managersendbackreason_1s", "Send back test1234");
                xrmBrowser.CommandBar.ClickCommand("Save");
            }

            //throw new NotImplementedException();
        }

        
    }
}
