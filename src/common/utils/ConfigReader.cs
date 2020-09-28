using System;
using System.Configuration;

namespace LinnworkTestTask.main.utils
{
    public class ConfigReader
    {
        static AppSettingsReader configurationAppSettings = new AppSettingsReader();

        public static String GetValue(String key)
        {
            return (string) configurationAppSettings.GetValue(key, typeof(string));
        }

        public static String GetAppUrl()
        {
            return GetValue("application.link");
        }
        
        public static String GetLoginToken()
        {
            return GetValue("login.token");
        }
    }
}