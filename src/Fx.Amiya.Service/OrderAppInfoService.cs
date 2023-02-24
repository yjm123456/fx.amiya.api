
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Newtonsoft.Json;
using Fx.Amiya.Dto.OrderAppInfo;
using Fx.Infrastructure.Utils;
using Fx.Common.Utils;
using Newtonsoft.Json.Linq;
using System.Web;
using Jd.Api.Util;

namespace Fx.Amiya.Service
{
    public class OrderAppInfoService : IOrderAppInfoService
    {
        private IDalOrderAppInfo dalOrderAppInfo;
        public OrderAppInfoService(IDalOrderAppInfo dalOrderAppInfo)
        {
            this.dalOrderAppInfo = dalOrderAppInfo;
        }

        public async Task<OrderAppInfoDto> GetTmallAppInfo()
        {
            var taobaoAppInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.Tmall);
            if (taobaoAppInfo == null)
                throw new Exception("天猫订单同步应用证书信息为空");

            OrderAppInfoDto tmallAppInfoDto = new OrderAppInfoDto();
            tmallAppInfoDto.Id = taobaoAppInfo.Id;
            tmallAppInfoDto.AppKey = taobaoAppInfo.AppKey;
            tmallAppInfoDto.AppSecret = taobaoAppInfo.AppSecret;
            tmallAppInfoDto.AccessToken = taobaoAppInfo.AccessToken;
            tmallAppInfoDto.AuthorizeDate = taobaoAppInfo.AuthorizeDate;
            tmallAppInfoDto.AppType = taobaoAppInfo.AppType;
            tmallAppInfoDto.ExpireDate = taobaoAppInfo.ExpireDate;
            tmallAppInfoDto.RefreshToken = taobaoAppInfo.RefreshToken;
            return tmallAppInfoDto;
        }

        public async Task<OrderAppInfoDto> GetJdAppInfo()
        {
            var jdAppInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.JD);
            if (jdAppInfo == null)
                throw new Exception("京东订单同步应用证书信息为空");
            DateTime date = DateTime.Now;
            if (jdAppInfo.ExpireDate <= date)
            {
                string url = $"https://open-oauth.jd.com/oauth2/refresh_token?app_key={jdAppInfo.AppKey}&app_secret={jdAppInfo.AppSecret}&grant_type=refresh_token&refresh_token={jdAppInfo.RefreshToken}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                var resJson = JsonConvert.DeserializeObject<dynamic>(res);
                jdAppInfo.AccessToken = resJson.access_token;
                jdAppInfo.RefreshToken = resJson.refresh_token;
                jdAppInfo.ExpireDate = date.AddHours(-2).AddSeconds(resJson.expires_in.ToObject<double>());
                jdAppInfo.AuthorizeDate = date;
                await dalOrderAppInfo.UpdateAsync(jdAppInfo, true);
            }

