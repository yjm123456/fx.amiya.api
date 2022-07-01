using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.Tmall.TmallAppInfoConfig
{
   public class TmallAppInfoReader: ITmallAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;
        public TmallAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }


        public async Task<TmallAppInfo> GetTmallAppInfo()
        {
            var tmallAppInfoDto = await orderAppInfoService.GetTmallAppInfo();
            TmallAppInfo tmallAppInfo = new TmallAppInfo();
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
