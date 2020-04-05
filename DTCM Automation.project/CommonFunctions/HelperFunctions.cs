using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.Dynamics365.UIAutomation.Api;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DTCM_Automation.project.Common
{
    public class HelperFunctions
    {

        public void ClickOnMenue(Browser xrmBrowser)
        {
            try
            {
                xrmBrowser.Entity.SwitchToDefaultContent();
                // check if crmRibbonManager is shown
                if (xrmBrowser.Driver.IsVisible(By.Id("crmRibbonManager")))
                {
                    var topItem = xrmBrowser.Driver.FindElements(By.ClassName(Elements.CssClass[Reference.Navigation.TopLevelItem])).FirstOrDefault();
                    var items = topItem?.FindElements(By.ClassName(Elements.ElementId[Reference.Navigation.HomeTab]));
                    topItem?.FindElements(By.ClassName(Elements.ElementId[Reference.Navigation.HomeTab]))[3].Click();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
