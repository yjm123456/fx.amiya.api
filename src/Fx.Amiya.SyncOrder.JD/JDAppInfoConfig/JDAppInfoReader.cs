using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.SyncOrder.JD.JDAppInfoConfig
{
    public class JDAppInfoReader : IJDAppInfoReader
    {
        private IOrderAppInfoService orderAppInfoService;
        public JDAppInfoReader(IOrderAppInfoService orderAppInfoService)
        {
            this.orderAppInfoService = orderAppInfoService;
        }


        public async Task<JDAppInfo> GetJdAppInfo()
        {
            var jdAppInfoDto = await orderAppInfoService.GetJdAppInfo();
            JDAppInfo jdAppInfo = new JDAppInfo();
            jdAppInfo.Id = jdAppInfoDto.Id;
            jdAppInfo.AppKey = jdAppInfoDto.AppKey;
            jdAppInfo.AppSecret = jdAppInfoDto.AppSecret;
            jdAppInfo.AccessToken = jdAppInfoDto.AccessToken;
            jdAppInfo.AuthorizeDate = jdAppInfoDto.AuthorizeDate;
            jdAppInfo.AppType = jdAppInfoDto.AppType;
            jdAppInfo.ExpireDate = jdAppInfoDto.ExpireDate;
            jdAppInfo.RefreshToken = jdAppInfoDto.RefreshToken;
            return jdAppInfo;
        }
    }
}
