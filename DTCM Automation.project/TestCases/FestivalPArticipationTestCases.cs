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
    public class FestivalParticipationTestCases
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
        /// to complete all Festival request steps, submit the request and return request id
        /// </summary>
        /// <param name="Company"></param>
        /// <param name="eventName"></param>
        /// <param name="participationselection"></param>
        /// <param name="SelectedPromotion"></param>
        public string AddFestivalRequestFromPortal(string Company, string eventName, Participationselection participationselection, Promotions SelectedPromotion, DateTime StartDate, DateTime EndDate)
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            portalForms.FestivalParticipationRequest_DetailsStep(Company, eventName, SelectedPromotion);

            if (SelectedPromotion == Promotions.Discount || SelectedPromotion == Promotions.Sale || SelectedPromotion == Promotions.PartSale || SelectedPromotion == Promotions.Offer)
            {
                portalForms.SelectBrandsAndBranchesStep(participationselection);
               
            }
                portalForms.FestivalParticipationAddPromotion(SelectedPromotion, StartDate, EndDate);
                portalForms.AddAttachmentsStep();
                return portalForms.PaymentDetailsStep(0);
            
        }
        
        /// <summary>
        /// Add promotion of type "Discount"
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddDiscountfromportal()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event
                , Participationselection.Brands, Promotions.Discount, DateTime.Now.AddDays(-4), DateTime.Now.AddDays(1));
            
        }
        
        /// <summary>
        /// Add promotion of type "Sale"
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddSaleFromportal()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event
                , Participationselection.Brands, Promotions.Sale, DateTime.Now.AddDays(2), DateTime.Now.AddDays(5));
            
        }
        
        /// <summary>
        /// Add promotion of type "PartSale"
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddPartSaleFromportal()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event
                , Participationselection.Brands, Promotions.PartSale,DateTime.Now.AddDays(8), DateTime.Now.AddDays(12));

        }
       
        /// <summary>
        /// Add promotion of type "Offer" Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(15), DateTime.Now.AddDays(17));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        /// <summary>
        /// Add promotion of type "Offer" Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(15), DateTime.Now.AddDays(17));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Add promotion of type "Offer" Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddOfferfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Offer, DateTime.Now.AddDays(12), DateTime.Now.AddDays(13));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        ///Add promotion of type "Kiosk" Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(5), DateTime.Now.AddDays(9));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }

        /// <summary>
        ///Add promotion of type "Kiosk" Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        ///Add promotion of type "Kiosk" Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddKioskfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Kiosk, DateTime.Now.AddDays(7), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        ///Add promotion of type "Raffle" Approve From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerApproveFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(5), DateTime.Now.AddDays(8));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }
        
        /// <summary>
        ///Add promotion of type "Raffle" Sendback From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(7), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }
        
        /// <summary>
        ///Add promotion of type "Raffle" Cancel From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddRafflefromportal_RetailerCancelFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Raffle, DateTime.Now.AddDays(6), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        ///Add promotion of type "Scratch and win" Approve From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerApproveFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(5), DateTime.Now.AddDays(9));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
                CRMSteps.Waveinvoice(xrmBrowser);
            }
        }
       
        /// <summary>
        ///Add promotion of type "Scratch and win" Sendback From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerSendbackFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(4), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Sendback);
            }
        }

        /// <summary>
        ///Add promotion of type "Scratch and win" Cancel From CRM
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_RetailerCancelFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(9), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Cancel);
            }
        }

        /// <summary>
        ///Add promotion of type "Scratch and win" with Sponsor company
        /// <summary>
        [TestMethod]
        public void TC_FestivlRequest_AddScratchandwinfromportal_SponsorComapny_RetailerApproveFromCRM()
        {
            string requestid = AddFestivalRequestFromPortal(Properties.Settings.Default.CompanyName, Properties.Settings.Default.Event,
                Participationselection.Brands, Promotions.Scratchandwin, DateTime.Now.AddDays(8), DateTime.Now.AddDays(10));
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Retailer, true, true, true, requestid, Decisions.Approve);
            }
        }
    }
}
