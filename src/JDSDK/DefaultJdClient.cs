using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Jd.Api.Parser;
using Jd.Api.Request;
using Jd.Api.Util;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Jd.Api
{
    /// <summary>
    /// 基于REST的Jd客户端。
    /// </summary>
    public class DefaultJdClient : IJdClient
    {
        public const string APP_KEY = "app_key";
        public const string APP_PARAM = "360buy_param_json";
        public const string FORMAT = "format";
        public const string METHOD = "method";
        public const string TIMESTAMP = "timestamp";
        public const string VERSION = "v";
        public const string SIGN = "sign";
        public const string ACCESSTOKEN = "access_token";
        public const string FORMAT_XML = "xml";
        public const string FORMAT_JSON = "json";

        public string serverUrl;
        public string appKey;
        public string appSecret;
        public string accessToken;
        private string Proxy;
        private string format = FORMAT_JSON;
        private bool isJava = false;

        private WebUtils webUtils;
        private IJdLogger topLogger;

        private bool disableParser = false; // 禁用响应结果解释
        private bool disableTrace = true; // 禁用日志调试功能

        #region DefaultJdClient Constructors

        public DefaultJdClient(string serverUrl, string appKey, string appSecret, bool isJava = false)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            this.appKey = appKey;
            this.appSecret = appSecret;
            this.serverUrl = serverUrl;
            this.webUtils = new WebUtils();
            this.topLogger = new DefaultJdLogger();
            this.isJava = isJava;
        }
        public DefaultJdClient(string serverUrl, string appKey, string appSecret, string accessToken, string proxy)
           : this(serverUrl, appKey, appSecret)
        {
            this.Proxy = proxy;
            this.accessToken = accessToken;
        }
        public DefaultJdClient(string serverUrl, string appKey, string appSecret, string accessToken, bool isJava = false)
            : this(serverUrl, appKey, appSecret, isJava)
        {
            this.accessToken = accessToken;
        }

        #endregion

        public void SetTimeout(int timeout)
        {
            webUtils.Timeout = timeout;
        }

        public void SetDisableParser(bool disableParser)
        {
            this.disableParser = disableParser;
        }

        public void SetDisableTrace(bool disableTrace)
        {
            this.disableTrace = disableTrace;
        }

        public void SetJdLogger(IJdLogger topLogger)
        {
            this.topLogger = topLogger;
        }

        public void SetAccessToken(String accessToken)
        {
            this.accessToken = accessToken;
        }

        #region IJdClient Members

        public T Execute<T>(IJdRequest<T> request) where T : JdResponse
        {
            return Execute<T>(request, accessToken);
        }

        public T Execute<T>(IJdRequest<T> request, string accessToken) where T : JdResponse
        {
            return Execute<T>(request, accessToken, DateTime.Now);
        }

        public T Execute<T>(IJdRequest<T> request, string accessToken, DateTime timestamp) where T : JdResponse
        {
            if (disableTrace)
            {
                return DoExecute<T>(request, accessToken, timestamp);
            }
            else
            {
                try
                {
                    return DoExecute<T>(request, accessToken, timestamp);
                }
                catch (Exception e)
                {
                    topLogger.Error(this.serverUrl + "\r\n" + e.StackTrace);
                    throw e;
                }
            }
        }

        #endregion

        public string GetParamJson(IDictionary<string, string> parameters)
        {
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
            StringBuilder query = new StringBuilder("{");
            Boolean first = true;
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key))
                {
                    Trace.WriteLine(String.Format("参数：{0}  值：{1}", key, value));
                    if (!first)
                        query.Append(",");

                    query.AppendFormat("\"{0}\":\"{1}\"", key, value);
                    first = false;
                }
            }

            query.Append("}");
            return query.ToString();
        }

        private T DoExecute<T>(IJdRequest<T> request, string accessToken, DateTime timestamp) where T : JdResponse
        {
            // 提前检查业务参数
            try
            {
                request.Validate();
            }
            catch (JdException e)
            {
                return createErrorResponse<T>(e.ErrorCode, e.ErrorMsg);
            }

            // 添加协议级请求参数
            JdDictionary txtParams = new JdDictionary();
            string strParam = request.GetParamJson();
            txtParams.Add(APP_PARAM, strParam);
            txtParams.Add(METHOD, request.ApiName);
            //API版本号，兼容开普勒接口调用，JOS接口不区分版本
            txtParams.Add(VERSION, string.IsNullOrEmpty(request.ApiVersion)?"2.0":request.ApiVersion);
            txtParams.Add(APP_KEY, appKey);
            //txtParams.Add(FORMAT, format);
            //txtParams.Add(PARTNER_ID, "top-sdk-net-20111024");
            txtParams.Add(TIMESTAMP, timestamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + timestamp.ToString("zzzz").Replace(":", ""));
            txtParams.Add(ACCESSTOKEN, accessToken);

            // 添加签名参数
            txtParams.Add(SIGN, JdUtils.SignJdRequest(txtParams, appSecret));

            string serverUrl = this.serverUrl;
            if (this.isJava)
            {
                txtParams.Remove(APP_PARAM);
                serverUrl = serverUrl + "?" + WebUtils.BuildQuery(txtParams);
                txtParams = new JdDictionary();
                txtParams.Add(APP_PARAM, strParam);
            }

            // 是否需要上传文件
            string body;
            int nErr = 0;
        retry:
            Thread.Sleep(nErr * 500);
            T rsp;
            rsp = Activator.CreateInstance<T>();
            if (request is IJdUploadRequest<T>)
            {
                IJdUploadRequest<T> uRequest = (IJdUploadRequest<T>)request;
                IDictionary<string, FileItem> fileParams = JdUtils.CleanupDictionary(uRequest.GetFileParameters());
                body = webUtils.DoPost(serverUrl, txtParams, fileParams);
            }
            else
            {
                body = webUtils.DoPost(serverUrl, txtParams, Proxy);
            }

            // 解释响应结果
            rsp.Body = body;
            {
                if (FORMAT_JSON.Equals(format))
                {
                    IJdParser<T> tp = new JdJsonParser<T>();
                    rsp = tp.Parse(body);
                }
                rsp.Body = body;
                if ((rsp.ErrCode == "66") && nErr++ < 5)
                {
                    //Trace.WriteLine(body);
                    goto retry;
                }
            }

            // 追踪错误的请求
            if (!disableTrace)
            {
                rsp.ReqUrl = webUtils.BuildGetUrl(this.serverUrl, txtParams);
                if (rsp.IsError)
                {
                    topLogger.Warn(rsp.ReqUrl + "\r\n" + rsp.Body);
                }
            }

            return rsp;
        }

        private T createErrorResponse<T>(string errCode, string errMsg) where T : JdResponse
        {
            T rsp = Activator.CreateInstance<T>();
            rsp.ErrCode = errCode;
            rsp.ErrMsg = errMsg;

            if (FORMAT_XML.Equals(format))
            {
                XmlDocument root = new XmlDocument();
                XmlElement bodyE = root.CreateElement("error_response");
                XmlElement codeE = root.CreateElement("code");
                codeE.InnerText = errCode;
                bodyE.AppendChild(codeE);
                XmlElement msgE = root.CreateElement("msg");
                msgE.InnerText = errMsg;
                bodyE.AppendChild(msgE);
                root.AppendChild(bodyE);
                rsp.Body = root.OuterXml;
            }
            else
            {
                JObject errJson = new JObject();
                errJson["error_response"] = new JObject();
                errJson["error_response"]["code"] = errCode;
                errJson["error_response"]["zh_desc"] = errMsg;
                string body = errJson.ToString();
                rsp.Body = body;
            }

            return rsp;
        }
    }
}
