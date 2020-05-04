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

        /// <summary>
        /// Get activation link from activation sent mail
        /// </summary>
        /// <param name="xrmBrowser"></param>
        /// <param name="User"></param>
        /// <param name="RequestNumber"></param>
        /// <returns></returns>
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

        
        //open invoice and wave invoice

       internal void Waveinvoice(Browser xrmBrowser)

        {
            CRMFormsClass.WaveIvoicefromCRM(xrmBrowser);
        }
        
        //Create contact
        internal void CreatContact(Browser xrmBrowser)
        {
            CRMFormsClass.CreateContactfromCRM(xrmBrowser, "Test", "Automation");
        }

        //Create Stratigic
        internal void CreateStratigic(Browser xrmBrowser)
        {
            CRMFormsClass.CreateStratigicfromCRM(xrmBrowser, "New Automation Stratigic", "10000", "10");
        }

        //Create Sponsor
        internal void CreateSponsor(Browser xrmBrowser)
        {
            CRMFormsClass.CreateStratigicfromCRM(xrmBrowser, "New Automation Sponsor", "10000", "10");
        }

        //Create Calendar
        internal void CreateCalendar(Browser xrmBrowser)
        {
            CRMFormsClass.CreateCalendar(xrmBrowser, "New Automation Calendar", "كالندر");
        }

        //Create OffSeason
        internal void CreateOffSeason(Browser xrmBrowser)
        {
            CRMFormsClass.CreateOffSeason(xrmBrowser, "New Automation Offseason", "اوف سيزون اتوميشن");
        }


        //Create Festival
        internal void CreateFestival(Browser xrmBrowser)
        {
            CRMFormsClass.CreateFestival(xrmBrowser, "New Automation Festival", "فيستيفال اتوميشن");
        }


        //Create Activation
        internal void CreateActivation(Browser xrmBrowser)
        {
            CRMFormsClass.CreateFestival(xrmBrowser, "New Automation Activation", "اكتيفيشن اتوميشن");
        }

    }
}
