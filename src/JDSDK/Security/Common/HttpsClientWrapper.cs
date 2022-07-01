using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.Reflection;
using log4net;
using Jd.ACES.Utils;

namespace Jd.ACES.Common
{
    public class HttpsClientWrapper
    {
        private static ILog LOGGER = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string PostJson(string requestUrl, string payload)
        {
            string result = null;
            string rootCause = null;
            bool hasConn = false;
            HttpWebRequest req = null;

            var header = GetHeaderProperty();
            var data = Encoding.UTF8.GetBytes(payload);

            for (int i = 0; !hasConn && i < Constants.HTTP_RETRY_MAX; i++)
            {
                try
                {
                    req = WebRequest.Create(requestUrl) as HttpWebRequest;
                    req.Method = "POST";

                    var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (property != null)
                    {
                        var collection = property.GetValue(req.Headers, null) as NameValueCollection;
                        foreach (KeyValuePair<string, string> param in header)
                        {
                            collection[param.Key] = param.Value;
                        }
                    }

                    using (var reqStream = req.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                    }

                    using (var resp = req.GetResponse() as HttpWebResponse)
                    using (var stream = resp.GetResponseStream())
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }

                    hasConn = true;
                }
                catch (Exception e)
                {
                    rootCause = e.Message;
                    LOGGER.Warn(e.Message);
                }
            }
            if (!hasConn)
            {
                LOGGER.FatalFormat("HTTPS Client cannot establish connections: {0}", rootCause);
                throw new SystemException("HTTPS Client cannot establish connections: " + rootCause);
            }

            return result;
        }
        
        private static Dictionary<string, string> GetHeaderProperty()
        {
            return new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Connection", "keep-alive" },
                { "Content-Type", "application/x-www-form-urlencoded;charset=UTF-8"},
                { "Timestamp",  EnvironmentHelper.GetCurrentMillis().ToString()}
            };
        }

    }

}
