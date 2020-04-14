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
    /// Summary description for ADDNEWPOITestCases
    /// </summary>
    [TestClass]
    public class CompanyTestcases
    {
        /// <summary>
        /// TODO in all test cases[- edit add steps that serve your test case like create company to change its custer, create create company,add brand then add a branch under it and so on
        /// - edit test case name to be more detailed
        /// - test class is to add all related test cases not only one test case
        /// - add guid and use it not use a constant number
        /// - return request id and use it on the decision step
        /// - use the exact usernot admin
        /// - add step at the last of each test case to check test case done correctly
        /// </summary>
        PortalFormsClass portalForms = new PortalFormsClass();
        CRMSteps CRMSteps = new CRMSteps();

        CommonFunctions.CommonFunctions CommonFunctions = new CommonFunctions.CommonFunctions();
        string Guid, RequestId;
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
        /// Create poi companyfrom portal then take decision approve from CRM
        /// </summary>
        [TestMethod]
        public void TC_CreatePOICompany_StackHolderApproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            

            portalForms.Portal_LoginAndNavigateTo(ServiceName.AddNewPoi);

          RequestId=  portalForms.ADDNewPOICompany(Properties.Settings.Default.CompanyName, Guid, PoiType.type1, PoiSubType.type2);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true,true, true, RequestId, Decisions.Approve);
            }
        }
        
        //Create NONDED company from portal then take decision approve from CRM
        [TestMethod]
        public void TC_CreateNONDEDCompany_StackHolderApproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId=portalForms.RegisterCompanyNonDED(Lisencetype.NONDED,Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Approve);
            }

        }

        [TestMethod]
        public void TC_CreateBrandfromportal()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.CreateBrand);
            portalForms.Fillbrandform();
        }

        [TestMethod]
        public void TC_AddGOCCompany_AddCompanyChild_AssoicateCompanyytoGOCParent()
        {
            Guid = CommonFunctions.RandomNumber();
            //TODO add steps crete Company and approve it and save its name
            //add coc and also save its name
            // after that the below steps work using the created company and goc
            
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestAssociatetogoc);

            // TODO add step create goc company then associate it as aparent
            
           RequestId= portalForms.AssociateToGOCRequest(Properties.Settings.Default.CompanyName, Properties.Settings.Default.GOCCompany, Guid);


            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, "", Decisions.Approve);
            }
        }

        /// <summary>
        /// TODO add steps - add new brand withcategory 1
        /// then create request to change category to 2
        /// return requestid and use it on decision step
        /// </summary>
        [TestMethod]
        public void TC_AddBrand_ChangeBrandCategory_ApproveRequestFromCRM()
        {

            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeBrandCategory);
            portalForms.ChangeBrandRequest(Properties.Settings.Default.Brand_Name);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, "", Decisions.Approve);
            }
        }

        /// <summary>
        /// TODO create guid on the top of the tc and use it
        /// add steps to create company of type(cluste)
        /// then add request to change its cluster
        /// return request id and use iton crm step
        /// use the exact user not admin
        /// change test case name to be moredetailed withsteps
        /// </summary>
        [TestMethod]
        public void TC_ChangeCluster_AproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeCompanyCluster);
            portalForms.ChangeClusterRequest(Properties.Settings.Default.CompanyName, Cluster.Multiplebrand, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, "", Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_ChangePOIType_AproveFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.UpdatePoiType);
            portalForms.ChangePoiTypeRequest(Properties.Settings.Default.CompanyName, PoiType.type1, PoiSubType.type2, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, "", Decisions.Approve);
            }
        }

        [TestMethod]
        public void TC_CreateCompanyDED()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            portalForms.RegisterCompanyDED(Lisencetype.DED, "588082");

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, "", Decisions.Approve);
            }
        }


    }
}
