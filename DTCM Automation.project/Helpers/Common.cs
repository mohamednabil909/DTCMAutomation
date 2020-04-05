using System;
using System.Globalization;
using System.IO;
using DTCM_Automation.project.Properties;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DTCM_Automation.project.Reporting;

namespace DTCM_Automation.project
{
    public class Common : TestHelper
    {
        internal Settings Settings = Properties.Settings.Default;

        public enum LocalizationKeys
        {
            RequestSubmittedSuccessfullyMessage
        }

        public enum LogFiles
        {
            RequestsLogFile,
            IssuesLogFile,
            CommandsLogFile
        }

        public string LocalizedValueOf(Enum value)
        {
            return null;// System.Resources.ResourceManager.GetString(value.ToString(), new CultureInfo(Settings.Language.ToString()));
        }
    }
}