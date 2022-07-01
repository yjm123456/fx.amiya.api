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
    public class MemberCardHandleRepository : IMemberCardHandleRepository
    {
        private IFreeSql<MemberCardFlag> freeSql;
        public MemberCardHandleRepository(IFreeSql<MemberCardFlag> freeSql)
        {
            this.freeSql = freeSql;
        }
        public async Task<MemberCardHandle> AddAsync(MemberCardHandle entity)
        {
            MemberCardHandleDbModel memberCardInfo = new MemberCardHandleDbModel();
            memberCardInfo.MemberCardNum = entity.MemberCardNum;
            memberCardInfo.CustomerId = entity.CustomerId;
            memberCardInfo.Date = entity.Date;
            memberCardInfo.MemberRankId = entity.MemberRankId;
            memberCardInfo.Valid = entity.Valid;
            memberCardInfo.HandleBy = entity.HandleBy;

            MemberCardSendRecordDbModel memberCardSendRecord = new MemberCardSendRecordDbModel();
            memberCardSendRecord.CustomerId = entity.CustomerId;
            memberCardSendRecord.Date = entity.Date;
            memberCardSendRecord.MemberCardNum = entity.MemberCardNum;
            memberCardSendRecord.MemberRankId = entity.MemberRankId;
            memberCardSendRecord.HandleBy = entity.HandleBy;

            await freeSql.Insert<MemberCardHandleDbModel>().AppendData(memberCardInfo).ExecuteAffrowsAsync();
            await freeSql.Insert<MemberCardSendRecordDbModel>().AppendData(memberCardSendRecord).ExecuteAffrowsAsync();

            return entity;
        }

        public Task<MemberCardHandle> GetByIdAsync(string memberCardNum)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(MemberCardHandle entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(string memberCardNum)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(MemberCardHandle entity)
        {
            MemberCardSendRecordDbModel memberCardSendRecord = new MemberCardSendRecordDbModel();
            memberCardSendRecord.CustomerId = entity.CustomerId;
            memberCardSendRecord.Date = entity.Date;
            memberCardSendRecord.MemberCardNum = entity.MemberCardNum;
            memberCardSendRecord.MemberRankId = entity.MemberRankId;
            memberCardSendRecord.HandleBy = entity.HandleBy;
            await freeSql.Insert<MemberCardSendRecordDbModel>().AppendData(memberCardSendRecord).ExecuteAffrowsAsync();

            return await freeSql.Update<MemberCardHandleDbModel>()
                .Set(e => e.MemberCardNum, entity.MemberCardNum)
                .Set(e => e.Date, entity.Date)
                .Set(e => e.MemberRankId, entity.MemberRankId)
                .Set(e => e.Valid, entity.Valid)
                .Set(e => e.HandleBy, entity.HandleBy)
                .Where(e => e.CustomerId == entity.CustomerId)
                .ExecuteAffrowsAsync();
        }
    }
}
