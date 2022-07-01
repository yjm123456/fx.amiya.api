using Fx.Amiya.Core.Dto.MemberCard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Interfaces.MemberCard
{
    public interface IMemberCard
    {
        /// <summary>
        /// 用户申请会员卡（
        /// </summary>
        /// <returns></returns>
        Task CustomerApplyForMemberCardAsync(string customerId,string memberRankCode);
        /// <summary>
        /// 手动发放会员卡（发放卡记录要保存，但是一个客户的卡账户只能存一个）卡账户，和办卡记录要分开
        /// </summary>
        /// <returns></returns>
        Task IssueMemberCardAsync(IssueMemberCardAddDto item );


 

        /// <summary>
        /// 根据客户编号获取会员卡信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>没有会员卡信息返回null</returns>
        Task<MemberCardHandleDto> GetMemberCardHandelByCustomerIdAsync(string customerId);



        /// <summary>
        /// 根据客户编号数组获取会员卡列表
        /// </summary>
        /// <param name="customerIds"></param>
        /// <returns></returns>
        Task<List<MemberCardHandleDto>> GetMemberCardHandelListByCustomerIdsAsync(List<string> customerIds);

        /// <summary>
        /// 根据会员级别获取会员卡列表
        /// </summary>
        /// <param name="memberRankId"></param>
        /// <returns></returns>
         Task<List<MemberCardHandleDto>> GetMemberCardHandelListByMemberRankAsync(int? memberRankId);


    }
}
