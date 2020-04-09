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
            // TODO service url
            driver.Navigate().GoToUrl(Properties.Settings.Default.portalLoginURL+ "/" + serviceName);
            Thread.Sleep(5000);

            WaitForPageToLoad();

        }

        private bool PortalLogin(IWebDriver driver, WebDriverWait wait)
        {
            By[] LoginLocators = new By[]
             {
             // TODO add login locators 
             By.Id("email"),
             By.Id("password"),
             By.Id("login")
             };

            // 
            FrontendLogin(Properties.Settings.Default.username, Properties.Settings.Default.password, LoginLocators);
            // TODO add loading elementid
           WaitForPageToLoad();
            // TODO word to check u r logged in  
            if (driver.Url.Contains("Workspace"))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public void RegisterationForm()
        {
            //TODO use helperas other functions
            //help.FindElement(By.Id("firstname")).SendKeys("magdy");
            //help.FindElement(By.Id("lastname")).SendKeys("ahmed");
            //new SelectElement(help.FindElement(By.Id("department"))).SelectByIndex(3);
            //new SelectElement(help.FindElement(By.Id("positionlevel"))).SelectByText("test position".ToLower());
            //help.FindElement(By.Id("landlinenumber")).SendKeys("123456789");
            //help.FindElement(By.Id("mobilenumber")).SendKeys("1234567890");
            //help.FindElement(By.Id("email")).SendKeys("magdyahmed@test.com");
            //help.FindElement(By.Id("password")).SendKeys("P@ssw0rd");
            //help.FindElement(By.Id("confirmpassword")).SendKeys("P@ssw0rd");
            //help.FindElement(By.Id("submit")).Click();

        }
        public string ADDNewPOICompany(IWebDriver driver, WebDriverWait wait, string CompanyName, String Guid, PoiType poiType, PoiSubType poiSubType)
        {


            SelectByText(By.Id("company"), CompanyName);

            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("BriefDescription_"), "Test Brief Description" + Guid);
            ClickOn(By.Id("submit"), false);

            return ""; // TODO return created poiname
        }

        public string AssociateToGOCRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, string ParentGOC, String Guid)
        {
            ClickOn(By.Id("AssociatetoGOCRequest"), false);
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("gocname"), ParentGOC); //parent GOC
            SendKeys(By.Id("RequestDetails"), "Request Details"+Guid);
            ClickOn(By.Id("submit"),false);
            return ""; // TODO return created name
        }

        public string ChangeBrandRequest(IWebDriver driver, WebDriverWait wait, string CompanyName)
        {
            SelectByText(By.Id("company"), CompanyName);
            SelectByIndex(By.Id("newcategory"), 2); //new category
            ClickOn(By.Id("submit"), false);
            return ""; // TODO return created name
        }

        public string ChangeClusterRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, string Cluster,string Guid)
        {
            SelectByText(By.Id("company"), CompanyName);
            SelectByText(By.Id("newcluster"), Cluster);
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
            return ""; // TODO return created name
        }

        public void ChangePoiTypeRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, PoiType poiType, PoiSubType poiSubType, string Guid)
        {
            SelectByText(By.Id("company"), CompanyName); 

            SendKeys(By.Id("PoiName_"), "Poi Name" + Guid);
            SelectByText(By.Id("poitype"), poiType.ToString());
            SelectByText(By.Id("poi1subtype1"), poiSubType.ToString());
            SendKeys(By.Id("RequestJustification"), "Test Request Justification" + Guid);
            ClickOn(By.Id("submit"), false);
        }

        public void FestivalParticipationRequest(IWebDriver driver, WebDriverWait wait, string CompanyName, string EventName, Participationtype participationtype)
        {

            ClickOn(By.Id("next"),false);
            SelectByText(By.Id("company"), CompanyName);
            WaitForPageToLoad();
            SelectByText(By.Id("event"), EventName); 
            WaitForPageToLoad();
            SelectByText(By.Id("participationtype"), participationtype.ToString()); 
            WaitForPageToLoad();

            ClickOn(By.Id("next"), false);

        }

        private void WaitForPageToLoad()
        {
            WaitTillPageLoad(By.ClassName(LoaderClassName));
        }

        public void RetailCalendarParticipationRequest(IWebDriver driver)
        {
            // TODO Edit
            //help.FindElement(By.Id("ServicesDropdown")).Click();
            //help.FindElement(By.Id("calendarmanagement")).Click();
            //help.FindElement(By.Id("CalendarParticicpationRequest")).Click();
            //help.FindElement(By.Id("next")).Click();
            //help.SelectByIndex(By.Id("company"), 2);// el mfrod el company that created
            //help.SelectByIndex(By.Id("calendar"), 2); //Calendar that created from CRM and published
            //help.FindElement(By.Id("next")).Click();
            //driver.WaitForPageToLoad();

            //help.FindElement(By.Id("branchesCheck0")).Click();
            //help.FindElement(By.Id("branchesCheck1")).Click();
            //help.FindElement(By.Id("branchesCheck2")).Click();
            //help.FindElement(By.Id("next")).Click();
            //help.FindElement(By.Id("checkedcontrol")).Click();
            //help.FindElement(By.Id("submit")).Click();
        }

    }
}
