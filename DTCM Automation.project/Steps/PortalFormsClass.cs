using DTCM_Automation.project.CommonFunctions;
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

        public void Portal_LoginAndNavigateTo(ServiceName serviceName)
        {

            // Done
            Driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL + "/" + ServiceName.Login);
            WaitForPageToLoad();
            PortalLogin();
            WaitForPageToLoad();

            Driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL + "/" + ServiceNameValue[serviceName]);


        }


        public bool NavigateToActivationLink( string Link)
        {
            Driver.Navigate().GoToUrl(Link);
            Thread.Sleep(5000);

            WaitForPageToLoad();

            // check message confirmed
           return IsTextVisible("Email confirmed successfully");
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

        public string GetRquestId()
        {
            var messages = Driver.FindElements(By.ClassName("popup-text"));
            foreach (var item in messages)
            {
                if (item.Text != "")
                {
                    return GetRequestId(item.Text, "#", " ");
                }
            }
            return "";
        }


        public bool RegisterationForm( string firstname,string lastname,string Email,String pass)
        {
            
            
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
           return IsTextVisible("Your email is not confirmed yet. Please follow the link sent to your inbox to activate it. Resend");
            
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

        public string RegisterCompanyNonDED(Lisencetype lisencetype,string Guid)
        {
            var licensetypevalue = "";
            Enums.lisencetype.TryGetValue(lisencetype, out licensetypevalue);
            SelectByText(By.XPath("//*[@id=\"licensetype\"]"), licensetypevalue);
            SendKeys(By.Id("licenseno"), Properties.Settings.Default.lisenceNumber);
            UploadAttachments(By.Id("bfeaa6c2-9a35-ec0c-0a00-a9218126e00e"),FileType.Txt); // Msh sh3'ala
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            return GetRquestId();
        }

        public string ADDNewPOICompany(string CompanyName, String Guid, PoiType poiType, PoiSubType poiSubType)
        {
            SelectByText(By.Id("company"), CompanyName);
            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            //SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("BriefDescription_"), "Test Brief Description" + Guid);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();

            return GetRquestId();
        }

        //Fill form brand
        public void Fillbrandform()
        {
            //ClickOn(By.Id("ManagementDropdown"), false);
            //ClickOn(By.Id("Companies"), false);
            //open the created company
            
            //ClickOn(By.Id("addnewbrand"), false);
            
            SendKeys(By.Id("brandnameen"), "testBrand");
            SelectByText(By.Id("category"), "Fashion Clothing".ToLower());
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
        
        public string AssociateToGOCRequest( string CompanyName, string ParentGOC, String Guid)
        {
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("gocname"), ParentGOC); //parent GOC
            SendKeys(By.Id("RequestDetails"), "Request Details" +Guid);
            ClickOn(By.Id("submit"),false);
            //String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return ""; // TODO after solving getrequest id method

        }

        public string ChangeBrandRequest( string BrandName)
        {
            WaitForPageToLoad();
            SelectByText(By.Id("company"), BrandName);
            SelectByIndex(By.Id("newcategory"), 2); //new category
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            
            //var req = GetTextOf(By.Id("message"));
            //var msg = FindElement(By.Id("message"));
            //var el = FindElement(By.Id("message"));
            //var ell = FindElement(By.ClassName("popup-text"));
            //var requestId = GetTextOf(By.Id("message")).Split('#')[1].Substring(0, 11);
           // String RequestID= GetRequestId(By.Id("message"), "Request", "has");
             //= GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return ""; // Done return created requestID
        }

        public string ChangeClusterRequest( string CompanyName, Cluster cluster,string Guid)
        {
            SelectByText(By.Id("company"), CompanyName);

            var clustervalue = "";
            Enums.cluster.TryGetValue(cluster, out clustervalue);
            SelectByText(By.Id("newcluster"), clustervalue);

            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            //String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return " "; // Done return created requestID

        }

        public string ChangePoiTypeRequest( string CompanyName, PoiType poiType, PoiSubType poiSubType, string Guid)
        {
            SelectByText(By.Id("company"), CompanyName); 

            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            //String RequestID = GetRequestId("Request #REQ-388497 has been created", "Request", "has");
            return ""; // Done return created requestID
        }

       
        private void WaitForPageToLoad()
        {
            WaitTillPageLoad(By.ClassName(LoaderClassName));
        }

        //RetailCalendar Request
        public void RetailCalendarParticipationRequestDescriptionAndDetailsStep( string CompanyName, string CalendarName)
        {
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("calendar"), CalendarName);
            //cluster = GetTextOf(By.Id("Cluster"));
            //cluster = FindElement(By.XPath("//*[@id=\"Cluster\"]")).Text;
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }
        public void RetailCalendarParticipationRequest_AddBransAndBranches(Participationselection participationselection)
        {
            
            if(participationselection == Participationselection.Branchs)
            {
                //var allBranches = FindElement(By.Id("selectallbranches"));
                //allBranches.Click();

                ClickOn(By.Id("selectallbranches"),true);

            }

           else if(participationselection == Participationselection.Brands)
            {
                //var allBrands = FindElement(By.Id("selectallbrands"));
                //allBrands.Click();
                ClickOn(By.Id("selectallbrands"), true);
            }

            else
            {
                
                ClickOn(By.Id("selectallbranches"),true);
                ClickOn(By.Id("selectallbrands"), true);

               
            }


            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }
        public string RetailCalendarParticipationRequest_PaymentDetailsStep( )
        {
            // add validationstep
            ClickOn(By.Id("checkedcontrol"), true);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            return GetRquestId();
        }
        public void FestivalParticipationRequest_DetailsStep(string CompanyName,string EventName)
        {
            ClickOn(By.Id("next"), false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            //SelectByText(By.XPath("//*[@id=\"participationtype\"]"), participationtype.ToString()); 
            WaitForPageToLoad();
            ClickOn(By.Id("Discount, Sale, Part sale"), false);
            ClickOn(By.Id("next"), false);

        }
        public void FestivalParticipationRequest_SelectBransAndBranches(Participationselection participationselection)
        {
            if (participationselection == Participationselection.Branchs)
            {
                //var allBranches = FindElement(By.Id("selectallbranches"));
                //allBranches.Click();
                ClickOn(By.Id("selectallbranches"), true);
            }

            else if (participationselection == Participationselection.Brands)
            {
                //var allBrands = FindElement(By.Id("selectallbrands"));
                //allBrands.Click();
                ClickOn(By.Id("selectallbrands"), true);
            }

            else
            {

                ClickOn(By.Id("selectallbranches"), true);
                ClickOn(By.Id("selectallbrands"), true);
            }
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);

        }
        public void FestivalParticipationAddDiscount_Sale_PartSale(Promotions promotions)
        {
            if (promotions == Promotions.Discount)
            {
                ClickOn(By.Id("Discount"), false);
                //kolha calendar :(
            }
            else if (promotions == Promotions.Sale)
            {
                ClickOn(By.Id("Sale"), false);
                //kolha calendar :(
            }

            else if (promotions == Promotions.PartSale)
            {
                ClickOn(By.Id("Part Sale"), false);
                //kolha calendar :(
            }
        }
        public void FestivalAttachmentsStep()
        {
            ClickOn(By.Id("next"), false);
        }
        public string FestivalParticipationRequest_PaymentDetailsStep()
        {
            // TODO add step to check payments created correctly
           /* ClickOn(By.XPath("/html/body/app-root/div/app-initiative-participation-request/div/div/div/form/div[2]/div[2]/div[3]/div/div/label"), false);*/
            ClickOn(By.Id("submit"), false);
            // TODO return request id
            return "";
        }

        //Activation
        public void ActivationParticipationRequest_Description_DetailsStep(string CompanyName, string EventName)
        {

            ClickOn(By.Id("next"), false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            ClickOn(By.Id("Discount, Sale, Part sale"), false);
            ClickOn(By.Id("next"), false);

        }

        public void ActivationParticipationRequest_SelectBransAndBranches(Participationselection participationselection)
        {
            if (participationselection == Participationselection.Branchs)
            {
                //var allBranches = FindElement(By.Id("selectallbranches"));
                //allBranches.Click();
                ClickOn(By.Id("selectallbranches"), true);
            }

            else if (participationselection == Participationselection.Brands)
            {
                //var allBrands = FindElement(By.Id("selectallbrands"));
                //allBrands.Click();
                ClickOn(By.Id("selectallbrands"), true);
            }
            else
            {
                ClickOn(By.Id("selectallbranches"), true);
                ClickOn(By.Id("selectallbrands"), true);
            }
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationAddDiscount_Sale_PartSale(Promotions promotions)
        {
            if (promotions == Promotions.Discount)
            {
                ClickOn(By.Id("Discount"), false);
                //kolha calendar :(
            }
            else if (promotions == Promotions.Sale)
            {
                ClickOn(By.Id("Sale"), false);
                //kolha calendar :(
            }

            else if (promotions == Promotions.PartSale)
            {
                ClickOn(By.Id("Part Sale"), false);
                //kolha calendar :(
            }
        }

        public void ActivationAttachmentsStep()
        {
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationRequest_PaymentDetailsStep()
        {
            // TODO add step to check payments created correctly
            ClickOn(By.XPath("/html/body/app-root/div/app-initiative-participation-request/div/div/div/form/div[2]/div[2]/div[3]/div/div/label"), false);
            ClickOn(By.Id("submit"), false);
        }
    }
}
