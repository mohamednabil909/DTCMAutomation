﻿using System;
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
       // [TestInitialize]
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
        public void TC_FestivlRequest_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.initiativeparticipationrequest);

            
            portalForms.FestivalParticipationRequest_DetailsStep(Properties.Settings.Default.CompanyName,Properties.Settings.Default.Event);

            portalForms.FestivalParticipationRequest_SelectBransAndBranches(Participationselection.Brands);

            portalForms.FestivalParticipationAddDiscount_Sale_PartSale(Promotions.Discount);

            portalForms.FestivalAttachmentsStep();

            portalForms.FestivalParticipationRequest_PaymentDetailsStep();

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.EventFirstDecisionStep(xrmBrowser, Users.Admin, true, true, true, "", Decisions.Approve);
            }
        }
    }
}