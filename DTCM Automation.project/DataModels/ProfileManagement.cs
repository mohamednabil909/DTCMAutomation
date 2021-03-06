﻿using DTCM_Automation.project.CommonFunctions;
using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DTCM_Automation.project.CommonFunctions;
using DTCM_Automation.project.DataModels;


namespace DTCM_Automation.project.DataModels
{
    class ProfileManagement
    {
        CommonFunctions.CommonFunctions commonFunctions = new CommonFunctions.CommonFunctions();
        public void Navigateto(Browser xrmBrowser)
        {
            commonFunctions.NavigateTo(xrmBrowser, "Profile Management", "Profile Management Requests");
        }

        string brandname;
        public string fillbrandform(Browser xrmBrowser, string company_Name)
        {
            
            xrmBrowser.Entity.SetValue("ldv_tradename_en", "brand new");
            xrmBrowser.Entity.SelectLookup("parentaccountid");
            xrmBrowser.Lookup.Search(company_Name.ToString());
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SelectLookup("ldv_categoryid");
            xrmBrowser.Lookup.SelectItem(2);
            xrmBrowser.Lookup.Add();

            xrmBrowser.CommandBar.ClickCommand("Save");
            return brandname;
        }
        //brand name that return from generated new brand
        public void fillbranchform(Browser xrmBrowser, string Brand_Name)
        {
            xrmBrowser.Entity.SetValue(new OptionSet() { Name = "ldv_branchtypecode", Value = "Mall" });

            xrmBrowser.Entity.SelectLookup("ldv_mallid");
            xrmBrowser.Lookup.SelectItem(1);
            xrmBrowser.Lookup.Add();

            xrmBrowser.Entity.SetValue("ldv_licenseno", "148det");

            xrmBrowser.Entity.SelectLookup("parentaccountid");
            xrmBrowser.Lookup.Search(Brand_Name.ToString());
            xrmBrowser.Lookup.Add();

            xrmBrowser.CommandBar.ClickCommand("Save");

        }

    
    
    
    }
}
