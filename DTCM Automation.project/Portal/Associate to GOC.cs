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
    class AssociatetoGOC
    {
        TestHelper help = new TestHelper();
        public void AssociateToGOCRequest()
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("retailservices")).Click();
            help.FindElement(By.Id("AssociatetoGOCRequest")).Click();
            help.SelectByIndex(By.Id("company"), 2);// el mfrod el company that created
            help.SelectByIndex(By.Id("gocname"), 2); //parent GOC
            help.FindElement(By.Id("RequestDetails")).SendKeys("Request just");
            help.FindElement(By.Id("submit")).Click();
        }
    }
}
