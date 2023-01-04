using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Amiya.Core.Dto.MemberCard;
namespace Fx.Amiya.Core.Interfaces.MemberCard
{
    /// <summary>
    /// 会员卡等级信息管理
    /// </summary>
    public interface IMemberRankInfo
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task AddMemberRankInfoAsync(MemberRankInfoAddDto item);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task UpdateMemberRankInfoAsync(MemberRankInfoUpdateDto item);
        /// <summary>
        /// 获取会员等级设置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MemberRankInfoDto> GetMemberRankInfoByIDAsync(int id);
        /// <summary>
        /// 获取所有会员等级
        /// </summary>
        /// <returns></returns>
        Task<List<MemberRankInfoDto>> GetMemberRankInfosAsync();

        /// <summary>
        /// 获取会员等级名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<MemberRankNameDto>> GetMemberRankNameListAsync();

        /// <summary>
        /// 获取会员等级名称列表
        /// </summary>
        /// <returns></returns>
        Task<List<MemberRankCodeDto>> GetMemberRankCodeListAsync();

        /// <summary>
        /// 获取有效的会员等级列表
        /// </summary>
        /// <returns></returns>
        Task<List<MemberRankInfoDto>> GetValidMemberRankInfosAsync();


        /// <summary>
        /// 获取最小产生积分比例的会员级别
        /// </summary>
        /// <returns></returns>
        Task<MemberRankInfoDto> GetMinGeneratePercentMemberRankInfoAsync();
        /// <summary>
        /// 获取最小介绍人产生积分比例的会员级别
        /// </summary>
        /// <returns></returns>
        Task<MemberRankInfoDto> GetMinReferralsGeneratePercentMemberRankInfoAsync();


    }
}
