using Fx.Amiya.Dto.WxAppConfig;
using Fx.Amiya.Dto.WxAppInfo;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Common
{
   public class FxAppGlobal
    {
        private IWxAppConfigService _service;
        private IWxAppInfoService _wxAppInfoService;
        public FxAppGlobal(IWxAppConfigService service, IWxAppInfoService wxAppInfoService)
        {
            _service = service;
            _wxAppInfoService = wxAppInfoService;
        }
        private static WxAppConfigDto appConfig;
        private static List<WxAppInfoDto> wxAppInfoList;


        /// <summary>
        /// 应用配置信息
        /// </summary>
        public WxAppConfigDto AppConfig
        {
            get
            {
                if (appConfig == null)
                {
                    appConfig = _service.GetWxAppConfigAsync().Result;

                }
                return appConfig;
            }
        }


        /// <summary>
        /// 微信 公众号或小程序的appid集合
        /// </summary>
        public List<WxAppInfoDto> WxAppInfoList
        {
            get
            {
                if (wxAppInfoList == null)
                {
                    wxAppInfoList = _wxAppInfoService.GetWxAppInfosAsync(true).Result;
                }
                return wxAppInfoList;
            }
        }

        private static readonly object lockObj = new object();

        public void Reload()
        {
            lock (lockObj)
            {
                appConfig = _service.GetWxAppConfigAsync().Result;
                wxAppInfoList = _wxAppInfoService.GetWxAppInfosAsync(true).Result;
            }
        }
    }
}