            OrderAppInfoDto jdAppInfoDto = new OrderAppInfoDto();
            jdAppInfoDto.Id = jdAppInfo.Id;
            jdAppInfoDto.AppKey = jdAppInfo.AppKey;
            jdAppInfoDto.AppSecret = jdAppInfo.AppSecret;
            jdAppInfoDto.AccessToken = jdAppInfo.AccessToken;
            jdAppInfoDto.AuthorizeDate = jdAppInfo.AuthorizeDate;
            jdAppInfoDto.AppType = jdAppInfo.AppType;
            jdAppInfoDto.ExpireDate = jdAppInfo.ExpireDate;
            jdAppInfoDto.RefreshToken = jdAppInfo.RefreshToken;
            return jdAppInfoDto;
        }



        public async Task<string> GetTmallAppAccessTokenAsync(string code)
        {
            string url = "http://gw.api.taobao.com/router/rest";


            var taobaoAppInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.Tmall);
            if (taobaoAppInfo == null)
                throw new Exception("淘宝订单同步应用证书信息为空");

            ITopClient client = new DefaultTopClient(url, taobaoAppInfo.AppKey, taobaoAppInfo.AppSecret);
            TopAuthTokenCreateRequest req = new TopAuthTokenCreateRequest();
            req.Code = code;
            TopAuthTokenCreateResponse rsp = client.Execute(req);

            var resJson = JsonConvert.DeserializeObject<dynamic>(rsp.Body);
            string accessToken = resJson.top_auth_token_create_response.token_result.access_token;
            taobaoAppInfo.AccessToken = accessToken;
            await dalOrderAppInfo.UpdateAsync(taobaoAppInfo, true);
            return accessToken;
        }

        public async Task<OrderAppInfoDto> GetWeiFenXiaoAppInfo()
        {
            var appInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.WeChatOfficialAccount);
            if (appInfo == null)
                throw new Exception("微分销公众号订单同步应用证书信息为空");
            DateTime date = DateTime.Now;
            if (appInfo.ExpireDate <= date)
            {
                string url = $"http://api.wifenxiao.com/token?shop_id={appInfo.AccessToken}&app_key={appInfo.AppKey}&secret={appInfo.AppSecret}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                if (res.Contains("errorcode"))
                    throw new Exception(res);
                JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
                string token = requestObject["access_token"].ToString();
                double expires_in = Convert.ToDouble(requestObject["expires_in"].ToString());
                appInfo.RefreshToken = token;
                appInfo.ExpireDate = date.AddSeconds(expires_in - 400);
                appInfo.AuthorizeDate = date;
                await dalOrderAppInfo.UpdateAsync(appInfo, true);
            }

            OrderAppInfoDto tmallAppInfoDto = new OrderAppInfoDto();
            tmallAppInfoDto.Id = appInfo.Id;
            tmallAppInfoDto.AppKey = appInfo.AppKey;
            tmallAppInfoDto.AppSecret = appInfo.AppSecret;
            tmallAppInfoDto.AccessToken = appInfo.AccessToken;
            tmallAppInfoDto.AuthorizeDate = appInfo.AuthorizeDate;
            tmallAppInfoDto.AppType = appInfo.AppType;
            tmallAppInfoDto.ExpireDate = appInfo.ExpireDate;
            tmallAppInfoDto.RefreshToken = appInfo.RefreshToken;
            return tmallAppInfoDto;
        }


        public async Task<OrderAppInfoDto> GetTikTokAppInfo(int belongLiveAnchor)
        {
            var appInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.Douyin && e.BelongLiveAnchor == belongLiveAnchor);
            if (appInfo == null)
                throw new Exception("抖音订单同步应用证书信息为空");

            if (string.IsNullOrEmpty(appInfo.AccessToken))
            {
                var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                var host = "https://openapi-fxg.jinritemai.com";
                //请求参数
                var param = new Dictionary<string, object> {
                    //{"shop_id","40391623" },
                    {"shop_id",appInfo.ShopId },
                    {"grant_type","authorization_self" }
                };
                var paramJson = Marshal(param);
                //计算签名
                var signVal = Sign(appInfo.AppKey, appInfo.AppSecret, "token.create", timestamp, paramJson);
                //发起请求
                var res = Fetch(appInfo.AppKey, host, "token.create", timestamp, paramJson, appInfo.AccessToken, signVal);
                var tokenResult = JsonConvert.DeserializeObject<dynamic>(res);
                appInfo.ExpireDate = DateTime.Now.AddSeconds(Convert.ToDouble(tokenResult.data.expires_in) - 3000);
                appInfo.AccessToken = tokenResult.data.access_token;
                appInfo.AuthorizeDate = DateTime.Now;
                appInfo.RefreshToken = tokenResult.data.refresh_token;
                await dalOrderAppInfo.UpdateAsync(appInfo, true);
            }
            else
            {
                var now = DateTime.Now;
                if (now > appInfo.ExpireDate)
                {
                    var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                    var host = "https://openapi-fxg.jinritemai.com";
                    //请求参数
                    var param = new Dictionary<string, object> {
                        {"refresh_token",appInfo.RefreshToken },
                        { "grant_type","refresh_token"},
                    };
                    var paramJson = Marshal(param);
                    //计算签名
                    var signVal = Sign(appInfo.AppKey, appInfo.AppSecret, "token.refresh", timestamp, paramJson);
                    //发起请求
                    var res = Fetch(appInfo.AppKey, host, "token.refresh", timestamp, paramJson, appInfo.AccessToken, signVal);
                    var refreshTokenResult = JsonConvert.DeserializeObject<dynamic>(res);
                    appInfo.AccessToken = refreshTokenResult.access_token;
                    appInfo.AuthorizeDate = DateTime.Now;
                    appInfo.RefreshToken = refreshTokenResult.refresh_token;
                    appInfo.ExpireDate = DateTime.Now.AddSeconds(refreshTokenResult.data.expires_in);
                    await dalOrderAppInfo.UpdateAsync(appInfo, true);
                }
            }
            OrderAppInfoDto tiktokAppInfoDto = new OrderAppInfoDto();
            tiktokAppInfoDto.Id = appInfo.Id;
            tiktokAppInfoDto.ShopId = appInfo.ShopId;
            tiktokAppInfoDto.AppKey = appInfo.AppKey;
            tiktokAppInfoDto.AppSecret = appInfo.AppSecret;
            tiktokAppInfoDto.AccessToken = appInfo.AccessToken;
            tiktokAppInfoDto.AuthorizeDate = appInfo.AuthorizeDate;
            tiktokAppInfoDto.AppType = appInfo.AppType;
            tiktokAppInfoDto.ExpireDate = appInfo.ExpireDate;
            tiktokAppInfoDto.RefreshToken = appInfo.RefreshToken;
            tiktokAppInfoDto.BelongLiveAnchorId = appInfo.BelongLiveAnchor;
            return tiktokAppInfoDto;
        }


        public async Task<OrderAppInfoDto> GetBusinessWeChatAppInfo()
        {
            var appInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e => e.AppType == (byte)AppType.Other);
            if (appInfo == null)
                throw new Exception("企业微信同步应用证书信息为空");
            DateTime date = DateTime.Now;
            if (appInfo.ExpireDate <= date)
            {
                string url = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={appInfo.ShopId}&corpsecret={appInfo.AppSecret}";
                var res = await HttpUtil.HTTPJsonGetAsync(url);
                JObject requestObject = JsonConvert.DeserializeObject(res) as JObject;
                var errCode = requestObject["errcode"].ToString();
                if (errCode != "0")
                {
                    throw new Exception(requestObject["errmsg"].ToString());
                }
                string token = requestObject["access_token"].ToString();
                double expires_in = Convert.ToDouble(requestObject["expires_in"].ToString());
                appInfo.RefreshToken = token;
                appInfo.AccessToken = token;
                appInfo.ExpireDate = date.AddSeconds(expires_in - 400);//1.8小时过期
                appInfo.AuthorizeDate = date;
                await dalOrderAppInfo.UpdateAsync(appInfo, true);
            }

            OrderAppInfoDto appInfoDto = new OrderAppInfoDto();
            appInfoDto.Id = appInfo.Id;
            appInfoDto.ShopId = appInfo.ShopId;
            appInfoDto.AppKey = appInfo.AppKey;
            appInfoDto.AppSecret = appInfo.AppSecret;
            appInfoDto.AccessToken = appInfo.AccessToken;
            appInfoDto.AuthorizeDate = appInfo.AuthorizeDate;
            appInfoDto.AppType = appInfo.AppType;
            appInfoDto.ExpireDate = appInfo.ExpireDate;
            appInfoDto.RefreshToken = appInfo.RefreshToken;
            return appInfoDto;
        }

        private static DateTime UnixTimestampToDateTime(DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }
        private string Fetch(string appKey, string host, string method, long timestamp, string paramJson,
    string accessToken, string sign)
        {
            var methodPath = method.Replace('.', '/');
            var u = host + "/" + methodPath +
                    "?method=" + HttpUtility.UrlEncode(method, Encoding.UTF8) +
                    "&app_key=" + HttpUtility.UrlEncode(appKey, Encoding.UTF8) +
                    "&access_token=" + HttpUtility.UrlEncode(accessToken, Encoding.UTF8) +
                    "&timestamp=" + HttpUtility.UrlEncode(timestamp.ToString(), Encoding.UTF8) +
                    "&v=" + HttpUtility.UrlEncode("2", Encoding.UTF8) +
                    "&sign=" + HttpUtility.UrlEncode(sign, Encoding.UTF8) +
                    "&sign_method=" + HttpUtility.UrlEncode("hmac-sha256", Encoding.UTF8);
            var header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json;charset=UTF-8");
            header.Add("Accept", "*/*");
            var res = HttpUtil.CommonHttpRequest(paramJson, u, "POST", header);
            return res;
        }
        // 序列化参数
        private string Marshal(object o)
        {
            var raw = JsonConvert.SerializeObject(o);
            // 反序列化为JObject
            var dict = JsonConvert.DeserializeObject(raw);

            // 重新序列化
            var settings = new JsonSerializerSettings();
            settings.Converters = new List<JsonConverter> { new JObjectConverter(), new JValueConverter() };
            return JsonConvert.SerializeObject(dict, Formatting.None, settings);
        }

        /// <summary>
        /// 获取请求url
        /// </summary>
        /// <param name="path">拼接请求地址</param>
        /// <returns></returns>
        private string GetRequestUrl(string path)
        {
            string url = "https://openapi-fxg.jinritemai.com";
            if (!string.IsNullOrEmpty(path))
            {
                url += path;
            }
            return url;
        }
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="method">方法描述</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="paramJson">请求参数</param>
        /// <returns></returns>
        private string Sign(string appKey, string appSecret, string method, long timestamp, string paramJson)
        {
            // 按给定规则拼接参数
            var paramPattern = "app_key" + appKey + "method" + method + "param_json" + paramJson + "timestamp" +
                               timestamp + "v2";
            var signPattern = appSecret + paramPattern + appSecret;
            Console.WriteLine("sign_pattern:" + signPattern);

            return HmacHelper.Hmac(signPattern, appSecret);
        }
    }
}
