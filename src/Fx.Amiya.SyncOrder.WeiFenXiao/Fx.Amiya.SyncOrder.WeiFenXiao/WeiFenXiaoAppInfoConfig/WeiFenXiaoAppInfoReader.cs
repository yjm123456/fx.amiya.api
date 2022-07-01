using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.WeiFenXiao.WeiFenXiaoAppInfoConfig
{
    public class WeiFenXiaoAppInfoReader: IWeiFenXiaoAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;
        public WeiFenXiaoAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }


        public async Task<WeiFenXiaoAppInfo> GetWeiFenXiaoAppInfo()
        {
            var tmallAppInfoDto = await orderAppInfoService.GetWeiFenXiaoAppInfo();
            WeiFenXiaoAppInfo tmallAppInfo = new WeiFenXiaoAppInfo();
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
