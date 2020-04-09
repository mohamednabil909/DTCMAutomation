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
            portalForms.Portal_LoginAndNavigateTo(Driver, Wait, ServiceName.RetailCalindar);
            portalForms.RetailCalendarParticipationRequest(Driver);
        }
    }
}
