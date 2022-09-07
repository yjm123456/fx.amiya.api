using Fx.Amiya.Dto.MemberCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IMemberCardRankInfoService
    {
        /// <summary>
        /// 根据会员卡编码获取指定的会员卡信息
        /// </summary>
        /// <param name="rankCode"></param>
        /// <returns></returns>
        Task<MemberCardRankInfoDto> GetMemberRankInfoByRankCodeAsync(string rankCode);
        /// <summary>
        /// 获取会员卡信息列表
        /// </summary>
        /// <returns></returns>
        Task<List<MemberCardRankInfoDto>> GetMemberRankInfoListAsync();
    }
}
