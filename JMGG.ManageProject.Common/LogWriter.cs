using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Common
{
    public class LogWriter
    {
        private static string log4netConfigPath = AppDomain.CurrentDomain.BaseDirectory + "Config\\log4net.config";

        static LogWriter()
        {
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4netConfigPath));
        }

        private static ILog logMongo = LogManager.GetLogger(typeof(LogWriter));

        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        public static void debug(object message)
        {

            Task.Run(() =>
            {
                try
                {
                    logMongo.Debug(message);
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        /// <param name="straceInfo">堆栈信息</param>
        public static void error(object message, string straceInfo = "")
        {
            Task.Run(() =>
            {
                try
                {
                    if (straceInfo == "")
                    {
                        logMongo.Error(message);
                    }
                    else
                    {
                        var msg = string.Format("\r\n[Comment]{0}\r\n[StackTrace]{1}\r\n", message, straceInfo);
                        logMongo.Error(msg);
                    }
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志 异步
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        /// <param name="ClassName">类名</param>
        public static void error(object message, Type ClassName)
        {
            Task.Run(() =>
            {
                try
                {
                    ILog logMongo55 = LogManager.GetLogger(ClassName);
                    logMongo55.Error(message);
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        /// <param name="ex">Exception</param>
        public static void error(object message, Exception ex)
        {
            Task.Run(() =>
            {
                try
                {
                    logMongo.Error(message, ex);
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        public static void fatal(object message)
        {
            Task.Run(() =>
            {
                try
                {
                    logMongo.Fatal(message);
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        /// <param name="straceInfo">堆栈信息</param>
        public static void info(object message, string straceInfo = "")
        {
            Task.Run(() =>
            {
                try
                {
                    if (straceInfo == "")
                    {
                        logMongo.Info(message);
                    }
                    else
                    {
                        var msg = string.Format("\r\n[Comment]{0}\r\n[StackTrace]{1}\r\n", message, straceInfo);
                        logMongo.Info(msg);
                    }
                }
                catch (Exception e) { }
            });
        }
        /// <summary>
        /// Mongo日志
        /// </summary>
        /// <param name="message">对象包括字符串</param>
        public static void warn(object message)
        {
            Task.Run(() =>
            {
                try
                {
                    logMongo.Warn(message);
                }
                catch (Exception e) { }
            });
        }

        /// <summary>
        /// 获取堆栈String
        /// </summary>
        /// <returns></returns>
        public static string GetFramesString(bool Head = true)
        {
            try
            {
                StringBuilder frames = new StringBuilder();
                if (Head) frames.Append("\r\n--------前台-------业务堆栈Start----------------");
                foreach (StackFrame Frame in new StackTrace().GetFrames())
                {
                    if (Frame.GetMethod().DeclaringType == null || Frame.GetMethod().Name == null || Frame.GetMethod().DeclaringType.ToString().StartsWith("System.")//不打出系统堆栈
                        || "GetFramesString" == Frame.GetMethod().Name/*不打出本方法堆栈*/)
                    {
                        continue;
                    }
                    frames.AppendFormat("\r\n类：{0},方法：{1}", Frame.GetMethod().DeclaringType, Frame.GetMethod().Name);
                }
                if (Head) frames.Append("\r\n------------------业务堆栈end------------------");
                return frames.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
