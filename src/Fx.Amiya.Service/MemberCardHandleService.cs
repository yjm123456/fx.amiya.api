using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.MemberCard;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MemberCardHandleService : IMemberCardHandleService
    {
        private IDalMemberCardHandle dalMemberCardHandle;

        public MemberCardHandleService(IDalMemberCardHandle dalMemberCardHandle)
        {
            this.dalMemberCardHandle = dalMemberCardHandle;
        }

        public async Task AddAsync(MemberCardHandleDto handleDto)
        {
            MemberCardHandle memberCardHandle = new MemberCardHandle { 
                MemberCardNum=handleDto.MemberCardNum,
                CustomerId=handleDto.CustomerId,
                Date=handleDto.Date,
                MemberRankId=handleDto.MemberRankId,
                Valid=handleDto.Valid,
                HandleBy=handleDto.HandleBy
            };
            await dalMemberCardHandle.AddAsync(memberCardHandle,true);
        }

        public async Task<MemberCardHandleDto> GetMemberCardByCustomeridAsync(string customerId)
        {
            return  dalMemberCardHandle.GetAll().Include(m=>m.MemberRankInfo).Where(m => m.CustomerId == customerId && m.Valid == true).Select(m=>new MemberCardHandleDto { 
                MemberRankId=m.MemberRankId,
                MemberCardNum=m.MemberCardNum,
                CustomerId=m.CustomerId,
                MemberRankName=m.MemberRankInfo.Name,
                MemberRankCode=m.MemberRankInfo.RankCode,
                ImageUrl = m.MemberRankInfo.ImageUrl,
                Date=m.Date,
                HandleBy=m.HandleBy,
                Valid=m.Valid

            }).OrderByDescending(m=>m.Date).FirstOrDefault();
        }

        public async Task<string> GetMemberCardHandleLastNumAsync(int cardid)
        {
            return dalMemberCardHandle.GetAll().Where(m => m.MemberRankId == cardid).OrderByDescending(m => Convert.ToInt32(m.MemberCardNum)).Select(m=>m.MemberCardNum).FirstOrDefault();
        }

        public async Task UpdateAsync(MemberCardHandleDto handleDto)
        {
            var card = dalMemberCardHandle.GetAll().Where(c => c.MemberCardNum == handleDto.MemberCardNum).FirstOrDefault();
            card.MemberRankId = handleDto.MemberRankId;
            card.Date = handleDto.Date;
            card.Valid = handleDto.Valid;
            await dalMemberCardHandle.UpdateAsync(card,true);
        }
    }
}
