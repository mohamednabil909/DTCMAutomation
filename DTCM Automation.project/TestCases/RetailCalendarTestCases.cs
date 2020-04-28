using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTCM_Automation.project.CommonFunctions;
using DTCM_Automation.project.Steps;
using static DTCM_Automation.project.CommonFunctions.CommonFunctions;
using static DTCM_Automation.project.CommonFunctions.Enums;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;


namespace DTCM_Automation.project.Portal
{
    /// <summary>
    /// Summary description for RetailCalendar
    /// </summary>
    [TestClass]
    public class RetailCalendarTestCases
    {
         PortalFormsClass portalForms = new PortalFormsClass();
        CRMSteps CRMSteps = new CRMSteps();
        CommonFunctions.CommonFunctions CommonFunctions = new CommonFunctions.CommonFunctions();
        string guid, RequestId;
        /* Initialize Runs at the Start of Run/Debug of Each Test Method
     * Opens New Driver and Initializes its Wait
     */
       [TestInitialize]
        public void Portal_Initialize()
        {
            portalForms.Intialize();
        }

        /* Cleanup Runs at the End of Run/Debug of Each Test Method
         * Closes Open Driver
         */

        [TestCleanup]
        public void Portal_CleanUp()
        {
            portalForms.CloseDriver();
        }
        
        [TestMethod]
        public void TC_CreateCalendarRequest_RetailerApproveFromCRM()
        {
         string Guid=   CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.calendarparticipationrequest);

            portalForms.RetailCalendarParticipationRequestDescriptionAndDetailsStep(Properties.Settings.Default.CompanyName,Properties.Settings.Default.Calendar);

            portalForms.RetailCalendarParticipationRequest_AddBransAndBranches(Participationselection.Brands);

            //need to validate and add code and retaurn request id
            string requestid= portalForms.RetailCalendarParticipationRequest_PaymentDetailsStep(Properties.Settings.Default.singlebrand1_2,Properties.Settings.Default.singlebrand1_2value);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                //requestid = "REQ-005141";
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }


        //Approve Retail Calendar request with Stratigic Company
        [TestMethod]
        public void TC_CreateCalendarRequest_StratigicCompany_RetailerApproveFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.calendarparticipationrequest);

            portalForms.RetailCalendarParticipationRequestDescriptionAndDetailsStep(Properties.Settings.Default.CompanyStratigic, Properties.Settings.Default.Calendar);

            portalForms.RetailCalendarParticipationRequest_AddBransAndBranches(Participationselection.Brands);

            //need to validate and add code and retaurn request id
            string requestid = portalForms.RetailCalendarParticipationRequest_PaymentDetailsStep(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.singlebrand1_2value);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                //requestid = "";
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }



        [TestMethod]
        public void TC_CreateCalendarRequest_RetailerSendbackFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.calendarparticipationrequest);

            portalForms.RetailCalendarParticipationRequestDescriptionAndDetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Calendar);

            portalForms.RetailCalendarParticipationRequest_AddBransAndBranches(Participationselection.Brands);

            //need to validate and add code and retaurn request id
            string requestid = portalForms.RetailCalendarParticipationRequest_PaymentDetailsStep(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.singlebrand1_2value);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        [TestMethod]
        public void TC_CreateCalendarRequest_RetailerCancelFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.calendarparticipationrequest);

            portalForms.RetailCalendarParticipationRequestDescriptionAndDetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Calendar);

            portalForms.RetailCalendarParticipationRequest_AddBransAndBranches(Participationselection.Brands);

            //need to validate and add code and retaurn request id
            string requestid = portalForms.RetailCalendarParticipationRequest_PaymentDetailsStep(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.singlebrand1_2value);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }
    }
}
