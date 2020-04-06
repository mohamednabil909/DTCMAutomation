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
    public class Main_Class
    {
        
        [TestMethod]
        public void Main() 
        {
            Login log = new Login();
            log.login();

            RegisterNewCompany register = new RegisterNewCompany();
            register.Regisetrcompany();
        
        }

    }
}
