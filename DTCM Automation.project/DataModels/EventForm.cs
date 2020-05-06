using DTCM_Automation.project.CommonFunctions;
using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DTCM_Automation.project.DataModels;
using static DTCM_Automation.project.CommonFunctions.Enums;

namespace DTCM_Automation.project.DataModels
{
    class EventForm
    {
        CommonFunctions.CommonFunctions commonFunctions = new CommonFunctions.CommonFunctions();
        public void Navigateto(Browser xrmBrowser)
        {
            commonFunctions.NavigateTo(xrmBrowser, "Event Management", "Events");
            xrmBrowser.CommandBar.ClickCommand("New");
        }

        
        public void FillCalendarform(Browser xrmbrowser, EventType eventType, string CalendarName, string EventName)
        {
            if (eventType == EventType.Festival)
            {
                xrmbrowser.Entity.SetValue("ldv_name_en", "New Festival Automation");
                xrmbrowser.Entity.SetValue("ldv_name_ar", "تست فيستيفال");
                xrmbrowser.Entity.SetValue(new OptionSet() { Name = "ldv_eventtypecode", Value = eventType.ToString() });

                xrmbrowser.Entity.SelectLookup("ldv_calendarid");
                Thread.Sleep(5000);
                xrmbrowser.Lookup.Search(CalendarName.ToString());
                xrmbrowser.Lookup.Add();

                xrmbrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("4/6/2020"));
                xrmbrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("6/1/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("3/2/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("5/25/2020"));

                xrmbrowser.Entity.SetValue("ldv_descriptionen", "descriptionen");
                xrmbrowser.Entity.SetValue("ldv_descriptionar", "تفاصيل");

                xrmbrowser.CommandBar.ClickCommand("Save");

                // xrmbrowser.CommandBar.ClickCommand("Publish");

            }

            else if (eventType == EventType.Activation)
            {
                xrmbrowser.Entity.SetValue("ldv_name_en", "New Activation Automation");
                xrmbrowser.Entity.SetValue("ldv_name_ar", "تست اكتيفيشن");
                xrmbrowser.Entity.SetValue(new OptionSet() { Name = "ldv_eventtypecode", Value = eventType.ToString() });


                xrmbrowser.Entity.SelectLookup("ldv_parentinitiativeid");
                Thread.Sleep(5000);
                xrmbrowser.Lookup.Search(EventName.ToString());
                xrmbrowser.Lookup.Add();
                
                
                xrmbrowser.Entity.SelectLookup("ldv_calendarid");
                Thread.Sleep(5000);
                xrmbrowser.Lookup.Search(CalendarName.ToString());
                xrmbrowser.Lookup.Add();

                xrmbrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("7/1/2020"));
                xrmbrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("9/1/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("6/29/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("8/1/2020"));

                xrmbrowser.Entity.SetValue("ldv_descriptionen", "descriptionen");
                xrmbrowser.Entity.SetValue("ldv_descriptionar", "تفاصيل");

                xrmbrowser.CommandBar.ClickCommand("Save");

                // xrmbrowser.CommandBar.ClickCommand("Publish");
            }

            else
            {
                xrmbrowser.Entity.SetValue("ldv_name_en", "New off season Automation");
                xrmbrowser.Entity.SetValue("ldv_name_ar", "تست اوف سيزون");
                xrmbrowser.Entity.SetValue(new OptionSet() { Name = "ldv_eventtypecode", Value = eventType.ToString() });

                xrmbrowser.Entity.SelectLookup("ldv_calendarid");
                Thread.Sleep(5000);
                xrmbrowser.Lookup.Search(CalendarName.ToString());
                xrmbrowser.Lookup.Add();

                xrmbrowser.Entity.SetValue("ldv_startdate", DateTime.Parse("4/6/2020"));
                xrmbrowser.Entity.SetValue("ldv_enddate", DateTime.Parse("6/1/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationstartdate", DateTime.Parse("3/2/2020"));
                xrmbrowser.Entity.SetValue("ldv_participationenddate", DateTime.Parse("5/25/2020"));

                xrmbrowser.Entity.SetValue("ldv_descriptionen", "descriptionen");
                xrmbrowser.Entity.SetValue("ldv_descriptionar", "تفاصيل");

                xrmbrowser.CommandBar.ClickCommand("Save");
            }
        }
    }
}