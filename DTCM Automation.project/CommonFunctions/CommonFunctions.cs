using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DTCM_Automation.project.CommonFunctions
{
    public class CommonFunctions
    {
        public enum Users
        {
            // Done
            Admin,
            Stackholder,
            Retailer,
            Poi,
            Configuration,

        }
        public enum Decisions
        {
            // Done
            Approve,
            Sendback,
            Cancel
        }
        public enum Stages
        {
            // Done
            Submission,
            Reviewdecision,
            Employeedecision,
            Managerdecision

        }
        public Dictionary<Stages, string> StagesValues = new Dictionary<Stages, string>()
        {
            // Done
            { Stages.Submission,"Submission" },
            { Stages.Reviewdecision,"Review Decision"},
            { Stages.Employeedecision,"Employee Decision" },
            { Stages.Managerdecision,"Manager Decision" }
        };
        private  SecureString _username = Properties.Settings.Default.OnlineUsername.ToSecureString(); 
        private  SecureString _password = Properties.Settings.Default.OnlinePassword.ToSecureString(); 
        private  Uri _xrmUri = new Uri(Properties.Settings.Default.OnlineCrmUrl.ToString());

        public void CRMLoginAs(Browser xrmBrowser, Users User)
        {
            switch (User)
            {

                case Users.Admin:
                    TestSettings.Options.PageLoadStrategyValue = OpenQA.Selenium.PageLoadStrategy.None;
                    _username = Properties.Settings.Default.CRMAdminUsername.ToSecureString();
                    _password = Properties.Settings.Default.CRMAdminPassword.ToSecureString();
                    break;
               
            };



            Thread.Sleep(5000);
            xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
            TestSettings.Options.PageLoadStrategyValue = OpenQA.Selenium.PageLoadStrategy.Default;
        }

        public void dismissPopup(Browser xrmBrowser)
        {
            xrmBrowser.Driver.WaitForPageToLoad();
            xrmBrowser.Dialogs.CloseWarningDialog(2);
        }

        public void NavigateTo(Browser xrmBrowser, string Area, string subArea, string view = null)
        {
            xrmBrowser.ThinkTime(5000);
            dismissPopup(xrmBrowser);
            try
            {
                xrmBrowser.Navigation.OpenHomePage();

                Thread.Sleep(2000);
                xrmBrowser.Entity.DismissAlertIfPresent(false);
            }
            catch (UnhandledAlertException)
            {
                xrmBrowser.Entity.DismissAlertIfPresent(false);
            }

            xrmBrowser.Driver.WaitForPageToLoad();

            xrmBrowser.Navigation.OpenSubArea(Area, subArea);

            if (view != null)
            {
                Thread.Sleep(5000);
                // ClickOnMenue(xrmBrowser);
                xrmBrowser.Grid.SwitchView(view);
            }
        }
        public void PickOpenRequest(Browser xrmBrowser, Users User, bool loginFirst, string RequestNumber)
        {
            if (loginFirst)
            {
                new CommonFunctions().CRMLoginAs(xrmBrowser, User);
            }
            // Done
            xrmBrowser.Navigation.OpenSubArea("Profile Management", "Queue Items");
            xrmBrowser.Driver.WaitForPageToLoad();
            Thread.Sleep(5000);
            xrmBrowser.Grid.Search(RequestNumber);


            //xrmBrowser.Grid.Search(RequestNumber);
            var GridItems = xrmBrowser.Grid.GetGridItems().Value;
            if (GridItems != null && GridItems.Count > 0)
            {
                xrmBrowser.Grid.SelectRecord(0);
                xrmBrowser.CommandBar.ClickCommand("PICK");
                xrmBrowser.Dialogs.PickDialog();
            }
            else
            {
                //Assert.Fail(RequestNumber + " Not exist");
            }
        }

        public bool CheckStage(Browser xrmBrowser, Stages ExpectedStage)
        {
            // check current stage
            string currentStage = xrmBrowser.BusinessProcessFlow.GetCurrentStage();
            var checkStageIsCorrect = StagesValues[ExpectedStage].Equals(currentStage.Trim());


            // Assert.AreEqual(NewCraftStagesValues[ExpectedStage], currentStage.Trim(), "Stage is " + currentStage.Trim() + " and it should be " + NewCraftStagesValues[ExpectedStage]);
            if (!checkStageIsCorrect)
            {

                Logg log = new Logg
                {
                    FailReason = "Stage is " + currentStage.Trim() + " and it should be " + StagesValues[ExpectedStage],
                    Result = "Fail",
                    Stage = currentStage.Trim(),
                };

                ResultLog resultLog = new ResultLog();
                resultLog.WriteFailReason(log);
            }


            return checkStageIsCorrect;
        }
        public void CheckItemCreated(Browser xrmBrowser, string ItemNumber, string Item, bool status)
        {
            ResultLog resultLog = new ResultLog();
            if (!status)
            {
                Logg log = new Logg
                {
                    FailReason = Item + " Not created Successfully",
                    Result = "Partially Fail"
                };
                resultLog.WriteFailReason(log);
            }
            else
            {
                Logg log = new Logg
                {
                    RequestNumber = ItemNumber + " created Successfully",
                    Result = "Partially Passed"
                };
                resultLog.WriteFinalResult(log);
            }


        }



        public bool CheckRequestStatus(Browser xrmBrowser, string ExpectedStatus)
        {
            // Done
            string RequestStatus = xrmBrowser.Entity.GetValue(new OptionSet { Name = "ldv_requeststatusid" });
            string RequestNumber = xrmBrowser.Entity.GetValue(new OptionSet { Name = "ldv_name" });
            if (!RequestStatus.Equals(ExpectedStatus))
            {
                Logg log = new Logg
                {
                    FailReason = "Status is " + RequestStatus + " and it should be " + ExpectedStatus,
                    Result = "Fail",
                    Stage = RequestStatus,
                    RequestNumber = RequestNumber
                };

                ResultLog resultLog = new ResultLog();
                resultLog.WriteFailReason(log);
            }
            else if (RequestStatus.Contains("Completed"))
            {
                //TODOMariana
                //LogCaseResult(xrmBrowser, RequestNumber);
            }
            return RequestStatus.Equals(ExpectedStatus);
        }


        public void RefreshPage(Browser xrmBrowser)
        {
            // refresh the page
            xrmBrowser.Driver.Navigate().Refresh();
            Thread.Sleep(2000);
            xrmBrowser.Entity.DismissAlertIfPresent(false);

            Thread.Sleep(10000);
            dismissPopup(xrmBrowser);
        }

        public bool selectLookup(Browser xrmBrowser, string ElementId,string SearchValue)
        {
            xrmBrowser.Entity.SelectLookup(ElementId);
            xrmBrowser.Lookup.Search(SearchValue);
            //xrmBrowser.Lookup.SelectItem(0)
           return xrmBrowser.Lookup.Add();
        }

    }
}
