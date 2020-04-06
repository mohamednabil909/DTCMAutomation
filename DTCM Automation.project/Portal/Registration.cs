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
using System.IO;

namespace DTCM_Automation.project.Portal
{
    [TestClass]
    public class Registration
    {
        IWebDriver portalDriver;
        TestHelper help = new TestHelper();
        [TestMethod]
        public void Registeration() 
        {
            portalDriver = new ChromeDriver(Directory.GetCurrentDirectory());
            help.SetDriver(portalDriver);
            help.GoToUrl("http://ld-iis-dtcm.cloudapp.net/");
            help.WaitTillPageLoad(By.ClassName(""));
            help.FindElement(By.Id("login")).Click();
            help.FindElement(By.Id("firstname")).SendKeys("magdy");
            help.FindElement(By.Id("lastname")).SendKeys("ahmed");
            new SelectElement(help.FindElement(By.Id("department"))).SelectByIndex(3);
            new SelectElement(help.FindElement(By.Id("positionlevel"))).SelectByText("test position".ToLower());
            help.FindElement(By.Id("landlinenumber")).SendKeys("123456789");
            help.FindElement(By.Id("mobilenumber")).SendKeys("1234567890");
            help.FindElement(By.Id("email")).SendKeys("magdyahmed@test.com");
            help.FindElement(By.Id("password")).SendKeys("P@ssw0rd");
            help.FindElement(By.Id("confirmpassword")).SendKeys("P@ssw0rd");
            help.FindElement(By.Id("submit")).Click();

        }

    }
}
