using Fx.Amiya.Dto.MemberCard;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MemberCardRankInfoService : IMemberCardRankInfoService
    {
        private readonly IDalMemberCardRankInfo dalMemberCardRankInfo;

        public MemberCardRankInfoService(IDalMemberCardRankInfo dalMemberCardRankInfo)
        {
            this.dalMemberCardRankInfo = dalMemberCardRankInfo;
        }

        public async Task<MemberCardRankInfoDto> GetMemberRankInfoByRankCodeAsync(string rankCode)
        {
            return  dalMemberCardRankInfo.GetAll().Where(m => m.RankCode == rankCode).Select(m => new MemberCardRankInfoDto
            {
                ID = m.ID,
                MinAmount=m.MinAmount,
                MaxAmount=m.MaxAmount
            }).SingleOrDefault();
        }
        /// <summary>
        /// 获取会员卡信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<MemberCardRankInfoDto>> GetMemberRankInfoListAsync()
        {
            return dalMemberCardRankInfo.GetAll().Select(e => new MemberCardRankInfoDto {
                Name=e.Name,
                MinAmount=e.MinAmount,
                MaxAmount=e.MaxAmount,
                RankCode=e.RankCode
            }).ToList();
        }

    }
}
