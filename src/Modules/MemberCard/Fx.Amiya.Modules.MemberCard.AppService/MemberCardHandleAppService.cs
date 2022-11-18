using Fx.Amiya.Core.Dto.MemberCard;
using Fx.Amiya.Core.Interfaces.MemberCard;
using Fx.Amiya.Modules.MemberCard.DbModels;
using Fx.Amiya.Modules.MemberCard.Domain.IRepository;
using Fx.Amiya.Modules.MemberCard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Fx.Amiya.Modules.MemberCard.AppService
{
    public class MemberCardHandleAppService : IMemberCard
    {
        private IFreeSql<MemberCardFlag> freeSql;
        private IMemberRankInfoRepository _memberRankInfoRepository;
        private IMemberCardHandleRepository _memberCardHoldRepository;

        public MemberCardHandleAppService(IFreeSql<MemberCardFlag> freeSql,
            IMemberRankInfoRepository memberRankInfoRepository,
            IMemberCardHandleRepository memberCardHoldRepository)
        {
            this.freeSql = freeSql;
            _memberRankInfoRepository = memberRankInfoRepository;
            _memberCardHoldRepository = memberCardHoldRepository;
        }
        public async Task CustomerApplyForMemberCardAsync(string customerId, string memberRankCode)
        {

            var memberRank = await _memberRankInfoRepository.GetMemberRankByRankCodeAsync(memberRankCode);

            var latestMemberCard = await freeSql.Select<MemberCardHandleDbModel>()
                .Where(e=>e.MemberRankId==memberRank.ID)
                .OrderByDescending(e => e.MemberCardNum).FirstAsync();

           
            var memberCard = memberRank.CreateMemberCardSendToCustomer(customerId, latestMemberCard?.MemberCardNum, "",null);
            await _memberCardHoldRepository.AddAsync(memberCard);
        }




        public async Task IssueMemberCardAsync(IssueMemberCardAddDto item)
        {
            var memberRank = await _memberRankInfoRepository.GetByIdAsync(item.MemberRankID);

            var latestMemberCard = await freeSql.Select<MemberCardHandleDbModel>()
                .Where(e => e.MemberRankId == memberRank.ID)
                .OrderByDescending(e => e.MemberCardNum).FirstAsync();

         
            var memberCard = memberRank.CreateMemberCardSendToCustomer(item.CustomerID, latestMemberCard?.MemberCardNum, item.MemberCardNum, item.HandleBy);

            var customerCemberCard= await freeSql.Select<MemberCardHandleDbModel>().Include(e => e.MemberRankInfo).Where(e => e.CustomerId == item.CustomerID).FirstAsync();
            if (customerCemberCard == null)
            {
                await _memberCardHoldRepository.AddAsync(memberCard);
            }
            else
            {
                if (customerCemberCard.MemberRankId == item.MemberRankID)
                    throw new Exception("该客户已有" + customerCemberCard.MemberRankInfo.Name + ",无需重复操作");
                await _memberCardHoldRepository.UpdateAsync(memberCard);
            }

        }



        public async Task<MemberCardHandleDto> GetMemberCardHandelByCustomerIdAsync(string customerId)
        {
            var memberCard = await freeSql.Select<MemberCardHandleDbModel>()
                .Include(e => e.MemberRankInfo)
                .Where(e => e.CustomerId == customerId && e.Valid == true).FirstAsync();
    
            if (memberCard == null)
                return null;

            MemberCardHandleDto memberCardHandle = new MemberCardHandleDto()
            {
                Date = memberCard.Date,
                CustomerId = memberCard.CustomerId,
                MemberCardNum = memberCard.MemberCardNum,
                MemberRankId = memberCard.MemberRankId,
                MemberRankName = memberCard.MemberRankInfo.Name,
                HandleBy = memberCard.HandleBy,
                Valid = memberCard.Valid,
                Description = memberCard.MemberRankInfo.Description,
                ImageUrl = memberCard.MemberRankInfo.ImageUrl,
                GenerateIntegrationPercent=memberCard.MemberRankInfo.GenerateIntegrationPercent,
                ReferralsIntegrationPercent=memberCard.MemberRankInfo.ReferralsIntegrationPercent

            };
            return memberCardHandle;
        }



        /// <summary>
        /// 根据客户编号数组获取会员卡列表
        /// </summary>
        /// <param name="customerIds"></param>
        /// <returns></returns>
       public async  Task<List<MemberCardHandleDto>> GetMemberCardHandelListByCustomerIdsAsync(List<string> customerIds)
        {

            var memberCardList = await freeSql.Select<MemberCardHandleDbModel>()
                .Include(e => e.MemberRankInfo)
                .Where(e => customerIds.Contains(e.CustomerId)&& e.Valid == true).ToListAsync();


            var memberCards = from d in memberCardList
                              select new MemberCardHandleDto
                              {
                                  Date = d.Date,
                                  CustomerId = d.CustomerId,
                                  MemberCardNum = d.MemberCardNum,
                                  MemberRankId = d.MemberRankId,
                                  MemberRankName = d.MemberRankInfo.Name,
                                  HandleBy = d.HandleBy,
                                  Valid = d.Valid,
                                  Description = d.MemberRankInfo.Description,
                                  ImageUrl = d.MemberRankInfo.ImageUrl,
                                  GenerateIntegrationPercent = d.MemberRankInfo.GenerateIntegrationPercent

                              };
           
            return memberCards.ToList();
        }


        /// <summary>
        /// 根据会员级别获取会员卡列表
        /// </summary>
        /// <param name="memberRankId"></param>
        /// <returns></returns>
        public async Task<List<MemberCardHandleDto>> GetMemberCardHandelListByMemberRankAsync(int? memberRankId)
        {

            var memberCardList = await freeSql.Select<MemberCardHandleDbModel>()
                .Include(e => e.MemberRankInfo)
                .Where(e => (memberRankId == null||e.MemberRankId== memberRankId) && e.Valid == true).ToListAsync();


            var memberCards = from d in memberCardList
                              select new MemberCardHandleDto
                              {
                                  Date = d.Date,
                                  CustomerId = d.CustomerId,
                                  MemberCardNum = d.MemberCardNum,
                                  MemberRankId = d.MemberRankId,
                                  MemberRankName = d.MemberRankInfo.Name,
                                  HandleBy = d.HandleBy,
                                  Valid = d.Valid,
                                  Description = d.MemberRankInfo.Description,
                                  ImageUrl = d.MemberRankInfo.ImageUrl,
                                  GenerateIntegrationPercent = d.MemberRankInfo.GenerateIntegrationPercent

                              };

            return memberCards.ToList();
        }
    }
}
