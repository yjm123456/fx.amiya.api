
using Fx.Amiya.Dto.OrderAppInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IOrderAppInfoService
    {
        /// <summary>
        /// 获取天猫订单应用信息
        /// </summary>
        /// <returns></returns>
        Task<OrderAppInfoDto> GetTmallAppInfo();


        /// <summary>
        /// 获取天猫AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<string> GetTmallAppAccessTokenAsync(string code);



        /// <summary>
        /// 获取京东订单应用信息
        /// </summary>
        /// <returns></returns>
        Task<OrderAppInfoDto> GetJdAppInfo();

        Task<OrderAppInfoDto> GetWeiFenXiaoAppInfo();

        /// <summary>
        /// 获取企业微信token
        /// </summary>
        /// <returns></returns>
        Task<OrderAppInfoDto> GetBusinessWeChatAppInfo();
        Task<OrderAppInfoDto> GetTikTokAppInfo(string belongLiveAnchor);

    }
}
