using DTCM_Automation.project.CommonFunctions;
using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTCM_Automation.project.CommonFunctions;

namespace DTCM_Automation.project.Steps
{
   public class CRMSteps
    {

        CommonFunctions.CommonFunctions commonFunctions = new CommonFunctions.CommonFunctions();
        CRMFormsClass CRMFormsClass = new CRMFormsClass();

        public bool CompanyCreationDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                // Done
               CRMFormsClass.CompanyCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve, CommonFunctions.CommonFunctions.AccountType.Retailer);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                       commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                       commonFunctions.CRMLoginAs(xrmBrowser1, User);
                       
                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                    // Done
                    CRMFormsClass.CompanyCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve, CommonFunctions.CommonFunctions.AccountType.Retailer);
                }
            }

            return checkStageIsCorrect;
        }



        public bool CalendarCreationDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Employeedecision);

                // Done
                CRMFormsClass.CalendarCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                        commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                        commonFunctions.CRMLoginAs(xrmBrowser1, User);

                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Employeedecision);

                    // Done
                    CRMFormsClass.CalendarCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
                }
            }

            return checkStageIsCorrect;
        }



        public bool ActivatioinCreationDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        {
            bool checkStageIsCorrect = true;

            if (SameUser)
            {
                if (PickRequest)
                    commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
                // Done
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Managerdecision);

                // Done
                CRMFormsClass.ActivatioinCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
            }
            else
            {
                using (var xrmBrowser1 = new Browser(TestSettings.Options))
                {
                    if (PickRequest)
                        commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
                    else
                    {
                        // TODO open existing request 
                        commonFunctions.CRMLoginAs(xrmBrowser1, User);
                        // TODO navigate to requests and open request using requestid parameter
                    }

                    // Done
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Managerdecision);

                    // Done
                    CRMFormsClass.ActivatioinCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
                }
            }

            return checkStageIsCorrect;
        }

    }
}
