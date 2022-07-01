using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;

namespace Fx.Amiya.Service
{
    public class SignHelper 
    {
        public async Task<string> BuildQueryAsync(IDictionary<string, string> dict, bool encode)
        {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(dict);
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = false;
            IEnumerator<KeyValuePair<string, string>> enumerator = sortedDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                string key = current.Key;
                current = enumerator.Current;
                string value = current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    if (flag)
                    {
                        stringBuilder.Append("&");
                    }
                    stringBuilder.Append(key);
                    stringBuilder.Append("=");
                    if (encode)
                    {
                        stringBuilder.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    }
                    else
                    {
                        stringBuilder.Append(value);
                    }
                    flag = true;
                }
            }
            return stringBuilder.ToString();
        }

        public async Task<string> BuildXmlAsync(IDictionary<string, string> dict, bool encode)
        {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(dict);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<xml>");
            IEnumerator<KeyValuePair<string, string>> enumerator = sortedDictionary.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = enumerator.Current;
                string key = current.Key;
                current = enumerator.Current;
                string value = current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    decimal num = 0m;
                    bool flag = false;
                    if (!decimal.TryParse(value, out num))
                    {
                        flag = true;
                    }
                    if (encode)
                    {
                        stringBuilder.AppendLine(string.Concat(new string[]
                        {
                            "<",
                            key,
                            ">",
                            flag ? "<![CDATA[" : "",
                            HttpUtility.UrlEncode(value, Encoding.UTF8),
                            flag ? "]]>" : "",
                            "</",
                            key,
                            ">"
                        }));
                    }
                    else
                    {
                        stringBuilder.AppendLine(string.Concat(new string[]
                        {
                            "<",
                            key,
                            ">",
                            flag ? "<![CDATA[" : "",
                            value,
                            flag ? "]]>" : "",
                            "</",
                            key,
                            ">"
                        }));
                    }
                }
            }
            stringBuilder.AppendLine("</xml>");
            return stringBuilder.ToString();
        }

        public async Task<string> SignPackage(IDictionary<string, string> parameters, string partnerKey)
        {
            string text = await BuildQueryAsync(parameters, false);
            text += string.Format("&key={0}", partnerKey);
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                var strResult = BitConverter.ToString(result);
                return (strResult.Replace("-", "").ToUpper());
            }
        }

        public async Task<string> SignPay(IDictionary<string, string> parameters, string key = "")
        {
            string text = await BuildQueryAsync(parameters, false);
            text += string.Format("&key={0}", key);
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                var strResult = BitConverter.ToString(result);
                return (strResult.Replace("-", "").ToUpper());
            }
        }
    }
}
