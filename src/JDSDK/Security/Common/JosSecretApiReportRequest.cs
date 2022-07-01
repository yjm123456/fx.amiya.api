using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.ACES.Utils;

namespace Jd.ACES.Common
{
    public class JosSecretApiReportRequest
    {
        public String serverUrl { get; set; }
        public long customerUserId { get; set; }
        public String businessId { get; set; }
        public String text { get; set; }
        public String attribute { get; set; }
        public String accessToken { get; set; }
        public String appKey { get; set; }
        public String appSecret { get; set; }

        public JosSecretApiReportRequest() {
        }

        public String getParameters()
        {
            Dictionary<string, string> businessParams = new Dictionary<string, string>();
            businessParams.Add("businessId", this.businessId);
            businessParams.Add("text", this.text);
            businessParams.Add("attribute", this.attribute);
            if (this.customerUserId > 0)
            {
                businessParams.Add("customer_user_id", Convert.ToString(this.customerUserId));
            }
            businessParams.Add("server_url", this.serverUrl);

            // 添加协议级请求参数
            Dictionary<string, string> sysParams = new Dictionary<string, string>();
            sysParams.Add(Constants.METHOD, Constants.SECRET_API_SERVER);
            sysParams.Add(Constants.VERSION, "2.0");
            sysParams.Add(Constants.APP_KEY, appKey);
            sysParams.Add(Constants.TIMESTAMP, DateTime.Now.ToString(Constants.DATE_TIME_FORMAT));
            if (this.accessToken != null)
            {
                sysParams.Add(Constants.ACCESS_TOKEN, this.accessToken);
            }
            sysParams.Add(Constants.PARAM_JSON, JsonConvert.SerializeObject(businessParams, Formatting.Indented));
            // 添加签名参数
            sysParams.Add(Constants.SIGN, WebUtils.SignJdRequest(sysParams, appSecret, true));
            return WebUtils.BuildQuery(sysParams);
        }
    }
}
