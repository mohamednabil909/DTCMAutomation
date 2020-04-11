using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTCM_Automation.project.CommonFunctions;
using DTCM_Automation.project.Steps;
using static DTCM_Automation.project.CommonFunctions.CommonFunctions;
using static DTCM_Automation.project.CommonFunctions.Enums;

namespace DTCM_Automation.project.Portal
{
    /// <summary>
    /// Summary description for RetailCalendar
    /// </summary>
    [TestClass]
    public class RetailCalendarTestCases
    {
         PortalFormsClass portalForms = new PortalFormsClass();
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
        
        [TestMethod]// TODO hya test method wala fara7 el 3omda e3ml l kol 7aga el test method bta3etha w mat3mlsh keda tani e7na mosh bnl3ab
        public void TC_CreateCalendarRequest_GOCCompany_CheckPO()
        {
         string Guid=   CommonFunctions.RandomNumber();
            //portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RetailCalendar);
            //portalForms.RetailCalendarParticipationRequest(Driver);




            //Register New Company DED
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.accountregistration);
            portalForms.RegisterCompanyDED(  Lisencetype.DED, "45874122DCwd");

            //Register New Company NONDED
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.accountregistration);
            portalForms.RegisterCompanyNonDED(  Lisencetype.NONDED);


            //Add New POI
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.AddNewPoi);
            portalForms.ADDNewPOICompany(  "katry", "123", PoiType.type1, PoiSubType.type2); //CompanyNAme :elmfrod el company elly created


            //Associate Company to GOC
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.RequestAssociatetogoc);
            portalForms.AssociateToGOCRequest(   "katry", "Aya GOC", "47524"); //parent GOC yt3m enum!?


            //Change brand catgory
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.RequestChangeBrandCategory);
            portalForms.ChangeBrandRequest(  "katry"); //Company name that created brdo

            //change cluster
            portalForms.Portal_LoginAndNavigateTo(  ServiceName.RequestChangeCompanyCluster);
            portalForms.ChangeClusterRequest(  "Katry", Cluster.Multiplebrand, "4785");

            //change poi type

            portalForms.Portal_LoginAndNavigateTo(ServiceName.UpdatePoiType);
            portalForms.ChangePoiTypeRequest(  "Katry", PoiType.type1, PoiSubType.type2, "5472");

        }
    }
}
