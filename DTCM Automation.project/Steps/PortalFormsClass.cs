using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static DTCM_Automation.project.CommonFunctions.Enums;

namespace DTCM_Automation.project.Steps
{
   public class PortalFormsClass: Common
    {
        private string LoaderClassName = "overlay";
 
        public void Portal_LoginAndNavigateTo(IWebDriver driver, WebDriverWait wait, ServiceName serviceName)
        {
            PortalLogin(driver, wait);
            // Done
            driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL+ "/" + serviceName);
            Thread.Sleep(5000);

            WaitForPageToLoad();

        }

        private bool PortalLogin(IWebDriver driver, WebDriverWait wait)
        {
            By[] LoginLocators = new By[]
             {
             // Done
             By.Id("email"),
             By.Id("password"),
             By.Id("login")
             };

            FrontendLogin(Properties.Settings.Default.username, Properties.Settings.Default.password, LoginLocators);
            // TODO add loading elementid
            WaitTillPageLoad(By.ClassName(LoaderClassName));
            WaitForPageToLoad();
            // Done
            if (driver.Url.Contains("Home".ToLower()))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public string RegisterationForm(IWebDriver driver,WebDriverWait wait, string firstname,string lastname,Department department,PositionLevel positionlevel,int landline,int Mobilenumber,string Email,String pass,string confirmpass)
        {
            //Done
            ClickOn(By.Id("register"),false);
            SendKeys(By.Id("firstname"),firstname);
            SendKeys(By.Id("lastname"), lastname);
            SelectByText(By.Id("department"), department.ToString());
            SelectByText(By.Id("positionlevel"), positionlevel.ToString());
            SendKeys(By.Id("landlinenumber"),landline.ToString());
            SendKeys(By.Id("mobilenumber"), Mobilenumber.ToString());
            SendKeys(By.Id("email"), Email.ToString());
            SendKeys(By.Id("password"), pass.ToString());
            SendKeys(By.Id("confirmpassword"), confirmpass.ToString());
            ClickOn(By.Id("submit"), false);

            return "";
        }

        public string RegisterCompanyDED(IWebDriver Drive,WebDriverWait Wait,Lisencetype lisencetype, string LisenceNumber)
        {
            SelectByText(By.Id("licensetype"), lisencetype.ToString());
            SendKeys(By.Id("licenseno"), LisenceNumber);
            SetDate(DateTime.Today.AddDays(2),By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/div/button"),
                By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker"),
                By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[1]/button"),
                By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[2]"));
            ClickOn(By.Id("gettid"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public string RegisterCompanyNonDED(IWebDriver Drive, WebDriverWait Wait, Lisencetype lisencetype)
        {
            SelectByText(By.Id("licensetype"), lisencetype.ToString());

            UploadAttachments(By.Id("3ac210ab-feef-ad63-6677-19ed57a761ce"),FileType.Txt); // 7ass enha 3'lt
            
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }
        public string ADDNewPOICompany(IWebDriver driver, WebDriverWait wait, string CompanyName, String Guid, PoiType poiType, PoiSubType poiSubType)
        {
            SelectByText(By.Id("company"), CompanyName);
            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("BriefDescription_"), "Test Brief Description" + Guid);
            ClickOn(By.Id("submit"), false);
           String RequestID= GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public string AssociateToGOCRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, string ParentGOC, String Guid)
        {
            ClickOn(By.Id("AssociatetoGOCRequest"), false);
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("gocname"), ParentGOC); //parent GOC
            SendKeys(By.Id("RequestDetails"), "Request Details"+Guid);
            ClickOn(By.Id("submit"),false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID

        }

        public string ChangeBrandRequest(IWebDriver driver, WebDriverWait wait, string CompanyName)
        {
            SelectByText(By.Id("company"), CompanyName);
            SelectByIndex(By.Id("newcategory"), 2); //new category
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public string ChangeClusterRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, Cluster cluster,string Guid)
        {
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("newcluster"), cluster.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID

        }

        public string ChangePoiTypeRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, PoiType poiType, PoiSubType poiSubType, string Guid)
        {
            SelectByText(By.Id("company"), CompanyName); 

            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public void FestivalParticipationRequest_description_and_details(IWebDriver driver, WebDriverWait wait, string CompanyName, string EventName, Participationtype participationtype)
        {

            ClickOn(By.Id("next"),false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName); 
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), participationtype.ToString()); 
            WaitForPageToLoad();
            ClickOn(By.Id("mat - radio - 12"), false);
            ClickOn(By.Id("next"), false);

        }

        public void FestivalParticipationRequest_branches_brands(IWebDriver driver, WebDriverWait wait)
        {

            if (participationlabel == "participation branches".ToLower())
            {
                ClickOn(By.Id(""), false);
            }

            else if (participationlabel == "participation brands".ToLower())
            {
                ClickOn(By.Id(""), false);
            }
            ClickOn(By.Id("next"), false);

        }

        private void WaitForPageToLoad()
        {
            WaitTillPageLoad(By.ClassName(LoaderClassName));
        }

        public void RetailCalendarParticipationRequest_description_and_details(IWebDriver driver, WebDriverWait wait, string CompanyName, string CalendarName)
        {
            ClickOn(By.Id("next"), false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("calendar"), CalendarName);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        String participationlabel;
        public void RetailCalendarParticipationRequest_branches_brands(IWebDriver driver, WebDriverWait wait)
        {

            if(participationlabel=="participation branches".ToLower()) 
            {
                ClickOn(By.Id(""), false);
            }

            else if (participationlabel == "participation brands".ToLower())
            {
                ClickOn(By.Id(""), false);
            }
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void RetailCalendarParticipationRequest_Payment_Details(IWebDriver driver, WebDriverWait wait) 
        {
            ClickOn(By.Id("checkedcontrol"),false);
            ClickOn(By.Id("submit"), false);
        }

    }
}
