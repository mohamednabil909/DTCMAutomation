using DTCM_Automation.project.CommonFunctions;
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
    class Calendarform
    {
        CommonFunctions.CommonFunctions commonFunctions = new CommonFunctions.CommonFunctions();
        public void Navigateto(Browser xrmBrowser)
        {
            commonFunctions.NavigateTo(xrmBrowser, "Event Management", "Calendars");
            xrmBrowser.CommandBar.ClickCommand("New");
        }

        string calendarname;
        public string FilCalendarform(Browser xrmbrowser,CommonFunctions.CommonFunctions.CalendarType calendarType)
        {
            xrmbrowser.Entity.SetValue("ldv_name_en", "New Calenddar Automation");
            xrmbrowser.Entity.SetValue("ldv_name_ar", "تست كاليندر");
            xrmbrowser.Entity.SetValue(new OptionSet() { Name = "ldv_calendartypecode", Value = calendarType.ToString() });
            xrmbrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("1/1/2020"));
            xrmbrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("12/1/2020"));
            xrmbrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("1/5/2020"));
            xrmbrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("12/1/2020"));

            xrmbrowser.Entity.SelectLookup("ldv_pricelistid");
            Thread.Sleep(5000);
            xrmbrowser.Lookup.Search("DSF PL");
            xrmbrowser.Lookup.Add();

            xrmbrowser.CommandBar.ClickCommand("Save");

            xrmbrowser.CommandBar.ClickCommand("Publish");
            return calendarname;
        }
    }
}
