using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Modules.MemberCard.DbModels;
using Fx.Amiya.Modules.MemberCard.Domain;
using Fx.Amiya.Modules.MemberCard.Domain.IRepository;
using Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.AppService
{
    public class MemberRankInfoAppService : IMemberRankInfo
    {
        private IMemberRankInfoRepository _memberRankInfoRepository;
        private IFreeSql<MemberCardFlag> freeSql;
        public MemberRankInfoAppService(IMemberRankInfoRepository memberRankInfoRepository,
            IFreeSql<MemberCardFlag> freeSql)
        {
            _memberRankInfoRepository = memberRankInfoRepository;
            this.freeSql = freeSql;
        }

        public async Task AddMemberRankInfoAsync(MemberRankInfoAddDto item)
        {
            MemberRankInfo memberRankInfo = new MemberRankInfo();
            memberRankInfo.Name = item.Name;
            memberRankInfo.MinAmount = item.MinAmount;
            memberRankInfo.MaxAmount = item.MaxAmount;
            memberRankInfo.Sconto = item.Sconto;
            memberRankInfo.GenerateIntegrationPercent = item.GenerateIntegrationPercent;
            memberRankInfo.ReferralsIntegrationPercent = item.ReferralsIntegrationPercent;
            memberRankInfo.Valid = true;
            memberRankInfo.Description = item.Description;
            memberRankInfo.Default = item.Default;
            memberRankInfo.ImageUrl = item.ImageUrl;
            memberRankInfo.RankCode = item.RankCode;

            await _memberRankInfoRepository.AddAsync(memberRankInfo);

        }

        public async Task<MemberRankInfoDto> GetMemberRankInfoByIDAsync(int id)
        {
            var memberRankInfo = await _memberRankInfoRepository.GetByIdAsync(id);

            return new MemberRankInfoDto()
            {
                ID = memberRankInfo.ID,
                Name = memberRankInfo.Name,
                MinAmount = memberRankInfo.MinAmount,
                MaxAmount = memberRankInfo.MaxAmount,
                Sconto = memberRankInfo.Sconto,
                GenerateIntegrationPercent = memberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent = memberRankInfo.ReferralsIntegrationPercent,
                Valid = memberRankInfo.Valid,
                Description = memberRankInfo.Description,
                Default = memberRankInfo.Default,
                ImageUrl = memberRankInfo.ImageUrl,
                RankCode = memberRankInfo.RankCode,
            };
        }

        public async Task<List<MemberRankInfoDto>> GetMemberRankInfosAsync()
        {
            var memberRankInfos = from d in await freeSql.Select<MemberRankInfoDbModel>().ToListAsync()
                                  select new MemberRankInfoDto
                                  { 
                                    ID=d.ID,
                                    Name=d.Name,
                                    MinAmount=d.MinAmount,
                                    MaxAmount=d.MaxAmount,
                                    Sconto=d.Sconto,
                                    GenerateIntegrationPercent=d.GenerateIntegrationPercent,
                                    ReferralsIntegrationPercent=d.ReferralsIntegrationPercent,
                                    Valid=d.Valid,
                                    Description=d.Description,
                                    Default=d.Default,
                                    ImageUrl= d.ImageUrl,
                                    RankCode= d.RankCode,
                                  };

            return memberRankInfos.ToList();
        }


        public async Task<List<MemberRankNameDto>> GetMemberRankNameListAsync()
        {
            var memberRankInfos = from d in await freeSql.Select<MemberRankInfoDbModel>().ToListAsync()
                                  select new MemberRankNameDto
                                  {
                                      Id = d.ID,
                                      Name = d.Name,
                                  };

            return memberRankInfos.ToList();
        }

        public async Task<List<MemberRankInfoDto>> GetValidMemberRankInfosAsync()
        {
            var memberRankInfos = from d in await freeSql.Select<MemberRankInfoDbModel>().Where(e=>e.Valid==true).ToListAsync()
                                  select new MemberRankInfoDto
                                  {
                                      ID = d.ID,
                                      Name = d.Name,
                                      MinAmount = d.MinAmount,
                                      MaxAmount = d.MaxAmount,
                                      Sconto = d.Sconto,
                                      GenerateIntegrationPercent = d.GenerateIntegrationPercent,
                                      ReferralsIntegrationPercent = d.ReferralsIntegrationPercent,
                                      Valid = d.Valid,
                                      Description = d.Description,
                                      Default = d.Default,
                                      ImageUrl = d.ImageUrl,
                                      RankCode = d.RankCode,
                                  };

            return memberRankInfos.ToList();
        }

        public async Task UpdateMemberRankInfoAsync(MemberRankInfoUpdateDto item)
        {
            var memberRankInfo = await _memberRankInfoRepository.GetByIdAsync(item.ID);

            memberRankInfo.ID = item.ID;
            memberRankInfo.Name = item.Name;
            memberRankInfo.MinAmount = item.MinAmount;
            memberRankInfo.MaxAmount = item.MaxAmount;
            memberRankInfo.Sconto = item.Sconto;
            memberRankInfo.GenerateIntegrationPercent = item.GenerateIntegrationPercent;
            memberRankInfo.ReferralsIntegrationPercent = item.ReferralsIntegrationPercent;
            memberRankInfo.Valid = item.Valid;
            memberRankInfo.Description = item.Description;
            memberRankInfo.Default = item.Default;
            memberRankInfo.ImageUrl = item.ImageUrl;
            memberRankInfo.RankCode = item.RankCode;

           
            await _memberRankInfoRepository.UpdateAsync(memberRankInfo);
        }


        public async Task<MemberRankInfoDto> GetMinGeneratePercentMemberRankInfoAsync()
        {
            var memberRankInfo = await freeSql.Select<MemberRankInfoDbModel>()
                .Where(e => e.Valid == true)
                .OrderBy(e => e.GenerateIntegrationPercent)
                .FirstAsync();

            MemberRankInfoDto memberRank = new MemberRankInfoDto()
            {
                ID = memberRankInfo.ID,
                Name = memberRankInfo.Name,
                MinAmount = memberRankInfo.MinAmount,
                MaxAmount = memberRankInfo.MaxAmount,
                Sconto = memberRankInfo.Sconto,
                GenerateIntegrationPercent = memberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent = memberRankInfo.ReferralsIntegrationPercent,
                Valid = memberRankInfo.Valid,
                Description = memberRankInfo.Description,
                Default = memberRankInfo.Default,
                ImageUrl = memberRankInfo.ImageUrl,
                RankCode = memberRankInfo.RankCode,
            };
            return memberRank;
        }
    }
}
