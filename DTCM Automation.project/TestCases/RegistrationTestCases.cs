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
    /// Summary description for RegistrationTestCases
    /// </summary>
    [TestClass]
    public class RegistrationTestCases
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

        [TestMethod]
        public void TC_RegisterNewUser_OpenSentEmail_ActivateAccount_Login()
        {
            string Guid = CommonFunctions.RandomNumber();
            bool confirmed;
            portalForms.Portal_NavigateToRegister();
            //Registeration
            portalForms.RegisterationForm("FirstName", Guid, "Test" + Guid + "Atomation@test.com", "P@ssw0rd1");



            // portalSteps.RegiterNewUser( guid);
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {


                string actvatinLink = CRMSteps.OpenActivationEmail(xrmBrowser, Users.Admin, "Test" + Guid + "Atomation@test.com");

                confirmed= portalForms.NavigateToActivationLink(actvatinLink);
            }

            // save it on settings
            if(confirmed)
            {
                Properties.Settings.Default.CreatedUser = "Test" + Guid + "Atomation@test.com";
            }

        }
    }
}
