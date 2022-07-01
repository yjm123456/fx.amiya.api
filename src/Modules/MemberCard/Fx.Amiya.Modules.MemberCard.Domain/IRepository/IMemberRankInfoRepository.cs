using Fx.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.Domain.IRepository
{
    public interface IMemberRankInfoRepository: IRepositoryBase<MemberRankInfo,int>
    {
        Task<MemberRankInfo> GetDefaultMemberRankAsync();
        Task<MemberRankInfo> GetMemberRankByRankCodeAsync(string memberRankCode);
    }
}
