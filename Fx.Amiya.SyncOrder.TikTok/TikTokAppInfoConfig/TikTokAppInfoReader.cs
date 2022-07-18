using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.TikTok.TikTokAppInfoConfig
{
    public class TikTokAppInfoReader: ITikTokAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;
        public TikTokAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }


        public async Task<TikTokAppInfo> GetTikTokAppInfo()
        {
            var tmallAppInfoDto = await orderAppInfoService.GetTikTokAppInfo();
            TikTokAppInfo tmallAppInfo = new TikTokAppInfo();
            tmallAppInfo.Id = tmallAppInfoDto.Id;
            tmallAppInfo.AppKey = tmallAppInfoDto.AppKey;
            tmallAppInfo.AppSecret = tmallAppInfoDto.AppSecret;
            tmallAppInfo.AccessToken = tmallAppInfoDto.AccessToken;
            tmallAppInfo.AuthorizeDate = tmallAppInfoDto.AuthorizeDate;
            tmallAppInfo.AppType = tmallAppInfoDto.AppType;
            tmallAppInfo.ExpireDate = tmallAppInfoDto.ExpireDate;
            tmallAppInfo.RefreshToken = tmallAppInfoDto.RefreshToken;
            return tmallAppInfo;
        }
    }
}
