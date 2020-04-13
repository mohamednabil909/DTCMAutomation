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
   public class PortalFormsClass: TestHelper
    {
        private string LoaderClassName = "overlay";
        public string cluster;
 
        public void Portal_LoginAndNavigateTo( ServiceName serviceName)
        {
            
            // Done
            Driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL+ "/" + serviceName);
            WaitForPageToLoad();
            ClickOn(By.Id("login"),false);
            Thread.Sleep(5000);
            PortalLogin();
            WaitForPageToLoad();

        }


        public void NavigateToActivationLink( string Link)
        {
            Driver.Navigate().GoToUrl(Link);
            Thread.Sleep(5000);

            WaitForPageToLoad();
        }
        public void Portal_NavigateToRegister()
        {
            // Done
            Driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL + ServiceName.Register );
            Thread.Sleep(5000);

            WaitForPageToLoad();

        }

        public void Intialize()
        {
            Driver = IsDriverOpen() ? Driver : Initialize(Browser.chrome, out Wait);
        }
        private bool PortalLogin( )
        {
            By[] LoginLocators = new By[]
             {
             // Done
             By.Id("email"),
             By.Id("password"),
             By.XPath("//*[@id=\"signin\"]")
             };

            FrontendLogin(Properties.Settings.Default.username, Properties.Settings.Default.password, LoginLocators);
            // TODO add loading elementid
            WaitTillPageLoad(By.ClassName(LoaderClassName));
            WaitForPageToLoad();
            // Done
            if (Driver.Url.Contains("Home".ToLower()))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public string RegisterationForm( string firstname,string lastname,string Email,String pass)
        {
            
            Portal_NavigateToRegister();
            SelectByIndex(By.Id("title"),1);
            SendKeys(By.Id("firstname"),firstname);
            SendKeys(By.Id("lastname"), lastname);
            SelectByIndex(By.Id("department"), 1);
            SelectByIndex(By.Id("positionlevel"), 1);
            SendKeys(By.Id("landlinenumber"),"123456789");
            SendKeys(By.Id("mobilenumber"), "0123456789");
            SendKeys(By.Id("email"), Email.ToString());
            SendKeys(By.Id("password"), pass.ToString());
            SendKeys(By.Id("confirmpassword"), pass.ToString());
            ClickOn(By.Id("submit"), false);


            WaitForPageToLoad();
            // check confirmation message
            IsTextVisible("Your email is not confirmed yet. Please follow the link sent to your inbox to activate it. Resend");
            //SpanTextContains("Your email is not confirmed yet. Please follow the link sent to your inbox to activate it.");
            return "";
        }

        public string RegisterCompanyDED( Lisencetype lisencetype, string LisenceNumber)
        {

            ClickOn(By.Id("ServicesDropdown"),false);
            ClickOn(By.Id("retailservices"), false);
            ClickOn(By.Id("RegisterNewCompany"), false);
            WaitForPageToLoad();
            SelectByText(By.XPath("//*[@id=\"licensetype\"]"), lisencetype.ToString());
            SendKeys(By.Id("licenseno"), LisenceNumber);
            //SetDate(new DateTime(2006, 11, 16),By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/div/button"),
            //    By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker"),
            //    By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[1]/button"),
            //    By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[2]/button"));

            ClickOn(By.Id("gettid"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public string RegisterCompanyNonDED(  Lisencetype lisencetype)
        {
            SelectByText(By.Id("licensetype"), lisencetype.ToString());

            UploadAttachments(By.Id("3ac210ab-feef-ad63-6677-19ed57a761ce"),FileType.Txt); // 7ass enha 3'lt
            
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        //Fill form brand
        public void Fillbrandform(String CompanyName)
        {
            ClickOn(By.Id("ManagementDropdown"), false);
            ClickOn(By.Id("Companies"), false);
            //open the created company
            
            ClickOn(By.Id("addnewbrand"), false);
            SendKeys(By.Id("brandnameen"), "testBrand");
            SelectByText(By.Id("category"), "Accessories");
            ClickOn(By.Id("submit"), false);
        }

        //Fill Branch Form
        public void Fillbranchform()
        {
            ClickOn(By.Id("ManagementDropdown"), false);
            ClickOn(By.Id("Companies"), false);
            //open the created company

            //open the created brand
            
            ClickOn(By.Id("addnewbranch"), false);
            ClickOn(By.Id("typestandalone"),false);
            SendKeys(By.Id("licenseno"), "458de");

        }
        public string ADDNewPOICompany( string CompanyName, String Guid, PoiType poiType, PoiSubType poiSubType)
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

        public string AssociateToGOCRequest( string CompanyName, string ParentGOC, String Guid)
        {
            ClickOn(By.Id("AssociatetoGOCRequest"), false);
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("gocname"), ParentGOC); //parent GOC
            SendKeys(By.Id("RequestDetails"), "Request Details"+Guid);
            ClickOn(By.Id("submit"),false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID

        }

        public string ChangeBrandRequest( string CompanyName)
        {
            ClickOn(By.Id("ServicesDropdown"), false);
            ClickOn(By.Id("retailservices"), false);
            ClickOn(By.Id("ChangeBrandCategoryRequest"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            SelectByIndex(By.Id("newcategory"), 2); //new category
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            
            //var req = GetTextOf(By.Id("message"));
            //var msg = FindElement(By.Id("message"));
            //var el = FindElement(By.Id("message"));
            //var ell = FindElement(By.ClassName("popup-text"));
            //var requestId = GetTextOf(By.Id("message")).Split('#')[1].Substring(0, 11);
            String RequestID= GetRequestId(By.Id("message"), "Request", "has");
             //= GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID
        }

        public string ChangeClusterRequest( string CompanyName, Cluster cluster,string Guid)
        {
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("newcluster"), cluster.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return RequestID; // Done return created requestID

        }

        public string ChangePoiTypeRequest( string CompanyName, PoiType poiType, PoiSubType poiSubType, string Guid)
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

        public void FestivalParticipationRequest_description_and_details( string CompanyName, string EventName, Participationtype participationtype)
        {
            ClickOn(By.Id("ServicesDropdown"), false);
            ClickOn(By.Id("calendarmanagement"), false);
            ClickOn(By.Id("initiativeparticipationrequest"), false);

            ClickOn(By.Id("next"),false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName); 
            WaitForPageToLoad();
            //SelectByText(By.XPath("//*[@id=\"participationtype\"]"), participationtype.ToString()); 
            WaitForPageToLoad();
            ClickOn(By.Id("Discount, Sale, Part sale"), false);
            ClickOn(By.Id("next"), false);

        }

        public void FestivalParticipationRequest_branches_brands( )
        {
            var allBranches_festival = FindElement(By.XPath("/ html / body / app - root / div / app - initiative - participation - request / div / div / div / form / div[2] / div[1] / app - participation - request - accounts / form / div[1] / div / table / tbody / tr[1] / td / div / label"));
            allBranches_festival.Click();

        }

        public void FestivalParticipation_Add_promotion_discount()
        {
            ClickOn(By.Id("Discount"), false);
            //kolha calendar :(
        }


        public void FestivalAttachment()
        {
            ClickOn(By.Id("next"), false);
        }
        public void FestivalParticipationRequest_Payment_Details()
        {
            ClickOn(By.XPath("/html/body/app-root/div/app-initiative-participation-request/div/div/div/form/div[2]/div[2]/div[3]/div/div/label"), false);
            ClickOn(By.Id("submit"), false);
        }


        private void WaitForPageToLoad()
        {
            WaitTillPageLoad(By.ClassName(LoaderClassName));
        }

        public void RetailCalendarParticipationRequest_description_and_details( string CompanyName, string CalendarName)
        {
            ClickOn(By.Id("ServicesDropdown"), false);
            ClickOn(By.Id("calendarmanagement"), false);
            ClickOn(By.Id("CalendarParticicpationRequest"), false);

            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
           
            // SelectByText(By.Id("calendar"), CalendarName);
           // SelectByValue(By.Id("calendar"), CalendarName);
            //  SelectByText(By.XPath("//*[@id=\"calendar\"]"), CalendarName);
            //cluster = GetTextOf(By.Id("Cluster"));
            //cluster = FindElement(By.XPath("//*[@id=\"Cluster\"]")).Text;
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }


        public void RetailCalendarParticipationRequest_branches_brands( )
        {
            
            //if (cluster == Cluster.Multiplebrand.ToString() || cluster == Cluster.Singlebrand.ToString() ||cluster == Cluster.Multiplebrandanddistributor.ToString() || cluster == Cluster.Restaurant.ToString())// Branches 
           // {
                var allBranches = FindElement(By.XPath("/html/body/app-root/div/app-calendar-particicpation-request/div/div/div/form/div[2]/div/app-participation-request-accounts/form/div[1]/div/table/tbody/tr[1]/td/div/label"));
                allBranches.Click();
                
            //}
            //if (cluster == Cluster.Multiplebrandanddistributor.ToString() || cluster == Cluster.Distributor.ToString() || cluster == Cluster.Singlebrandanddistributor.ToString() || cluster == Cluster.Estore.ToString()) //brands 
            
            //{
            //    var allBrands = FindElement(By.XPath("/html/body/app-root/div/app-calendar-particicpation-request/div/div/div/form/div[2]/div/app-participation-request-accounts/form/div[1]/div/table/tbody/tr[1]/td/div/label"));
            //    allBrands.Click();
            //}
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void RetailCalendarParticipationRequest_Payment_Details( ) 
        {
            ClickOn(By.XPath("/html/body/app-root/div/app-calendar-particicpation-request/div/div/div/form/div[2]/div/div[3]/div/div/div/label"),false);
            ClickOn(By.Id("submit"), false);
        }

    }
}
