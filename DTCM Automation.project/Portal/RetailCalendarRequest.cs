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
    class RetailCalendarRequest
    {
        TestHelper help = new TestHelper();
        public void RetailCalendarParticipationRequest(IWebDriver driver)
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("calendarmanagement")).Click();
            help.FindElement(By.Id("CalendarParticicpationRequest")).Click();
            help.FindElement(By.Id("next")).Click();
            help.SelectByIndex(By.Id("company"), 2);// el mfrod el company that created
            help.SelectByIndex(By.Id("calendar"), 2); //Calendar that created from CRM and published
            help.FindElement(By.Id("next")).Click();
            driver.WaitForPageToLoad();

            help.FindElement(By.Id("branchesCheck0")).Click();
            help.FindElement(By.Id("branchesCheck1")).Click();
            help.FindElement(By.Id("branchesCheck2")).Click();
            help.FindElement(By.Id("next")).Click();
            help.FindElement(By.Id("checkedcontrol")).Click();
            help.FindElement(By.Id("submit")).Click();
        }
    }
}
