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
    class AddNewPOI
    {
        TestHelper help = new TestHelper();
        public void ChangeClusterRequest()
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("attractionservices")).Click();
            help.FindElement(By.Id("AddNewPOI")).Click();
            help.SelectByIndex(By.Id("company"), 4); 
            help.FindElement(By.Id("PoiName_")).SendKeys("test123456");
            help.SelectByIndex(By.Id("poitype"), 0);
            help.SelectByIndex(By.Id("poi1subtype1"), 0);
            help.FindElement(By.Id("BriefDescription_")).SendKeys("test123456test123456");
            help.FindElement(By.Id("submit")).Click();
        }

    }
}
