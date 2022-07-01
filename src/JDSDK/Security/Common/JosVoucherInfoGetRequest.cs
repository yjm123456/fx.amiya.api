using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.ACES.Utils;

namespace Jd.ACES.Common
{
    public class JosVoucherInfoGetRequest
    {
        public string accessToken { get; set; }
        public string appKey { get; set; }
        public string appSecret { get; set; }
        public long customerUserId { get; set; }


        public JosVoucherInfoGetRequest()
        {

        }

        public string getParameters()
        {
            Dictionary<string, string> businessParams = new Dictionary<string, string>();
            if(this.customerUserId>0)
                businessParams.Add("customer_user_id", Convert.ToString(this.customerUserId));
            // 添加协议级请求参数
            Dictionary<string, string> sysParams = new Dictionary<string, string>();
            sysParams.Add(Constants.METHOD, Constants.TMS_API_SERVER);
            sysParams.Add(Constants.VERSION, "2.0");
            sysParams.Add(Constants.APP_KEY, appKey);
            sysParams.Add(Constants.TIMESTAMP, DateTime.Now.ToString(Constants.DATE_TIME_FORMAT));
            if (!String.IsNullOrEmpty(this.accessToken))
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
