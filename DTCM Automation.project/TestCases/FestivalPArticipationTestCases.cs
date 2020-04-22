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
    /// Summary description for Festival
    /// </summary>
    [TestClass]
    public class FestivalPArticipationTestCases
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
        public void TC_FestivlRequest_AddDiscountfromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);
    
            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName,Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Discount);

            portalForms.FestivalAttachmentsStep();
            
            string requestid=portalForms.FestivalParticipationRequest_PaymentDetailsStep();
            
        }
        
        // Add promotion of type "Sale"
        [TestMethod]
        public void TC_FestivlRequest_AddSaleFromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);
            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Sale);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            
        }

        // Add promotion of type "PartSale"
        [TestMethod]
        public void TC_FestivlRequest_AddPartSaleFromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);
            
            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.PartSale);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();
            
        }

       // Add promotion of type "Offer"
        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerSendbaclFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions.Offer);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }

        
        //Add promotion of type "Kiosk"
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);
            
            portalForms.FestivalParticipationAddKiosk(Promotions.Kiosk);

            portalForms.FestivalAttachmentsStepKiosk();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }
        
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddKiosk(Promotions.Kiosk);

            portalForms.FestivalAttachmentsStepKiosk();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }
        
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepkiosk(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddKiosk(Promotions.Kiosk);

            portalForms.FestivalAttachmentsStepKiosk();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }


        //Add promotion of type "Raffle"
        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddRaffle(Promotions.Raffle);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddRaffle(Promotions.Raffle);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepRaffle(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddRaffle(Promotions.Raffle);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }


        //Add promotion of type "Scratch and win"
        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }


        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerSendbackFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }


        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerCancelFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStepScratchandwin(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event);

            portalForms.FestivalParticipationAddScratchandWin(Promotions.Scratchandwin);

            portalForms.FestivalAttachmentsStep();

            string requestid = portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }

    }
}
