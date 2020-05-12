using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using DTCM_Automation.project.Steps;
using static DTCM_Automation.project.CommonFunctions.Enums;

namespace DTCM_Automation.project.Steps
{
    public class CRMFormsClass
    {
        internal void CompanyCreationDecision(Browser xrmBrowser, Decisions decision,AccountType accountType)
        {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "header_process_ldv_employeedecisioncode", Value =decisionsValues[ decision] });
            if (decision == Decisions.Approve)
            {
                xrmBrowser.Entity.SetValue(new OptionSet() { Name = "header_process_ldv_accounttypecode", Value = accountType.ToString() });
                xrmBrowser.Entity.SelectLookup("header_process_ldv_clusterid");
                xrmBrowser.Lookup.SelectItem(2);
                xrmBrowser.Lookup.Add();
            }
            else if (decision == Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_cancelreason", "Test Automation Cancel Reason");
            }
            else
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_sendbackreason", "Test Automation SendBack reason");
            }

            xrmBrowser.Entity.Save();
        }


        internal void CalendarCreationDecision(Browser xrmBrowser, Decisions decision)
        {
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "header_process_ldv_employeedecisioncode", Value = decisionsValues[decision]});
          if (decision == Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_cancelreason", "Test automation Cancel reason");
                
            }
            
            else if (decision == Decisions.Sendback)
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_sendbackreason", "Test automation sendback reason");
               
            }
            xrmBrowser.Entity.Save();
        }


        internal void MarkWaived(Browser xrmBrowser)
        {
            xrmBrowser.Entity.ClickElement("ldv_invoiceid");
            xrmBrowser.Driver.WaitForPageToLoad();
            xrmBrowser.CommandBar.ClickCommand("Waive Invoice");
        }

        internal void ActivatioinCreationDecision(Browser xrmBrowser, Decisions decision)
        {
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "header_process_ldv_managerdecision", Value = decisionsValues[decision] });
            if (decision == Decisions.Cancel)
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_managercancelreason", "Test automation Cancel reason");

            }

            else if (decision == Decisions.Sendback)
            {
                xrmBrowser.Entity.SetValue("header_process_ldv_managersendbackreason_1s", "Test automation sendback reason");

            }

            xrmBrowser.Entity.Save();

            
        }

        //Create Contact from CRM
        public string CreateContactfromCRM(Browser xrmBrowser, string firstname, string lastname)
        {
            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Contacts");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("firstname", firstname);
            xrmBrowser.Entity.SetValue("lastname", lastname);
            xrmBrowser.Entity.SelectLookup("ldv_departmentid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SelectLookup("ldv_positionlevelid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(0);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_landlinenumber", "123456789");
            xrmBrowser.Entity.SetValue("mobilephone", "0123456789");
            xrmBrowser.Entity.SetValue("emailaddress1", "Test@automation.com");
            xrmBrowser.CommandBar.ClickCommand("Save");
            return firstname + lastname;
        }

        //Open invoice and waveit

        public void WaveIvoicefromCRM(Browser xrmBrowser)
        {
            //xrmBrowser.Lookup.
        }

        //Create Stratigic from CRM

        public string CreateStratigicfromCRM(Browser xrmBrowser, string stratigic_Name, string Original_Balance, string EPermit_Fees)

        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Sponsorship Balances");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name", stratigic_Name);
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_sponsorshiptypecode", Value = "0" });
            xrmBrowser.Entity.SelectLookup("ldv_calendarid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SelectLookup("ldv_offseasoncalendarid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_originalbalanceamount", Original_Balance);
            xrmBrowser.Entity.SetValue("ldv_epermitfeesamount", EPermit_Fees);
            xrmBrowser.CommandBar.ClickCommand("Save");
            return "";
        }

        //Create Sponsor from CRM

        public string CreateSponsorfromCRM(Browser xrmBrowser, string sponsor_Name, string Original_Balance, string EPermit_Fees)

        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Sponsorship Balances");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name", sponsor_Name);
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_sponsorshiptypecode", Value = "0" });
            xrmBrowser.Entity.SelectLookup("ldv_calendarid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_originalbalanceamount", Original_Balance);
            xrmBrowser.Entity.SetValue("ldv_epermitfeesamount", EPermit_Fees);
            xrmBrowser.CommandBar.ClickCommand("Save");
            return "";
        }



        //Create Calendar From CRM
        public string CreateCalendar(Browser xrmBrowser, string Calendar_Name_En, string Calendar_Name_Ar)
        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Calendars");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name_en", Calendar_Name_En);
            xrmBrowser.Entity.SetValue("ldv_name_ar", Calendar_Name_Ar);
            xrmBrowser.Entity.SelectLookup("ldv_calendartypecode");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(0);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("1/1/2021"));
            xrmBrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("1/1/2022"));
            xrmBrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("5/1/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("1/12/2021"));
            xrmBrowser.Entity.SelectLookup("ldv_pricelistid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.CommandBar.ClickCommand("Save");
            return Calendar_Name_En + Calendar_Name_Ar;
        }

        //Create OffSeason From CRM
        public string CreateOffSeason(Browser xrmBrowser, string OffSeason_Name_En, string OffSeason_Name_Ar)
        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Calendars");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name_en", OffSeason_Name_En);
            xrmBrowser.Entity.SetValue("ldv_name_ar", OffSeason_Name_Ar);
            xrmBrowser.Entity.SelectLookup("ldv_calendartypecode");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("20/2/2021"));
            xrmBrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("1/5/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("25/3/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("30/4/2021"));
            xrmBrowser.Entity.SelectLookup("ldv_pricelistid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.CommandBar.ClickCommand("Save");
            return OffSeason_Name_En + OffSeason_Name_Ar;
        }


        //Create Festival From CRM
        public string CreateFestival(Browser xrmBrowser, string Festival_Name_En, string Festival_Name_Ar)
        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Events");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name_en", Festival_Name_En);
            xrmBrowser.Entity.SetValue("ldv_name_ar", Festival_Name_Ar);
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_eventtypecode", Value = "0" });
            xrmBrowser.Entity.SelectLookup("ldv_calendarid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("20/2/2021"));
            xrmBrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("1/5/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("25/3/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("30/4/2021"));
            xrmBrowser.Entity.SetValue("ldv_descriptionen", "descriptionen1452");
            xrmBrowser.Entity.SetValue("ldv_descriptionar", "descriptionar121452");
            xrmBrowser.CommandBar.ClickCommand("Save");
            return Festival_Name_En + Festival_Name_Ar;
        }

        //Create Calendar From Activation
        public string CreateActivation(Browser xrmBrowser, string Activation_Name_En, string Activation_Name_Ar)
        {
            xrmBrowser.Navigation.OpenSubArea("Event Management", "Events");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("ldv_name_en", Activation_Name_En);
            xrmBrowser.Entity.SetValue("ldv_name_ar", Activation_Name_Ar);
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_eventtypecode", Value = "0" });
            //parent festival
            xrmBrowser.Entity.SelectLookup("ldv_parentinitiativeid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("20/2/2021"));
            xrmBrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("1/5/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("25/3/2021"));
            xrmBrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("30/4/2021"));
            xrmBrowser.Entity.SetValue("ldv_descriptionen", "descriptionen1452");
            xrmBrowser.Entity.SetValue("ldv_descriptionar", "descriptionar121452");
            xrmBrowser.CommandBar.ClickCommand("Save");
            return Activation_Name_En + Activation_Name_Ar;
        }

       

    }
}
