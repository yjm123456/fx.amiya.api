using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using System.Net;

namespace Jd.ACES.Common
{
    public class HttpClientWrapper
    {
        public static string SendData(string requestUrl, string method, string payload,
            Dictionary<string, string> additional)
        {
            HttpWebRequest req = WebRequest.Create(requestUrl) as HttpWebRequest;
            req.Method = method;

            var property = typeof(WebHeaderCollection).GetProperty("InnerCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (property != null)
            {
                var collection = property.GetValue(req.Headers, null) as NameValueCollection;
                foreach (KeyValuePair<string, string> param in additional)
                {
                    collection[param.Key] = param.Value;
                }
            }

            byte[] data = Encoding.UTF8.GetBytes(payload);
            req.ContentLength = data.Length;

            using (var reqStream = req.GetRequestStream()) {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }            

            string result = null;
            using (var resp = req.GetResponse() as HttpWebResponse)
            using (var stream = resp.GetResponseStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
