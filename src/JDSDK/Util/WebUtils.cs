using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace Jd.Api.Util
{
    /// <summary>
    /// 网络工具类。
    /// </summary>
    public sealed class WebUtils
    {
        private int _timeout = 60000;
        private int _readWriteTimeout = 100000;

        /// <summary>
        /// 请求与响应的超时时间
        /// </summary>
        public int Timeout
        {
            get { return this._timeout; }
            set { this._timeout = value; }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        /// <summary>
        /// 执行HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public String DoPost(String url, IDictionary<String, String> parameters, string Proxy = null)
        {
            string ret = "";
            HttpWebRequest req = null;
            HttpWebResponse rsp = null;
            int err = 0;
        retry:
            try
            {
                req = GetWebRequest(url, "POST");
#if DEBUG
                if (Proxy != null)
                {
                    string[] sip = Proxy.Split(':');
                    req.Proxy = new WebProxy(sip[0], Convert.ToInt32(sip[1]));
                }
#endif
                req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                Byte[] postData = Encoding.UTF8.GetBytes(BuildQuery(parameters));
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(postData, 0, postData.Length);
                reqStream.Close();

                rsp = (HttpWebResponse)req.GetResponse();
                Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
                ret = GetResponseAsString(rsp, encoding);
            }
            catch (WebException ex)
            {
                try
                {
                    string resp = "";
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    using (Stream data = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(data))
                        {
                            resp = reader.ReadToEnd();
                        }
                    }
                    Trace.WriteLine(resp);

                    if (err++ < 3)
                        goto retry;
                    if (err < 5)
                    {
                        req.ServicePoint.CloseConnectionGroup(req.ConnectionGroupName);
                        goto retry;
                    }

                    ret = resp;
                }
                catch (Exception exx)
                {
                    ret = ex.Message + ex.StackTrace + exx.Message + exx.StackTrace;
                }
            }
            finally
            {
                if (req != null) req.Abort();
                req = null;
                if (rsp != null) rsp.Close();
                rsp = null;
            }
            return ret;
        }

        /// <summary>
        /// 执行HTTP GET请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>HTTP响应</returns>
        public String DoGet(String url, IDictionary<String, String> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            HttpWebRequest req = GetWebRequest(url, "GET");
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }

        public String DoGet(String url, String refUrl, CookieContainer cookies, IDictionary<String, String> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            HttpWebRequest req = GetWebRequest(url, "GET");
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }

        /// <summary>
        /// 执行带文件上传的HTTP POST请求。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="textParams">请求文本参数</param>
        /// <param name="fileParams">请求文件参数</param>
        /// <returns>HTTP响应</returns>
        public String DoPost(String url, IDictionary<String, String> textParams, IDictionary<String, FileItem> fileParams)
        {
            // 如果没有文件参数，则走普通POST请求
            if (fileParams == null || fileParams.Count == 0)
            {
                return DoPost(url, textParams);
            }

            String boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线

            HttpWebRequest req = GetWebRequest(url, "POST");
            req.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;

            Stream reqStream = req.GetRequestStream();
            Byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            Byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            // 组装文本请求参数
            String textTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
            IEnumerator<KeyValuePair<String, String>> textEnum = textParams.GetEnumerator();
            while (textEnum.MoveNext())
            {
                String textEntry = String.Format(textTemplate, textEnum.Current.Key, textEnum.Current.Value);
                Byte[] itemBytes = Encoding.UTF8.GetBytes(textEntry);
                reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                reqStream.Write(itemBytes, 0, itemBytes.Length);
            }

            // 组装文件请求参数
            String fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
            IEnumerator<KeyValuePair<String, FileItem>> fileEnum = fileParams.GetEnumerator();
            while (fileEnum.MoveNext())
            {
                String key = fileEnum.Current.Key;
                FileItem fileItem = fileEnum.Current.Value;
                String fileEntry = String.Format(fileTemplate, key, fileItem.GetFileName(), fileItem.GetMimeType());
                Byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
                reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                reqStream.Write(itemBytes, 0, itemBytes.Length);

                Byte[] fileBytes = fileItem.GetContent();
                reqStream.Write(fileBytes, 0, fileBytes.Length);
            }

            reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            reqStream.Close();

            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding(rsp.CharacterSet);
            return GetResponseAsString(rsp, encoding);
        }

        public String DoPostHeader(String url, IDictionary<String, String> textParams, IDictionary<String, FileItem> fileParams)
        {
            // 如果没有文件参数，则走普通POST请求
            if (fileParams == null || fileParams.Count == 0)
            {
                return DoPost(url, textParams);
            }

            String boundary = "-------" + DateTime.Now.Ticks.ToString("X"); // 随机分隔线

            HttpWebRequest req = GetWebRequest(url, "POST");
            req.ContentType = "multipart/form-data; boundary=" + boundary;
            req.Accept = "*/*";

            Stream reqStream = req.GetRequestStream();
            Byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            Byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            // 组装文本请求参数
            IEnumerator<KeyValuePair<String, String>> textEnum = textParams.GetEnumerator();
            while (textEnum.MoveNext())
            {
                req.Headers.Add(textEnum.Current.Key, textEnum.Current.Value);
            }

            // 组装文件请求参数
            String fileTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            IEnumerator<KeyValuePair<String, FileItem>> fileEnum = fileParams.GetEnumerator();
            while (fileEnum.MoveNext())
            {
                String key = fileEnum.Current.Key;
                FileItem fileItem = fileEnum.Current.Value;
                String fileEntry = String.Format(fileTemplate, key, fileItem.GetFileName(), JdUtils.GetMimeType(fileItem.GetFileName()));
                Byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
                reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                reqStream.Write(itemBytes, 0, itemBytes.Length);

                Byte[] fileBytes = fileItem.GetContent();
                reqStream.Write(fileBytes, 0, fileBytes.Length);
            }

            reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            reqStream.Close();

            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            return GetResponseAsString(rsp, encoding);
        }

        public HttpWebRequest GetWebRequest(String url, String method)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ServicePoint.Expect100Continue = false;
            req.Method = method;
            req.KeepAlive = true;
            req.UserAgent = "JdSdk.NET V2.0 by StarPeng";
            req.Timeout = this._timeout;
            req.ReadWriteTimeout = this._readWriteTimeout;
            return req;
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static String GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                reader = null;
                if (stream != null) stream.Close();
                stream = null;
                if (rsp != null) rsp.Close();
            }
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public String BuildGetUrl(String url, IDictionary<String, String> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            return url;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static String BuildQuery(IDictionary<String, String> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<String, String>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                String name = dem.Current.Key;
                String value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(HttpUtility.UrlEncode(value));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }
    }
}