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
            WaitForPageToLoad();
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
        public string FillBrandForm(string brandNameEnglish, string categoryName, string brandNameArabic ="")
        {
            WaitForPageToLoad();
            SendKeys(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[1]/div/div/input"), "cinnabon".ToLower());
            ClickOn(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[2]/div/div/a/div"),false);
            ClickOn(By.Id("addnewbrand"),false);
            SendKeys(By.Id("brandnameen"), brandNameEnglish);
            SendKeys(By.Id("brandnamear"), brandNameArabic);
            SelectByText(By.Id("category"),categoryName); 
            ClickOn(By.Id("submit"), false);
            //click on close
            //string url = GetUrl();
            //url = url.Split('/')[5].ToString();

            return brandNameEnglish;
        }

        public string ChangeBrandRequest(string BrandName)
        {
            WaitForPageToLoad();
            SelectByText(By.Id("company"), BrandName);
            SelectByIndex(By.Id("newcategory"), 2); //new category
            WaitForPageToLoad();
            ClickOn(By.Id("submit"), false);
            return GetRquestId();
        }

        //Fill Branch Form (Standalone)
        public void Fillbranchform_Standalone()
        {

            SendKeys(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[1]/div/div/input"), "cinnabon".ToLower());
            ClickOn(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[2]/div/div/a/div"), false);
            ClickOn(By.XPath("/html/body/app-root/div/app-company/div/div/div/div[3]/div[1]/div"),false);
            ClickOn(By.Id("addnewbranch"), false);
            ClickOn(By.Id("typestandalone"), false);
            SelectByText(By.Id("area"), "Bur Dubai");
            SendKeys(By.Id("licenseno"), Properties.Settings.Default.lisenceNumber);
            SendKeys(By.Id("Street1"), "Street11212");
            ClickOn(By.Id("submit"), false);
        }
        
        //Fill Branch Form (Mall)
        public void Fillbranchform_Mall()
        {
            SendKeys(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[1]/div/div/input"), "cinnabon".ToLower());
            ClickOn(By.XPath("/html/body/app-root/div/app-companymanagement/div/div/div[2]/div/div/a/div"), false);
            ClickOn(By.XPath("/html/body/app-root/div/app-company/div/div/div/div[3]/div[1]/div"), false);
            ClickOn(By.Id("addnewbranch"), false);
            ClickOn(By.Id("typemall"), false);
            SendKeys(By.Id("licenseno"), Properties.Settings.Default.lisenceNumber);
            SelectByText(By.Id("mall"), "Dubai Mall");
            ClickOn(By.Id("submit"), false);
        }


        public string AssociateToGOCRequest( string CompanyName, string ParentGOC, String Guid)
        {
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("gocname"), ParentGOC); //parent GOC
            SendKeys(By.Id("RequestDetails"), "Request Details" +Guid);
            ClickOn(By.Id("submit"),false);

            return GetRquestId();

        }

        

        public string ChangeClusterRequest( string CompanyName, Cluster cluster,string Guid)
        {
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);

            var newclustervalue = "";
            Enums.clustervalue.TryGetValue(cluster, out newclustervalue);
            SelectByText(By.Id("newcluster"), newclustervalue);

            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            return GetRquestId();

        }

        public string ChangePoiTypeRequest( string CompanyName, PoiType poiType, PoiSubType poiSubType, string Guid)
        {
            SelectByText(By.Id("company"), CompanyName); 

            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            return GetRquestId();
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
        public string RetailCalendarParticipationRequest_PaymentDetailsStep(string product,double productvalue)
        {
            // add validationstep
            // TODO Add id of total price
            string Actual_price = GetTextOf(By.Id(""));
            double Expected_value = productvalue+ Properties.Settings.Default.POAddedValues;
            if(Convert.ToDouble(Actual_price)!= Expected_value)
            {
                // Log exception po not calculated correctly 
                // take screenshot
            }
            ClickOn(By.Id("checkedcontrol"), true);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            return GetRquestId();
        }
        //Festival Request
        public void FestivalParticipationRequest_DetailsStep(string CompanyName,string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
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

        public void FestivalParticipationRequest_DetailsStepkiosk(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Kiosk"), false);
            ClickOn(By.Id("next"), false);
        }

        public void FestivalParticipationRequest_DetailsStepRaffle(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Raffle"), false);
            ClickOn(By.Id("next"), false);
        }

        public void FestivalParticipationRequest_DetailsStepScratchandwin(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Scratch and win"), false);
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
        public void FestivalParticipationAddDiscount_Sale_PartSale_Offer(Promotions promotions)
        {
            if (promotions == Promotions.Discount)
            {
                ClickOn(By.Id("Discount"), false);
                //2 fields of calendar
                SendKeys(By.Id("DiscountPercentage"),"50");
                SelectByText(By.Id("discounttype"), "On All Items".ToLower());
                ClickOn(By.Id("submit"),false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"),false);
            }
            else if (promotions == Promotions.Sale)
            {
                ClickOn(By.Id("Sale"), false);
                //2 fields of calendar
                SendKeys(By.Id("MinValue"), "60");
                SendKeys(By.Id("MaxValue"), "70");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

            else if (promotions == Promotions.PartSale)
            {
                ClickOn(By.Id("Part Sale"), false);
                //2 fields of calendar
                SendKeys(By.Id("MinValue"), "50");
                SendKeys(By.Id("MaxValue"), "60");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

            else if (promotions == Promotions.Offer)
            {
                ClickOn(By.Id("Offer"), false);
                //2 fields of calendar
                SendKeys(By.Id("offerdetails"), "offertest");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

        }

        public void FestivalParticipationAddKiosk(Promotions promotions)
        {
            ClickOn(By.Id("Kiosk"), false);
            //2 fields of calendar
            SendKeys(By.Id("KioskLocation"), "Test Kiosk Location");
            SelectByText(By.Id("kiosktype"), "Commercial");
            SendKeys(By.Id("kioskdetails"), "Test Kiosk details");
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void FestivalParticipationAddRaffle(Promotions promotions)
        {
            ClickOn(By.Id("Raffle"), false);
            //2 fields of calendar
            SelectByText(By.Id("raffletype"), "Online");
            SendKeys(By.Id("raffledetails"), "Raffle Details");
            SendKeys(By.Id("TotalNoOfWinners"), "7");
            SendKeys(By.Id("ContactPersonName"), "Test Raffle");
            SendKeys(By.Id("ContactPersonEmail"), "Test@Raffle.com");
            SendKeys(By.Id("ContactPersonMobile"), "1234567890");

            ClickOn(By.Id("addrafflelocation"),false);
            SendKeys(By.Id("rafflelocation"),"Location");
            //Calendar
            ClickOn(By.Id("save"),false);
            ClickOn(By.Id("addgift"),false);
            SendKeys(By.Id("GiftName"),"Prize");
            SendKeys(By.Id("NoOfGifts"), "4");
            SendKeys(By.Id("PricePerEachGift"), "4");
            ClickOn(By.Id("save"), false);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void FestivalParticipationAddScratchandWin(Promotions promotions)
        {
            ClickOn(By.Id("Scratch & Win"), false);
            //2 fields of calendar
            
            SendKeys(By.Id("details"), "Details");
            SendKeys(By.Id("numberofwinners"), "4");
            SendKeys(By.Id("contactpersonname"), "Test Scratch");
            SendKeys(By.Id("contactpersonemail"), "Test@Scratch.com");
            SendKeys(By.Id("contactpersonmobile"), "1234567800");
            
            ClickOn(By.Id("addgift"), false);
            SendKeys(By.Id("GiftName"), "Prize1");
            SendKeys(By.Id("NoOfGifts"), "42");
            SendKeys(By.Id("PricePerEachGift"), "24");
            ClickOn(By.Id("save"), false);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void FestivalAttachmentsStep()
        {
            ClickOn(By.Id("next"), false);
        }

        public void FestivalAttachmentsStepKiosk()
        {
            //Add attchment
            UploadAttachments(By.Id(""), FileType.Txt);
            ClickOn(By.Id("next"), false);
        }

        public string FestivalParticipationRequest_PaymentDetailsStep()
        {
            // TODO add step to check payments created correctly
           /* ClickOn(By.XPath("/html/body/app-root/div/app-initiative-participation-request/div/div/div/form/div[2]/div[2]/div[3]/div/div/label"), false);*/
            ClickOn(By.Id("submit"), false);
            return GetRquestId();
        }

        // Activation Request
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


        public void ActivationParticipationRequest_DetailsStepkiosk(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Kiosk"), false);
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationRequest_DetailsStepRaffle(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Raffle"), false);
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationRequest_DetailsStepScratchandwin(string CompanyName, string EventName)
        {
            ClickOn(By.Id("next"), false);
            WaitForPageToLoad();
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName);
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), "Promotions");
            WaitForPageToLoad();
            ClickOn(By.Id("Scratch and win"), false);
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

        public void ActivationParticipationAddDiscount_Sale_PartSale_Offer(Promotions promotions)
        {
            if (promotions == Promotions.Discount)
            {
                ClickOn(By.Id("Discount"), false);
                //2 fields of calendar
                SendKeys(By.Id("DiscountPercentage"), "50");
                SelectByText(By.Id("discounttype"), "On All Items".ToLower());
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }
            else if (promotions == Promotions.Sale)
            {
                ClickOn(By.Id("Sale"), false);
                //2 fields of calendar
                SendKeys(By.Id("MinValue"), "60");
                SendKeys(By.Id("MaxValue"), "70");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

            else if (promotions == Promotions.PartSale)
            {
                ClickOn(By.Id("Part Sale"), false);
                //2 fields of calendar
                SendKeys(By.Id("MinValue"), "50");
                SendKeys(By.Id("MaxValue"), "60");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

            else if (promotions == Promotions.Offer)
            {
                ClickOn(By.Id("Offer"), false);
                //2 fields of calendar
                SendKeys(By.Id("offerdetails"), "offertest");
                ClickOn(By.Id("submit"), false);
                WaitForPageToLoad();
                ClickOn(By.Id("next"), false);
            }

        }


        public void ActivationParticipationAddKiosk(Promotions promotions)
        {
            ClickOn(By.Id("Kiosk"), false);
            //2 fields of calendar
            SendKeys(By.Id("KioskLocation"), "Test Kiosk Location");
            SelectByText(By.Id("kiosktype"), "Commercial");
            SendKeys(By.Id("kioskdetails"), "Test Kiosk details");
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationAddRaffle(Promotions promotions)
        {
            ClickOn(By.Id("Raffle"), false);
            //2 fields of calendar
            SelectByText(By.Id("raffletype"), "Online");
            SendKeys(By.Id("raffledetails"), "Raffle Details");
            SendKeys(By.Id("TotalNoOfWinners"), "7");
            SendKeys(By.Id("ContactPersonName"), "Test Raffle");
            SendKeys(By.Id("ContactPersonEmail"), "Test@Raffle.com");
            SendKeys(By.Id("ContactPersonMobile"), "1234567890");

            ClickOn(By.Id("addrafflelocation"), false);
            SendKeys(By.Id("rafflelocation"), "Location");
            //Calendar
            ClickOn(By.Id("save"), false);
            ClickOn(By.Id("addgift"), false);
            SendKeys(By.Id("GiftName"), "Prize");
            SendKeys(By.Id("NoOfGifts"), "4");
            SendKeys(By.Id("PricePerEachGift"), "4");
            ClickOn(By.Id("save"), false);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void ActivationParticipationAddScratchandWin(Promotions promotions)
        {
            ClickOn(By.Id("Scratch & Win"), false);
            //2 fields of calendar

            SendKeys(By.Id("details"), "Details");
            SendKeys(By.Id("numberofwinners"), "4");
            SendKeys(By.Id("contactpersonname"), "Test Scratch");
            SendKeys(By.Id("contactpersonemail"), "Test@Scratch.com");
            SendKeys(By.Id("contactpersonmobile"), "1234567800");

            ClickOn(By.Id("addgift"), false);
            SendKeys(By.Id("GiftName"), "Prize1");
            SendKeys(By.Id("NoOfGifts"), "42");
            SendKeys(By.Id("PricePerEachGift"), "24");
            ClickOn(By.Id("save"), false);
            ClickOn(By.Id("submit"), false);
            WaitForPageToLoad();
            ClickOn(By.Id("next"), false);
        }

        public void ActivationAttachmentsStepKiosk()
        {
            //Add attchment
            UploadAttachments(By.Id(""), FileType.Txt);
            ClickOn(By.Id("next"), false);
        }


        public void ActivationAttachmentsStep()
        {
            ClickOn(By.Id("next"), false);
        }

        public string ActivationParticipationRequest_PaymentDetailsStep()
        {
            // TODO add step to check payments created correctly
            WaitForPageToLoad();
            ClickOn(By.XPath("/html/body/app-root/div/app-initiative-participation-request/div/div/div/form/div[2]/div[2]/div[3]/div/div/label"), false);
            ClickOn(By.Id("submit"), false);
            return GetRquestId();
        }
    }
}
