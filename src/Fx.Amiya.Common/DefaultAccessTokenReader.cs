using Fx.Amiya.Dto.WxAppConfig;
using Fx.Weixin.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Common
{
    public class DefaultAccessTokenReader : IAccessTokenReader
    {
        private IAccessToken _accessTokenApi;
        private FxUniteWxAccessTokenConfigDto _uniteAccessTokenConfig;
        private FxAppGlobal _fxAppGlobal;

        public DefaultAccessTokenReader(IAccessToken accessTokenApi,
            FxAppGlobal fxAppGlobal)
        {
            _accessTokenApi = accessTokenApi;
            _fxAppGlobal = fxAppGlobal;
            _uniteAccessTokenConfig = fxAppGlobal.AppConfig.FxUniteWxAccessTokenConfig;
        }
        public async Task<string> GetAccessTokenAsync(string appId)
        {
            var wxAppInfo = _fxAppGlobal.WxAppInfoList.SingleOrDefault(t => t.WxAppId == appId);
            if (wxAppInfo == null)
                throw new Exception("无效的AppId");
            if (_uniteAccessTokenConfig.Enable)  //启用统一获取          
            {
                var baseUrl = _uniteAccessTokenConfig.RequestBaseUrl;
                var url = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";

                return await _accessTokenApi.GetAccessTokenByUniteAsync(wxAppInfo.WxAppId, url + "fxopen/accesstoken");
            }
            else
            {
                var accessTokenDto = await _accessTokenApi.GetAccessTokenAsync(wxAppInfo.WxAppId, wxAppInfo.WxAppSecret);
                return accessTokenDto?.Value;
            }
        }
    }
}
