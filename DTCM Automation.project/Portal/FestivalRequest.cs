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
    class FestivalRequest
    {
        TestHelper help = new TestHelper();
        public void FestivalParticipationRequest(IWebDriver driver)
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("checkedcontrol")).Click();
            help.FindElement(By.Id("initiativeparticipationrequest")).Click();
            help.FindElement(By.Id("next")).Click();
            help.SelectByIndex(By.Id("company"), 2);// el mfrod el company that created and participated in Retail Calendar
            driver.WaitForPageToLoad();
            help.SelectByIndex(By.Id("event"), 2); //Event that created from CRM and published
            driver.WaitForPageToLoad();
            help.SelectByIndex(By.Id("participationtype"), 0); //promotions
            driver.WaitForPageToLoad();

            help.FindElement(By.Id("next")).Click();
            
        }
    }
}
