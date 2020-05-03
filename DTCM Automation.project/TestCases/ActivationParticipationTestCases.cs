using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTCM_Automation.project.CommonFunctions;
using DTCM_Automation.project.Steps;
using static DTCM_Automation.project.CommonFunctions.CommonFunctions;
using static DTCM_Automation.project.CommonFunctions.Enums;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;

namespace DTCM_Automation.project.TestCases
{
    /// <summary>
    /// Summary description for Activation
    /// </summary>
    [TestClass]
   public class ActivationParticipationTestCases
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


        /// <summary>
        /// to complete all activation request steps, submit the request and return request id
        /// </summary>
        /// <param name="Company"></param>
        /// <param name="eventName"></param>
        /// <param name="participationselection"></param>
        /// <param name="SelectedPromotion"></param>
        public string AddActivationRequestFromPortal(string Company, string eventName, Participationselection participationselection, Promotions SelectedPromotion,DateTime StartDate,DateTime EndDate)
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_DescriptionDetailsStep(Company,eventName, SelectedPromotion);

            portalForms.SelectBrandsAndBranchesStep(participationselection);

            portalForms.ActivationParticipationAddPromotion(SelectedPromotion,StartDate,EndDate);

            portalForms.AddAttachmentsStep();

          return  portalForms.PaymentDetailsStep(0);
        }
        // Add promotion of type "Discount"
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddDiscountPromotion_ApproveFromCRMRetailer_ApproveFromCRMManager()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent
                , Participationselection.Brands, Promotions.Discount, SetDate(DateTime.Now.AddDays(40), By.Id("startdatebtn"), By.Id("startdate"), null, null));
        }

        // Add promotion of type "Sale"
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddSalePromotion_ApproveFromCRMRetailer_ApproveFromCRMManager()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Sale);
        }

        // Add promotion of type "PartSale"
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddPartSalePromotion_ApproveFromCRMRetailer_ApproveFromCRMManager()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.PartSale);
        }


        // Add promotion of type "Offer" Approve from CRM
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddOfferPromotion_ApproveFromCRMRetailer_ApproveFromCRMManager()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Offer);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        // Add promotion of type "Offer" Sendback from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Offer);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }


        // Add promotion of type "Offer" Cancel from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Offer);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }


        // Add promotion of type "Kiosk" Approve from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Kiosk);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        // Add promotion of type "Kiosk" Sendback from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Kiosk);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        // Add promotion of type "Kiosk" Cancel from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Kiosk);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        // Add promotion of type "Raffle" Approve from CRM

        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Raffle);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        // Add promotion of type "Raffle" Sendback from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Raffle);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        // Add promotion of type "Raffle" Cancel from CRM
        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Raffle);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }


        // Add promotion of type "Scratch and win" Approve From CRM

        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Scratchandwin);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        // Add promotion of type "Scratch and win" Sendback From CRM
        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Scratchandwin);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        // Add promotion of type "Scratch and win" Cancel From CRM
        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, Participationselection.Brands, Promotions.Scratchandwin);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

    }
}
