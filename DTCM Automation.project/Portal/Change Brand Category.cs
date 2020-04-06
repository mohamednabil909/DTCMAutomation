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
    class ChangeBrandCategory
    {
        TestHelper help = new TestHelper();
        public void ChangeBrandRequest()
        {
            help.FindElement(By.Id("ServicesDropdown")).Click();
            help.FindElement(By.Id("retailservices")).Click();
            help.FindElement(By.Id("ChangeBrandCategoryRequest")).Click();
            help.SelectByIndex(By.Id("company"), 2);// el mfrod el company that created
            help.SelectByIndex(By.Id("newcategory"), 2); //new category
            help.FindElement(By.Id("submit")).Click();
        }
    }
}
