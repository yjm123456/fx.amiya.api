using System;

namespace Jd.ACES.Common
{
    public class JosSystemParam
    {
        //网关请求url
        public string serverURL { get; set; }
        //网关appkey
        public string appKey { get; set; }
        //网关appsecret
        public string appSecret { get; set; }
        //网关accessToken
        public string accessToken { get; set; }
        public JosSystemParam() {
        }
    }
}
