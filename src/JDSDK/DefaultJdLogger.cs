using System;
using System.Diagnostics;
using System.IO;

namespace Jd.Api
{
    /// <summary>
    /// 日志打点的简单实现。
    /// </summary>
    public class DefaultJdLogger : IJdLogger
    {
        public const string LOG_FILE_NAME = "jdsdk.log";
        public const string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        static DefaultJdLogger()
        {
        }

        public void Error(string message)
        {
            Trace.WriteLine(message, DateTime.Now.ToString(DATETIME_FORMAT) + " ERROR");
        }

        public void Warn(string message)
        {
            Trace.WriteLine(message, DateTime.Now.ToString(DATETIME_FORMAT) + " WARN");
        }

        public void Info(string message)
        {
            Trace.WriteLine(message, DateTime.Now.ToString(DATETIME_FORMAT) + " INFO");
        }
    }
}
