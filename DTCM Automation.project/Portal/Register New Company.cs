using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using DTCM_Automation.project.CommonFunctions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace DTCM_Automation.project.Portal
{

    public class RegisterNewCompany
    {
        TestHelper help = new TestHelper();
        IWebDriver Portaldriver = new ChromeDriver();
        public void Regisetrcompany() 
        {
            Portaldriver.WaitForPageToLoad();
           // Portaldriver.FindElement(By.Id("ServicesDropdown")).Click();
            
           // Portaldriver.FindElement(By.XPath("//*[@id=\"navbarSupportedContent\"]/ul/li[2]")).Click();
            Portaldriver.FindElement(By.Id("retailservices")).Click();
            Portaldriver.FindElement(By.Id("RegisterNewCompany")).Click();
           // Portaldriver.SelectByText(By.Id("licensetype"),"DED");
            //new SelectElement(help.FindElement(By.Id("licensetype"))).SelectByIndex(0);
            //help.FindElement(By.Id("licenseno")).SendKeys("547851426");
            //help.SetDate(DateTime.Today.AddMonths(2),By.ClassName("btn calendar"),By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[2]/div/ngb-datepicker-month-view"),By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[1]/button"),By.XPath("//*[@id=\"licenseissuancedate\"]/div/div/ngb-datepicker/div[1]/ngb-datepicker-navigation/div[2]/button"));
            //help.FindElement(By.Id("gettid")).Click();
            //help.FindElement(By.Id("submit")).Click();

           // return companyname;
        }
        
    }
}
