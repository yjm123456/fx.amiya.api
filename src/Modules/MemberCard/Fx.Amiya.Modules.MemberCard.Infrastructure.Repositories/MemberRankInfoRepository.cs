using Fx.Amiya.Modules.MemberCard.DbModels;
using Fx.Amiya.Modules.MemberCard.Domain;
using Fx.Amiya.Modules.MemberCard.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories
{
    public class MemberRankInfoRepository : IMemberRankInfoRepository
    {
        private IFreeSql<MemberCardFlag> freeSql;
        public MemberRankInfoRepository(IFreeSql<MemberCardFlag> freeSql)
        {
            this.freeSql = freeSql;
        }

        public async Task<MemberRankInfo> AddAsync(MemberRankInfo entity)
        {
            MemberRankInfoDbModel memberRankInfo = new MemberRankInfoDbModel();
            memberRankInfo.Name = entity.Name;
            memberRankInfo.MinAmount = entity.MinAmount;
            memberRankInfo.MaxAmount = entity.MaxAmount;
            memberRankInfo.Sconto = entity.Sconto;
            memberRankInfo.GenerateIntegrationPercent = entity.GenerateIntegrationPercent;
            memberRankInfo.ReferralsIntegrationPercent = entity.ReferralsIntegrationPercent;
            memberRankInfo.Valid = entity.Valid;
            memberRankInfo.Description = entity.Description;
            memberRankInfo.Default = entity.Default;
            memberRankInfo.ImageUrl = entity.ImageUrl;
            memberRankInfo.RankCode = entity.RankCode;

            if (entity.Default == true)
            {
                await freeSql.Update<MemberRankInfoDbModel>()
                    .Set(e => e.Default, false)
                    .Where(e => e.Default == true).ExecuteAffrowsAsync();
            }
            entity.ID = (byte)await freeSql.Insert<MemberRankInfoDbModel>().AppendData(memberRankInfo).ExecuteIdentityAsync();
            return entity;
        }

        public async Task<MemberRankInfo> GetByIdAsync(int id)
        {
            var memberRankInfo = await freeSql.Select<MemberRankInfoDbModel>().Where(e => e.ID == id).FirstAsync();
            if (memberRankInfo == null)
                throw new Exception("会员级别编号错误");

            MemberRankInfo memberRank = new MemberRankInfo()
            { 
                ID= memberRankInfo.ID,
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

        public async Task<MemberRankInfo> GetDefaultMemberRankAsync()
        {
            var memberRankInfo = await freeSql.Select<MemberRankInfoDbModel>().Where(e => e.Default == true).FirstAsync();
            MemberRankInfo memberRank = new MemberRankInfo()
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

        public async Task<MemberRankInfo> GetMemberRankByRankCodeAsync(string memberRankCode)
        {
            var memberRankInfo = await freeSql.Select<MemberRankInfoDbModel>().Where(e => e.RankCode == memberRankCode).FirstAsync();
            if (memberRankInfo == null)
                throw new Exception("会员级别代码错误");
            MemberRankInfo memberRank = new MemberRankInfo()
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

        public async Task<int> RemoveAsync(MemberRankInfo entity)
        {
            return await RemoveAsync(entity.ID);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await freeSql.Delete<MemberRankInfoDbModel>().Where(e=>e.ID==id).ExecuteAffrowsAsync();
        }

        public async Task<int> UpdateAsync(MemberRankInfo entity)
        {
            if (entity.Default == true)
            {
                await freeSql.Update<MemberRankInfoDbModel>()
                    .Set(e => e.Default, false)
                    .Where(e => e.Default == true&&e.ID!=entity.ID)
                    .ExecuteAffrowsAsync();
            }

            return await freeSql.Update<MemberRankInfoDbModel>()
                .Set(e => e.Name, entity.Name)
                .Set(e=>e.MinAmount,entity.MinAmount)
                .Set(e=>e.MaxAmount,entity.MaxAmount)
                .Set(e=>e.Sconto,entity.Sconto)
                .Set(e=>e.GenerateIntegrationPercent,entity.GenerateIntegrationPercent)
                .Set(e=>e.ReferralsIntegrationPercent,entity.ReferralsIntegrationPercent)
                .Set(e=>e.Valid,entity.Valid)
                .Set(e=>e.Description,entity.Description)
                .Set(e=>e.Default,entity.Default)
                .Set(e=>e.ImageUrl,entity.ImageUrl)
                .Set(e=>e.RankCode,entity.RankCode)
                .Where(e => e.ID == entity.ID)
                .ExecuteAffrowsAsync();
        }
    }
}
