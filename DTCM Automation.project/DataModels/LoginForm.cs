using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using DTCM_Automation.project.CommonFunctions;
using OpenQA.Selenium.Support.UI;


namespace DTCM_Automation.project.Steps
{
    class LoginForm
    {
        TestHelper testHelper = new TestHelper();
        public void login()
        {
            testHelper.GoToUrl(Properties.Settings.Default.portalLoginURL);
            testHelper.ClickOn(By.Id("login"),true);
            testHelper.FrontendLogin(Properties.Settings.Default.username, Properties.Settings.Default.password, new By[] {By.Id("Email"), By.Id("password"), By.Id("login") });
        }
        String CompanyDED_Name;
        public string RegisternewcompanyDED()
        {
            
            testHelper.ClickOn(By.Id("ServicesDropdown"), true);
            testHelper.ClickOn(By.Id("retailservices"), true);
            testHelper.ClickOn(By.Id("RegisterNewCompany"), true);
            testHelper.SelectByValue(By.Id("licensetype"),CommonFunctions.CommonFunctions.LisenceNumber.DED.ToString());
            testHelper.SendKeys(By.Id("licenseno"),"48521475de");
            testHelper.SetDate(DateTime.Now, By.ClassName("btn calendar"), By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[2]/div/ngb-datepicker-month-view"), By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[1]/button"), By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[2]/button"));
            testHelper.ClickOn(By.Id("gettid"), true);
            testHelper.ClickOn(By.Id("submit"), true);
            return CompanyDED_Name;
        }

        string companyNONDED_Name;
        public string RegisternewcompanyNONDED()
        {
            testHelper.ClickOn(By.Id("ServicesDropdown"), true);
            testHelper.ClickOn(By.Id("retailservices"), true);
            testHelper.ClickOn(By.Id("RegisterNewCompany"), true);
            testHelper.SelectByValue(By.Id("licensetype"), CommonFunctions.CommonFunctions.LisenceNumber.NonDED.ToString());
            testHelper.SendKeys(By.Id("licenseno"), "48521475d5");
            testHelper.ClickOn(By.Id("82942235 - 0a58 - cda3 - d225 - ab47dc2cfe56"), true);
            //testHelper.UploadAttachments(,); Ezay Msh 3arf
            testHelper.ClickOn(By.Id("submit"), true);
            return companyNONDED_Name;
        }

        string Brand_Name;
        public string BrandForm()
        {
            testHelper.ClickOn(By.Id("ManagementDropdown"), true);
            testHelper.ClickOn(By.Id("Companies"), true);
            //Search 3 company elly mltlha create w open it
            testHelper.XPathMaker(TestHelper.HtmlTag.button, TestHelper.Attribute.Class, " btn-style waves-effect waves-light");
            testHelper.SendKeys(By.Id("brandnameen"), "Brand Auto portal");
            testHelper.SelectByValue(By.Id("category"), "Accessories".ToLower());
            testHelper.ClickOn(By.Id("submit"), true);
            return Brand_Name;
        }

        string branch_Name;
        public string BranchForm()
        {
            testHelper.ClickOn(By.Id("ManagementDropdown"), true);
            testHelper.ClickOn(By.Id("Companies"), true);
            //Search 3 company elly mltlha create w open it
            //Search 3 brand elly mltlha create w open it
            testHelper.XPathMaker(TestHelper.HtmlTag.button, TestHelper.Attribute.Class, " btn-style waves-effect waves-light");
            testHelper.ClickOn(By.Id("typestandalone"), true);
            testHelper.SelectByValue(By.Id("area"), "deira".ToLower());
            testHelper.SendKeys(By.Id("licenseno"), "54er8");
            testHelper.SendKeys(By.Id("Street1"), "Street");
            testHelper.ClickOn(By.Id("submit"), true);
            




            return branch_Name;
            ;
        }
    }
}
