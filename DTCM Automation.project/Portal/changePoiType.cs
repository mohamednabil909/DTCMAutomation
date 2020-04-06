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
    class changePoiType
    {
        TestHelper help = new TestHelper();
        public void ChangePoiTypeRequest()
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("attractionservices")).Click();
            help.FindElement(By.Id("UpdatePoiType")).Click();
            help.SelectByIndex(By.Id("company"), 2); // elmfrod el company that created from poi request
            help.SelectByIndex(By.Id("poitype"), 3);
            help.SelectByIndex(By.Id("poisubtype1"), 1);
            help.FindElement(By.Id("RequestJustification")).SendKeys("test123456");
            help.FindElement(By.Id("submit")).Click();
        }
    }
}
