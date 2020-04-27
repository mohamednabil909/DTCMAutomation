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

        // Add promotion of type "Discount"
        [TestMethod]
        public void TC_ActivationRequest_AddDiscountfromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName,Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Discount);

            portalForms.ActivationAttachmentsStep();

            portalForms.ActivationParticipationRequest_PaymentDetailsStep();   
        }

        // Add promotion of type "Sale"
        [TestMethod]
        public void TC_ActivationRequest_AddSalefromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);
            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);
            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Sale
);
            portalForms.ActivationAttachmentsStep();
            portalForms.ActivationParticipationRequest_PaymentDetailsStep();
        }

        // Add promotion of type "PartSale"
        [TestMethod]
        public void TC_ActivationRequest_AddPartSalefromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);
            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);
            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.PartSale);
            portalForms.ActivationAttachmentsStep();
            portalForms.ActivationParticipationRequest_PaymentDetailsStep();
        }


        // Add promotion of type "Offer"
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);
            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);
            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);
            portalForms.ActivationAttachmentsStep();
            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);
            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);
            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);
            portalForms.ActivationAttachmentsStep();
            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }
        
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.SubInitiativeParticipationReq);

            portalForms.ActivationParticipationRequest_Description_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);
            portalForms.ActivationParticipationRequest_SelectBransAndBranches(Participationselection.Brands);
            portalForms.ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);
            portalForms.ActivationAttachmentsStep();
            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }


        // Add promotion of type "Kiosk"
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddKiosk(Promotions.Kiosk);

            portalForms.ActivationAttachmentsStepKiosk();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddKiosk(Promotions.Kiosk);

            portalForms.ActivationAttachmentsStepKiosk();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddKiosk(Promotions.Kiosk);

            portalForms.ActivationAttachmentsStepKiosk();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }

        // Add promotion of type "Raffle"

        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddRaffle(Promotions.Raffle);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }


        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddRaffle(Promotions.Raffle);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }


        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddRaffle(Promotions.Raffle);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }


        // Add promotion of type "Scratch and win"

        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.ActivationParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent);

            portalForms.ActivationParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.ActivationAttachmentsStep();

            string requestid = portalForms.ActivationParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }

    }
}
