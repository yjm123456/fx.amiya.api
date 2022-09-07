using Fx.Amiya.Dto.MemberCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMemberCardHandleService
    {
        /// <summary>
        /// 根据customerid获取会员卡信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<MemberCardHandleDto> GetMemberCardByCustomeridAsync(string customerId);
        /// <summary>
        /// 根据会员卡id获取该编码最新添加的会员卡卡号
        /// </summary>
        /// <returns></returns>
        Task<string> GetMemberCardHandleLastNumAsync(int cardid);
        /// <summary>
        /// 添加会员卡
        /// </summary>
        /// <param name="handleDto"></param>
        /// <returns></returns>
        Task AddAsync(MemberCardHandleDto handleDto);
        /// <summary>
        /// 更新会员卡信息
        /// </summary>
        /// <param name="handleDto"></param>
        /// <returns></returns>
        Task UpdateAsync(MemberCardHandleDto handleDto);
    }
}
