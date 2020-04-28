using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTCM_Automation.project.CommonFunctions;
using DTCM_Automation.project.DataModels;
using System.Threading;

namespace DTCM_Automation.project.Steps
{
   public class CRMSteps
    {

        CommonFunctions.CommonFunctions commonFunctions = new CommonFunctions.CommonFunctions();
        CRMFormsClass CRMFormsClass = new CRMFormsClass();

        public string OpenActivationEmail(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, string RequestNumber)
        {
            ProfileManagement Profile = new ProfileManagement();

            commonFunctions.CRMLoginAs(xrmBrowser, User);
            return Profile.GetActivationLink(xrmBrowser, RequestNumber);
            
        }


        public bool CompanyCreationDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);

                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);
                // Done
               CRMFormsClass.CompanyCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve, CommonFunctions.CommonFunctions.AccountType.Retailer);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                       commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                       commonFunctions.CRMLoginAs(xrmBrowser1, User); 
                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                    // Done
                    CRMFormsClass.CompanyCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve, CommonFunctions.CommonFunctions.AccountType.Retailer);
                }
            }

            return checkStageIsCorrect;
        }


        public bool EventFirstDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                // Done
                CRMFormsClass.CalendarCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                        commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                        commonFunctions.CRMLoginAs(xrmBrowser1, User);
                        commonFunctions.OpenRequest(xrmBrowser1, "Profile Management", "Queue Items", "Items available to work on");
                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Employeedecision);

                    // Done
                    CRMFormsClass.CalendarCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
                }
            }

            return checkStageIsCorrect;
        }
        
        public bool ActivatioinCreationDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Managerdecision);

                // Done
                CRMFormsClass.ActivatioinCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                        commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                        commonFunctions.CRMLoginAs(xrmBrowser1, User);
                        // TODO navigate to requests and open request using requestid parameter
                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Managerdecision);

                    // Done
                    CRMFormsClass.ActivatioinCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
                }
            }

            return checkStageIsCorrect;
        }

        //Create Contact from CRM
        public string CreateContactfromCRM(Browser xrmBrowser,string firstname,string lastname)
        {
            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Contacts");
            xrmBrowser.CommandBar.ClickCommand("New");
            xrmBrowser.Entity.SetValue("firstname",firstname);
            xrmBrowser.Entity.SetValue("lastname", lastname);
            xrmBrowser.Entity.SelectLookup("ldv_departmentid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SelectLookup("ldv_positionlevelid");
            Thread.Sleep(5000);
            xrmBrowser.Lookup.SelectItem(0);
            xrmBrowser.Lookup.Add();
            xrmBrowser.Entity.SetValue("ldv_landlinenumber","123456789");
            xrmBrowser.Entity.SetValue("mobilephone", "0123456789");
            xrmBrowser.Entity.SetValue("emailaddress1", "Test@automation.com");
            xrmBrowser.CommandBar.ClickCommand("Save");
            return firstname + lastname;
        }
        

        //Create Stratigic from CRM

       public string CreateStratigicfromCRM(Browser xrmBrowser,string stratigic_Name, string Original_Balance , string EPermit_Fees)

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
        public string CreateCalendar(Browser xrmBrowser,string Calendar_Name_En, string Calendar_Name_Ar)
        {
            xrmBrowser.Navigation.OpenSubArea("Event Management","Calendars");
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
            return Calendar_Name_En + Calendar_Name_Ar ;
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
