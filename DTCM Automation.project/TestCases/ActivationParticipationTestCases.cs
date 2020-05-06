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
        string guid;
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

            if (SelectedPromotion == Promotions.Discount || SelectedPromotion == Promotions.Sale || SelectedPromotion == Promotions.PartSale || SelectedPromotion == Promotions.Offer)
            {
                portalForms.SelectBrandsAndBranchesStep(participationselection);
                
            }

                portalForms.ActivationParticipationAddPromotion(SelectedPromotion, StartDate, EndDate);

                portalForms.AddAttachmentsStep();

                return portalForms.PaymentDetailsStep(0);
            
            
        }
        /// <summary>
        /// Add promotion of type "Discount"
        /// <summary>
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddDiscountPromotion()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent
                , Participationselection.Brands, Promotions.Discount, DateTime.Now.AddDays(2), DateTime.Now.AddDays(5));
        }

        /// <summary>
        /// Add promotion of type "Sale"
        /// <summary>
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddSalePromotion()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent
                , Participationselection.Brands, Promotions.Sale, DateTime.Now.AddDays(4), DateTime.Now.AddDays(6));
        }

        /// <summary>
        /// Add promotion of type "PartSale"
        /// <summary>
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddPartSalePromotion()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent
                , Participationselection.Brands, Promotions.PartSale,DateTime.Now.AddDays(7), DateTime.Now.AddDays(10));
        }

        /// <summary>
        /// Add promotion of type "Offer" Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_PortalAddActivationRequest_AddOfferPromotion_ApproveFromCRMRetailer_ApproveFromCRMManager()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10));

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }
       
        /// <summary>
        /// Add promotion of type "Offer" Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(5), DateTime.Now.AddDays(6));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Add promotion of type "Offer" Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddOfferfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, 
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(7), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Add promotion of type "Kiosk" Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(5), DateTime.Now.AddDays(8));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        /// <summary>
        /// Add promotion of type "Kiosk" Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, 
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(5), DateTime.Now.AddDays(8));

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Add promotion of type "Kiosk" Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddKioskfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(9), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Add promotion of type "Raffle" Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, 
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(6), DateTime.Now.AddDays(8));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        /// <summary>
        /// Add promotion of type "Raffle" Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(8), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Add promotion of type "Raffle" Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddRafflefromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(6), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Add promotion of type "Scratch and win" Approve From CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        /// <summary>
        /// Add promotion of type "Scratch and win" Sendback From CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent, 
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(7), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }
        /// <summary>
        /// Add promotion of type "Scratch and win" Cancel From CRM
        /// <summary>
        [TestMethod]
        public void TC_ActivationRequest_AddScratchandWinfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddActivationRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.ActivationEvent,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(6), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

    }
}
