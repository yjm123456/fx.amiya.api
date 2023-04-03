using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeChatVideo.WeChatVideoAppInfoConfig
{
    public class WechatVideoAppInfoReader : IWechatVideoAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;

        public WechatVideoAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }

        public async Task<WechatVideoAppInfo> GetWeChatVideoAppInfo(int belongLiveAnchor)
        {
            var tikTokAppInfoDto = await orderAppInfoService.GetWeChatVideoAppInfo(belongLiveAnchor);
            WechatVideoAppInfo tikTokAppInfo = new WechatVideoAppInfo();
            tikTokAppInfo.Id = tikTokAppInfoDto.Id;
            tikTokAppInfo.ShopId = tikTokAppInfo.ShopId;
            tikTokAppInfo.AppKey = tikTokAppInfoDto.AppKey;
            tikTokAppInfo.AppSecret = tikTokAppInfoDto.AppSecret;
            tikTokAppInfo.AccessToken = tikTokAppInfoDto.AccessToken;
            tikTokAppInfo.AuthorizeDate = tikTokAppInfoDto.AuthorizeDate;
            tikTokAppInfo.AppType = tikTokAppInfoDto.AppType;
            tikTokAppInfo.ExpireDate = tikTokAppInfoDto.ExpireDate;
            tikTokAppInfo.RefreshToken = tikTokAppInfoDto.RefreshToken;
            tikTokAppInfo.BelongLiveAnchorId = tikTokAppInfoDto.BelongLiveAnchorId;
            return tikTokAppInfo;
        }
    }

}
