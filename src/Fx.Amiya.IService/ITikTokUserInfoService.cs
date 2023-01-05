using Fx.Amiya.Dto.TikTokUserInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface ITikTokUserInfoService
    {
        Task AddAsync(AddTikTokUserDto addTikTokUserDto);
        /// <summary>
        /// 根据加密信息获取用户信息
        /// </summary>
        /// <param name="cipherphone"></param>
        /// <returns></returns>
        TikTokUserDto getTikTokUserInfoByCipherPhone(string cipherphone);
        Task<TikTokUserDto> DecryptUserInfoAsync(string userinfoid, string userid, string belongLiveAnchorId);
        /// <summary>
        /// 根据订单id解密用户信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        Task<TikTokUserDto> DecryptUserInfoByOrderIdAsync(string orderid,string ciperName,string cipherPhone,string belongLiveAnchorId);
    }
}
