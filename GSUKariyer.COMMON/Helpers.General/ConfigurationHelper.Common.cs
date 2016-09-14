using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace GSUKariyer.COMMON
{
    public partial class ConfigurationHelper
    {
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static ConnectionStringSettings GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key];
        }
    }
}
