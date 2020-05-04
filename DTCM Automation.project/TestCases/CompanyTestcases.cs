using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTCM_Automation.project.CommonFunctions;
using OpenQA.Selenium;
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
        string Guid, RequestId,RequestbrandID;

        /* Initialize Runs at the Start of Run/Debug of Each Test Method
     * Opens New Driver and Initializes its Wait
     */
        //[TestInitialize]
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
        public void TC_CreatePOICompany_POIApproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            

            portalForms.Portal_LoginAndNavigateTo(ServiceName.AddNewPoi);

          RequestId=  portalForms.ADDNewPOICompany(Properties.Settings.Default.POICompany, Guid, PoiType.type1, PoiSubType.type2);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi,true,true, true, RequestId, Decisions.Approve);
            }
        }

        /// <summary>
        /// Create poi companyfrom portal then take decision Sendback from CRM
        /// </summary>
        [TestMethod]
        public void TC_CreatePOICompany_POISendbackFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.AddNewPoi);

            RequestId = portalForms.ADDNewPOICompany(Properties.Settings.Default.POICompany, Guid, PoiType.type1, PoiSubType.type2);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Create poi companyfrom portal then take decision Cancel from CRM
        /// </summary>
        [TestMethod]
        public void TC_CreatePOICompany_POICancelFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.AddNewPoi);

            RequestId = portalForms.ADDNewPOICompany(Properties.Settings.Default.POICompany, Guid, PoiType.type1, PoiSubType.type2);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi, true, true, true, RequestId, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Create NONDED companyfrom portal then take decision approve from CRM
        /// </summary>
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
        
        /// <summary>
        /// Create NONDED companyfrom portal then take decision Sendback from CRM
        /// </summary>
        [TestMethod]
        public void TC_CreateNONDEDCompany_StackHolderSendbackFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId = portalForms.RegisterCompanyNonDED(Lisencetype.NONDED, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Sendback);
            }

        }
        
        /// <summary>
        /// Create NONDED companyfrom portal then take decision Cancel from CRM
        /// </summary>
        [TestMethod]
        public void TC_CreateNONDEDCompany_StackHolderCancelFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId = portalForms.RegisterCompanyNonDED(Lisencetype.NONDED, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Cancel);
            }

        }

        /// <summary>
         ///Create Branch from Portal Mall
        /// </summary>
        [TestMethod]
        public void TC_CreateBranchfromportal_Mall()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.CompanyManagement3);
            portalForms.Fillbranchform_Mall();
        }

        /// <summary>
        ///Create Branch from Portal StandAlone
        /// </summary>
        [TestMethod]
        public void TC_CreateBranchfromportal_Standalone()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.CompanyManagement3);
            portalForms.Fillbranchform_Standalone();
        }
        
        /// <summary>
        /// Create GOCRequest portal then take decision Approve from CRM
        /// </summary>
        [TestMethod]
        public void TC_AddGOCCompany_AddCompanyChild_AssoicateCompanyytoGOCParent_StackHolderApproveFromCRM()
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
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Approve);
            }
        }
        
        /// <summary>
        /// Create GOCRequest portal then take decision Sendback from CRM
        /// </summary>
        [TestMethod]
        public void TC_AddGOCCompany_AddCompanyChild_AssoicateCompanyytoGOCParent_StackHolderSendbackFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            

            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestAssociatetogoc);


            RequestId = portalForms.AssociateToGOCRequest(Properties.Settings.Default.CompanyName, Properties.Settings.Default.GOCCompany, Guid);


            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Sendback);
            }
        }
        
        /// <summary>
        /// Create GOCRequest portal then take decision Cancel from CRM
        /// </summary>
        [TestMethod]
        public void TC_AddGOCCompany_AddCompanyChild_AssoicateCompanyytoGOCParent_StackHolderCancelFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestAssociatetogoc);

            RequestId = portalForms.AssociateToGOCRequest(Properties.Settings.Default.CompanyName, Properties.Settings.Default.GOCCompany, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Stackholder, true, true, true, RequestId, Decisions.Cancel);
            }
        }


        /// <summary>
        /// TODO add steps - add new brand withcategory 1
        /// then create request to change category to 2
        /// return requestid and use it on decision step
        /// </summary>
        [TestMethod]
        public void TC_AddBrand_ChangeBrandCategory_RetailerApproveFromCRM()
        {
            portalForms.Portal_LoginAndNavigateTo(ServiceName.CompanyManagement3);
            var brandName= portalForms.FillBrandForm("Test Brand English", "Food & Beverage","");
            portalForms.GoToUrl("http://ld-iis-dtcm.cloudapp.net/en/RequestChangeBrandCategory");
            RequestId = portalForms.ChangeBrandRequest(brandName);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        /// <summary>
        /// Create ChangebrandCategory Request from portal then take decision Sendback from CRM
        /// </summary>
        [TestMethod]
        public void TC_AddBrand_ChangeBrandCategory_RetailerSendbackFromCRM()
        {

            portalForms.Portal_LoginAndNavigateTo(ServiceName.CompanyManagement3);
            var brandName = portalForms.FillBrandForm("Test Brand English", "Food & Beverage", "");

            //  portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeBrandCategory);
            portalForms.GoToUrl("http://ld-iis-dtcm.cloudapp.net/en/RequestChangeBrandCategory");
           
            RequestId = portalForms.ChangeBrandRequest(brandName);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Create ChangebrandCategory Request from portal then take decision Cancel from CRM
        /// </summary>
        [TestMethod]
        public void TC_AddBrand_ChangeBrandCategory_RetailerCancelFromCRM()
        {

            portalForms.Portal_LoginAndNavigateTo(ServiceName.CompanyManagement3);
            String brandName = portalForms.FillBrandForm("Test Brand English", "Food & Beverage", "");
              portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeBrandCategory);
           // Driver.Navigate().GoToUrl("http://ld-iis-dtcm.cloudapp.net/en/RequestChangeBrandCategory");
            RequestId = portalForms.ChangeBrandRequest(brandName);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
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
        public void TC_ChangeCluster_RetailerApproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeCompanyCluster);
           
            RequestId= portalForms.ChangeClusterRequest(Properties.Settings.Default.CompanyName, Cluster.Multiplebrand, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Approve);
            }
        }

        /// <summary>
        /// Create ChangeCluster Request from portal then take decision Sendback from CRM
        /// </summary>
        [TestMethod]
        public void TC_ChangeCluster_RetailerSendbackFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeCompanyCluster);
            RequestId = portalForms.ChangeClusterRequest(Properties.Settings.Default.CompanyName, Cluster.Multiplebrand, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Create ChangeCluster Request from portal then take decision Cancel from CRM
        /// </summary>
        [TestMethod]
        public void TC_ChangeCluster_ReatilerCancelFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();
            portalForms.Portal_LoginAndNavigateTo(ServiceName.RequestChangeCompanyCluster);
            RequestId = portalForms.ChangeClusterRequest(Properties.Settings.Default.CompanyName, Cluster.Multiplebrand, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Retailer, true, true, true, RequestId, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Create POICompany Request from portal then take decision Approve from CRM
        /// </summary>
        [TestMethod]
        public void TC_ChangePOIType_POIApproveFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.UpdatePoiType);
           RequestId= portalForms.ChangePoiTypeRequest(Properties.Settings.Default.CompanyName, PoiType.type1, PoiSubType.type2, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi, true, true, true, RequestId, Decisions.Approve);
            }
        }
        
        /// <summary>
        /// Create POICompany Request from portal then take decision Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_ChangePOIType_POISendbackFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.UpdatePoiType);
            RequestId = portalForms.ChangePoiTypeRequest(Properties.Settings.Default.CompanyName, PoiType.type1, PoiSubType.type2, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi, true, true, true, RequestId, Decisions.Sendback);
            }
        }
        
        /// <summary>
        /// Create POICompany Request from portal then take decision Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_ChangePOIType_POICancelFromCRM()
        {
            string Guid = CommonFunctions.RandomNumber();

            portalForms.Portal_LoginAndNavigateTo(ServiceName.UpdatePoiType);
            RequestId = portalForms.ChangePoiTypeRequest(Properties.Settings.Default.CompanyName, PoiType.type1, PoiSubType.type2, Guid);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Poi, true, true, true, RequestId, Decisions.Cancel);
            }
        }

        /// <summary>
        /// Create DEDCompany Request from portal then take decision Approve from CRM
        /// <summary>
        [TestMethod]
        public void TC_CreateCompanyDED_StackHolderApproveFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId= portalForms.RegisterCompanyDED(Lisencetype.DED, Properties.Settings.Default.lisenceNumber);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, RequestId, Decisions.Approve);
            }
        }

        /// <summary>
        /// Create DEDCompany Request from portal then take decision Sendback from CRM
        /// <summary>
        [TestMethod]
        public void TC_CreateCompanyDED_StackHolderSendbackFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId = portalForms.RegisterCompanyDED(Lisencetype.DED, Properties.Settings.Default.lisenceNumber);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, RequestId, Decisions.Sendback);
            }
        }

        /// <summary>
        /// Create DEDCompany Request from portal then take decision Cancel from CRM
        /// <summary>
        [TestMethod]
        public void TC_CreateCompanyDED_StackHolderCancelFromCRM()
        {
            Guid = CommonFunctions.RandomNumber();


            portalForms.Portal_LoginAndNavigateTo(ServiceName.accountregistration);
            RequestId = portalForms.RegisterCompanyDED(Lisencetype.DED, Properties.Settings.Default.lisenceNumber);

            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                CRMSteps.CompanyCreationDecisionStep(xrmBrowser, Users.Admin, true, true, true, RequestId, Decisions.Cancel);
            }
        }


    }
}
