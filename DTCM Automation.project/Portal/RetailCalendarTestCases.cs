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
    public class RetailCalendarTestCases: TestHelper
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
            Driver = IsDriverOpen() ? Driver : Initialize(Browser.chrome, out Wait);
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
        public void TC_CreateCalendarRequest_GOCCompany_CheckPO()
        {
         string Guid=   CommonFunctions.RandomNumber();
            //portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RetailCalendar);
            //portalForms.RetailCalendarParticipationRequest(Driver);

            //Registeration
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.Register);
            portalForms.RegisterationForm(Driver, Wait, "Ahmed23", "test65te", Department.Managementandleadership,
                                          PositionLevel.testposition,123456789, 012346789,
                                          "ahmed@test21.com", "P@ssw0rd", "P@ssw0rd"); //Emai&pass hyd5lo kda wla m setting b2a




            //Register New Company DED
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.accountregistration);
            portalForms.RegisterCompanyDED(Driver, Wait, Lisencetype.DED, "45874122DCwd");

            //Register New Company NONDED
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.accountregistration);
            portalForms.RegisterCompanyNonDED(Driver, Wait, Lisencetype.NONDED);


            //Add New POI
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.AddNewPoi);
            portalForms.ADDNewPOICompany(Driver, Wait, "katry", "123", PoiType.type1, PoiSubType.type2); //CompanyNAme :elmfrod el company elly created


            //Associate Company to GOC
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RequestAssociatetogoc);
            portalForms.AssociateToGOCRequest(Driver, Wait, "katry", "Aya GOC", "47524"); //parent GOC yt3m enum!?


            //Change brand catgory
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RequestChangeBrandCategory);
            portalForms.ChangeBrandRequest(Driver, Wait, "katry"); //Company name that created brdo

            //change cluster
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RequestChangeCompanyCluster);
            portalForms.ChangeClusterRequest(Driver, Wait, "Katry", Cluster.Multiplebrand, "4785");

            //change poi type

            portalForms.Portal_LoginAndNavigateTo(Driver,Wait,ServiceName.UpdatePoiType);
            portalForms.ChangePoiTypeRequest(Driver, Wait, "Katry", PoiType.type1, PoiSubType.type2, "5472");

        }
    }
}
