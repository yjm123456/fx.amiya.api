using Fx.Amiya.DbModels.Model;
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
    
    public class MemberCardSendRecordService: IMemberCardSendRecordService
    {
        private readonly IDalMemberCardSendRecord dalMemberCardSendRecord;

        public MemberCardSendRecordService(IDalMemberCardSendRecord dalMemberCardSendRecord)
        {
            this.dalMemberCardSendRecord = dalMemberCardSendRecord;
        }

        public async Task AddAsync(MemberCardSendRecordDto dto)
        {
            MemberCardSendRecord sendRecord = new MemberCardSendRecord {
                CustomerId = dto.CustomerId,
                Date = DateTime.Now,
                MemberCardNum=dto.MemberCardNum,
                MemberRankId=dto.MemberRankId,
                HandleBy=null
            };
            await dalMemberCardSendRecord.AddAsync(sendRecord,true);
        }
    }
}
