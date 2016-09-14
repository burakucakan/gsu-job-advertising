using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace GSUKariyer.COMMON
{
    public class Logger
    {
        public static void LogErrors(string errorMessage)
        {
           
            try
            {
                //using (new Impersonator(ConfigurationManager.AppSettings[GlobalValues.AppSettings.ImpersonatedUserUserName], ConfigurationManager.AppSettings[GlobalValues.AppSettings.ImpersonatedUserDomain], ConfigurationManager.AppSettings[GlobalValues.AppSettings.ImpersonatedUserPassword]))
                //{
                    string logName = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.LogName);
                    string appName = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.AppName);

                    if (!EventLog.SourceExists(appName))
                        EventLog.CreateEventSource(appName, logName);

                    EventLog.WriteEntry(appName, errorMessage, EventLogEntryType.Error);
                //}
            }
            catch (Exception ex)
            {
                string errorFilePath = ConfigurationHelper.GetAppSetting(ConfigurationHelper.AppSettingKeys.UnloggedErrorsFilePath);
                if (String.IsNullOrEmpty(errorFilePath))
                    return;
                    //throw new Exception(String.Format("No UnloggedErrorsFilePath ! Error:{0} - Error Message:{1} ", ex.Message, errorMessage));


                StreamWriter logWriter = null;

                if (File.Exists(errorFilePath))
                    logWriter = new StreamWriter(errorFilePath, true);
                else
                    logWriter = File.CreateText(errorFilePath);

                logWriter.WriteLine("***********************************************");
                logWriter.WriteLine(String.Format("{0} Error : {1}", DateTime.Now.ToString(), ex.ToString()));
                logWriter.WriteLine(String.Format("    ** Error Message : {0}", errorMessage));
                logWriter.WriteLine("***********************************************");
                logWriter.WriteLine("");

                logWriter.Close();
                logWriter = null;
            }
           /* */
        }
    }
}
