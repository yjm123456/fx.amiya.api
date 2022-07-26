using Fx.Amiya.DbModels.Model;
using Fx.Amiya.IService;
using Fx.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig
{
    public class TikTokAppInfoReader : ITikTokAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;
        public TikTokAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }


        public async Task<TikTokAppInfo> GetTikTokAppInfo()
        {
            var tikTokAppInfoDto = await orderAppInfoService.GetTikTokAppInfo();
            TikTokAppInfo tikTokAppInfo = new TikTokAppInfo();
            tikTokAppInfo.Id = tikTokAppInfoDto.Id;
            tikTokAppInfo.AppKey = tikTokAppInfoDto.AppKey;
            tikTokAppInfo.AppSecret = tikTokAppInfoDto.AppSecret;
            tikTokAppInfo.AccessToken = tikTokAppInfoDto.AccessToken;
            tikTokAppInfo.AuthorizeDate = tikTokAppInfoDto.AuthorizeDate;
            tikTokAppInfo.AppType = tikTokAppInfoDto.AppType;
            tikTokAppInfo.ExpireDate = tikTokAppInfoDto.ExpireDate;
            tikTokAppInfo.RefreshToken = tikTokAppInfoDto.RefreshToken;
            return tikTokAppInfo;
        }
    }
}
