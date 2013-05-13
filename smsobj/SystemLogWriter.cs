using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Reflection;

//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）
//如果是WebForm，则从web.config中读取相关信息
[assembly: log4net.Config.DOMConfiguratorAttribute(ConfigFile = "log4net.config", ConfigFileExtension = "config", Watch = true)]

namespace SmsObj
{
   public static class SystemLogWriter
    {
       //日志记录实例
       public static ILog NewLogger()
       {
           //创建日志记录组件实例
           return log4net.LogManager.GetLogger("File");
           
       }
       //记录一般信息
       public static void Info(object msg)
       {
           NewLogger().Info(msg);
       }
       //记录错误信息
       public static void Error(object msg)
       {
           NewLogger().Error(msg);
       }
       //记录严重错误
       public static void Fatal(object msg, Exception e)
       {
           NewLogger().Fatal(msg, e);
       }
       //记录调试信息
       public static void Debug(object msg)
       {
           NewLogger().Debug(msg);
       }
       //记录警告信息
       public static void Warn(object msg)
       {
           NewLogger().Warn(msg);
       }
       
    }
}
