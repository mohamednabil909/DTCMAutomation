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
        

        public string SubmitRetailCalendarRequest(string Company, string eventName, Participationselection participationselection, double Product,  SponsorType  sponsorType = SponsorType.None)
        {

            portalForms.Portal_LoginAndNavigateTo(ServiceName.calendarparticipationrequest);

            portalForms.RetailCalendarParticipationRequestDescriptionAndDetailsStep(Company,eventName);

            portalForms.SelectBrandsAndBranchesStep(participationselection);

            //need to validate and add code and retaurn request id
           return portalForms.PaymentDetailsStep(Product,sponsorType);
        }

        [TestMethod]
        public void TC_SingleBrandCompany_CreateCalendarRequest_RetailerApproveFromCRM()
        {
            string requestid = SubmitRetailCalendarRequest(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.Calendar, Participationselection.Brands,Properties.Settings.Default.singlebrand1_2value.ToDouble());

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
            string requestid = SubmitRetailCalendarRequest(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.Calendar, Participationselection.Brands, Properties.Settings.Default.singlebrand1_2value.ToDouble(), SponsorType.Strategic);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                //requestid = "";
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }


        //Sendback Retail Calendar request
        [TestMethod]
        public void TC_CreateCalendarRequest_RetailerSendbackFromCRM()
        {
            string requestid = SubmitRetailCalendarRequest(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.Calendar, Participationselection.Brands, Properties.Settings.Default.singlebrand1_2value.ToDouble());

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        //Cancel Retail Calendar request
        [TestMethod]
        public void TC_CreateCalendarRequest_RetailerCancelFromCRM()
        {
            string requestid = SubmitRetailCalendarRequest(Properties.Settings.Default.singlebrand1_2, Properties.Settings.Default.Calendar, Participationselection.Brands, Properties.Settings.Default.singlebrand1_2value.ToDouble());

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }
    }
}
