using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.Security;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using DTCM_Automation.project.Portal;


namespace DTCM_Automation.project.Portal
{
    [TestClass]
    public class Login
    {
        IWebDriver portalDriver;
        TestHelper help = new TestHelper();
       [TestMethod]
        public void login()
        {
            portalDriver = new ChromeDriver(Directory.GetCurrentDirectory());
            help.SetDriver(portalDriver);
            portalDriver.Url="http://ld-iis-dtcm.cloudapp.net/";
            portalDriver.Manage().Window.Maximize();
            //portalDriver.WaitTillPageLoad(By.ClassName("overlay"));
            portalDriver.WaitForPageToLoad();
            portalDriver.FindElements(By.Id("login"))[0].Click();
            Thread.Sleep(5000);
            portalDriver.FindElement(By.Id("email")).SendKeys("amir@dtcm.com");
            portalDriver.FindElement(By.Id("password")).SendKeys("P@ssw0rd");
            portalDriver.FindElements(By.Id("login"))[1].Click();
        }
 

    }
}
