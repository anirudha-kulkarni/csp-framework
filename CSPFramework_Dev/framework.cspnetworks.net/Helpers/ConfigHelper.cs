using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace framework.cspnetworks.net.Helpers
{
    public class ConfigHelper
    {
        public static string InternalIPAddress
        {
            get
            {
                return ConfigurationManager.AppSettings["Internal_IP"].ToString();
            }
        }
        public static int InternalExpiration
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Internal_Expiration"]);
            }
        }
        public static int ExternalExpiration
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["External_Expiration"]);
            }
        }
        public static int InternalSessionExpiration
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["Internal_Session_Timeout"]);
            }
        }
        public static int ExternalSessionExpiration
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["External_Session_Timeout"]);
            }
        }
    }
}