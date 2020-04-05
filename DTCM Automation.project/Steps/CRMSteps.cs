using DTCM_Automation.project.CommonFunctions;
using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // TODO Add approva stage
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Employeedecision);

                // TODO add approve stage form
               CRMFormsClass.CompanyCreationDecision(xrmBrowser, decision);
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
                       commonFunctions.NavigateTo(xrmBrowser1, "", "", "");
                    }

                    // TODO Add approva stage
                    checkStageIsCorrect =commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                    // TODO add approve stage form
                    CRMFormsClass.CompanyCreationDecision(xrmBrowser1, decision);
                }
            }

            return checkStageIsCorrect;
        }


    }
}
