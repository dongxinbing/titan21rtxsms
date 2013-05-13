using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SmsObj
{
   public class MyConfigManager
    {
        
        public MyConfigManager()
        {
            
        }

        public static string GetRTXServerIP()
        {
            return ConfigurationManager.AppSettings["rtxserverip"].ToString();
        }
        public static short GetRTXServerPort()
        {
            return Convert.ToInt16(ConfigurationManager.AppSettings["rtxserverport"].ToString());
        }
        public static string GetManDaoSerialNumber()
        {
            return ConfigurationManager.AppSettings["mandaoserialnumber"].ToString();
        }
        public static string GetManDaoSerialPassword()
        {
            return ConfigurationManager.AppSettings["mandaoserialpassword"].ToString();
        }

        public static string GetLogConnStr()
        {
            return ConfigurationManager.AppSettings["logconn"].ToString();
        }

    }
}
