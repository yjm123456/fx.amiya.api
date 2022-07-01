
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


           var taobaoAppInfo = await dalOrderAppInfo.GetAll().SingleOrDefaultAsync(e=>e.AppType==(byte)AppType.Tmall);
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
                double expires_in= Convert.ToDouble(requestObject["expires_in"].ToString());
                appInfo.RefreshToken = token;
                appInfo.ExpireDate = date.AddSeconds(expires_in-400);
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
    }
}
