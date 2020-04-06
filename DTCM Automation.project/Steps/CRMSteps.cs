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
                // TODO Add approval 
               // xrmBrowser.BusinessProcessFlow.SelectStage(  commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
                checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                // TODO add approve stage form
               CRMFormsClass.CompanyCreationDecision(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Approve);
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
                       commonFunctions.NavigateTo(xrmBrowser1, "Profile Management", "Profile Management Requests", RequestNumber);
                    }

                    // TODO Add approval stage
                    //xrmBrowser.BusinessProcessFlow.SelectStage(commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
                    checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

                    // TODO add approve stage form
                    CRMFormsClass.CompanyCreationDecision(xrmBrowser1, decision);
                }
            }

            return checkStageIsCorrect;
        }




        //public bool CancelCompanyDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        //{
        //    bool checkStageIsCorrect = true;

        //    if (SameUser)
        //    {
        //        if (PickRequest)
        //            commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
        //        // TODO Add approval stage
        //        xrmBrowser.BusinessProcessFlow.SelectStage(commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
        //        checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

        //        // TODO add approve stage form
        //        CRMFormsClass.cancelrequest(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Cancel);
        //    }
        //    else
        //    {
        //        using (var xrmBrowser1 = new Browser(TestSettings.Options))
        //        {
        //            if (PickRequest)
        //                commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
        //            else
        //            {
        //                // TODO open existing request 
        //                commonFunctions.CRMLoginAs(xrmBrowser1, User);
        //                commonFunctions.NavigateTo(xrmBrowser1, "Profile Management", "Profile Management Requests", RequestNumber);
        //            }

        //            // TODO Add approval stage
        //            xrmBrowser.BusinessProcessFlow.SelectStage(commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
        //            checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

        //            // TODO add approve stage form
        //            CRMFormsClass.cancelrequest(xrmBrowser1, CommonFunctions.CommonFunctions.Decisions.Cancel);
        //        }
        //    }

        //    return checkStageIsCorrect;
        //}



        //public bool SendbackCompanyDecisionStep(Browser xrmBrowser, CommonFunctions.CommonFunctions.Users User, bool SameUser, bool PickRequest, bool loginFirst, string RequestNumber, CommonFunctions.CommonFunctions.Decisions decision)
        //{
        //    bool checkStageIsCorrect = true;

        //    if (SameUser)
        //    {
        //        if (PickRequest)
        //            commonFunctions.PickOpenRequest(xrmBrowser, User, loginFirst, RequestNumber);
        //        // TODO Add approval stage
        //        xrmBrowser.BusinessProcessFlow.SelectStage(commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
        //        checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

        //        // TODO add approve stage form
        //        CRMFormsClass.Sendbackrequest(xrmBrowser, CommonFunctions.CommonFunctions.Decisions.Sendback);
        //    }
        //    else
        //    {
        //        using (var xrmBrowser1 = new Browser(TestSettings.Options))
        //        {
        //            if (PickRequest)
        //                commonFunctions.PickOpenRequest(xrmBrowser1, User, loginFirst, RequestNumber);
        //            else
        //            {
        //                // TODO open existing request 
        //                commonFunctions.CRMLoginAs(xrmBrowser1, User);
        //                commonFunctions.NavigateTo(xrmBrowser1, "Profile Management", "Profile Management Requests", RequestNumber);
        //            }

        //            // TODO Add approval stage
        //            xrmBrowser.BusinessProcessFlow.SelectStage(commonFunctions.StagesValues[CommonFunctions.CommonFunctions.Stages.Reviewdecision]);
        //            checkStageIsCorrect = commonFunctions.CheckStage(xrmBrowser1, CommonFunctions.CommonFunctions.Stages.Reviewdecision);

        //            // TODO add approve stage form
        //            CRMFormsClass.Sendbackrequest(xrmBrowser1, CommonFunctions.CommonFunctions.Decisions.Sendback);
        //        }
        //    }

        //    return checkStageIsCorrect;
        //}

    }
}
