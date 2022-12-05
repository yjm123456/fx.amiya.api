using Fx.Amiya.Dto.MemberCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMemberCardService
    {
        /// <summary>
        /// 给指定用户发送会员卡
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task SendMemberCardAsync(string customerid);
        /// <summary>
        /// 给用户发送指定类型的会员卡
        /// </summary>
        /// <param name="memberrankcode"></param>
        /// <returns></returns>
        Task SendCardAsync(string memberrankcode,string customerId);
        /// <summary>
        /// 计算升级下一等级所需的成长值
        /// </summary>
        /// <param name="growthPoints"></param>
        /// <returns></returns>
        Task<MemberCardUpgradeDto> GetUpgradeInfoAsync(decimal growthPoints,string customerId);
    }
}
