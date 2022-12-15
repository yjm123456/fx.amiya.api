using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.Dto.MemberCard;
using Fx.Amiya.IService;
using jos_sdk_net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class MemberCardService : IMemberCardService
    {
        private readonly IMemberCardRankInfoService memberCardRankInfoService;
        private readonly IMemberCardHandleService memberCardHandleService;
        private readonly IGrowthPointsAccountService growthPointsAccountService;
        private readonly IMemberCardSendRecordService memberCardSendRecordService;
        private readonly ICustomerConsumptionVoucherService customerConsumptionVoucherService;
        public MemberCardService(IMemberCardRankInfoService memberCardRankInfoService, IMemberCardHandleService memberCardHandleService, IGrowthPointsAccountService growthPointsAccountService, IMemberCardSendRecordService memberCardSendRecordService, ICustomerConsumptionVoucherService customerConsumptionVoucherService)
        {
            this.memberCardRankInfoService = memberCardRankInfoService;
            this.memberCardHandleService = memberCardHandleService;
            this.growthPointsAccountService = growthPointsAccountService;
            this.memberCardSendRecordService = memberCardSendRecordService;
            this.customerConsumptionVoucherService = customerConsumptionVoucherService;
        }

        public async Task SendMemberCardAsync(string customerid)
        {
            var account =await growthPointsAccountService.GetGrowthPointAccountByCustomerId(customerid);
            if (account == null) {
                CreateGrowthPointsAccountDto createGrowthPointsAccountDto = new CreateGrowthPointsAccountDto {
                    CustomerId=customerid,
                    Balance=0
                };
                account= await growthPointsAccountService.AddAsync(createGrowthPointsAccountDto);               
            }
            
            var card = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerid);           
            if (card == null)
            {
                var memberCardList = await memberCardRankInfoService.GetMemberRankInfoListAsync();
                memberCardList = memberCardList.OrderBy(m=>Convert.ToInt32(m.RankCode)).ToList();
                foreach (var memberCard in memberCardList)
                {
                    if (account.Balance>=memberCard.MinAmount) {
                        await SendCardAsync(memberCard.RankCode, customerid);
                    }
                }
            }
            else {
                var currentMemberRankCode = Convert.ToInt32(card.MemberRankCode);
                var memberCardList = await memberCardRankInfoService.GetMemberRankInfoListAsync();
                memberCardList = memberCardList.OrderBy(m => Convert.ToInt32(m.RankCode)).ToList();
                //添加用户当前的会员等级
                List<int> rnakList = new List<int>();
                foreach (var memberCard in memberCardList)
                {
                    if (account.Balance >= memberCard.MinAmount)
                    {
                        rnakList.Add(Convert.ToInt32(memberCard.RankCode));
                        //await SendCardAsync(memberCard.RankCode, customerid);
                    }
                }
                var maxLevel = rnakList.Max();
                //如果用户当前等级适配等级相同直接返回
                if (maxLevel== currentMemberRankCode) {
                    return;
                }
                
                if (maxLevel > currentMemberRankCode)
                {
                    //如果当前等级小于适配的最大等级用户升级
                    var addMemberList = rnakList.Where(e => e > currentMemberRankCode).ToList();
                    foreach (var item in addMemberList)
                    {
                        await SendCardAsync(item.ToString(), customerid);
                    }
                }
                else {
                    //如果用户当前等级大于适配的最大等级用户降级
                    await SendCardAsync(maxLevel.ToString(), customerid);
                }
            }          
        }

        public async Task SendCardAsync(string memberRankCode,string customerId)
        {
            var card = await memberCardRankInfoService.GetMemberRankInfoByRankCodeAsync(memberRankCode);
            if (card == null) {
                throw new Exception("没有对应的会员卡信息");
            }
            var membercard = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            if (membercard != null)
            {
                if (Convert.ToInt32(membercard.MemberRankCode) == Convert.ToInt32(memberRankCode))
                {
                    return;
                }
                else
                {
                    //有会员卡且当前发放的会员卡和原有的会员卡编码不同
                    membercard.MemberRankId = card.ID;
                    membercard.Date = DateTime.Now;
                    membercard.Valid = true;
                    membercard.HandleBy = null;
                    await memberCardHandleService.UpdateAsync(membercard);
                    MemberCardSendRecordDto updateRecord = new MemberCardSendRecordDto
                    {
                        CustomerId = customerId,
                        MemberCardNum = membercard.MemberCardNum,
                        MemberRankId = card.ID,
                        HandleBy = membercard.HandleBy
                    };
                    await memberCardSendRecordService.AddAsync(updateRecord);
                    //暂时不赠送抵用券
                    /*//如果是白金会员,发放白金会员抵用券
                    if (memberRankCode == MemberRankCode.MEIYAWhiteCardMember)
                    {
                        await customerConsumptionVoucherService.MEIYAWhiteCardMemberSendVoucherAsync(customerId,0);
                    }
                    //如果是黑金会员,发放黑金会员抵用券
                    if (memberRankCode == MemberRankCode.BlackCardMember)
                    {
                        await customerConsumptionVoucherService.BlackCardMemberSendVoucherAsync(customerId,0);
                    }*/
                }
            }
            else {
                var latestMemberCard = await memberCardHandleService.GetMemberCardHandleLastNumAsync(card.ID); ;
                var createCard = CreateMemberCardAsync(latestMemberCard, "", memberRankCode, card.ID);
                createCard.CustomerId = customerId;
                createCard.HandleBy = null;
                await memberCardHandleService.AddAsync(createCard);
                MemberCardSendRecordDto record = new MemberCardSendRecordDto
                {
                    CustomerId = customerId,
                    MemberCardNum = createCard.MemberCardNum,
                    MemberRankId = card.ID,
                    HandleBy = createCard.HandleBy
                };
                await memberCardSendRecordService.AddAsync(record);
                //普通会员发放抵用券
                //await customerConsumptionVoucherService.OrdinaryMemberSendVoucherAsync(customerId,0);
            }
            



        }
        private  MemberCardHandleDto CreateMemberCardAsync(string latestMemberCardNum, string inputMemberCardNum,string memberRankCode,int memberCardId)
        {
            string memberCardNum = "";
            DateTime date = DateTime.Now;
            if (string.IsNullOrEmpty(latestMemberCardNum))
            {
                memberCardNum = "01030";
            }
            else {
                memberCardNum = latestMemberCardNum.Substring(memberRankCode.Length + 2);
            }
            memberCardNum = (Convert.ToInt32(memberCardNum) + 1).ToString().PadLeft(memberCardNum.Length, '0');
            string year = date.Year.ToString().Substring(date.Year.ToString().Length - 2);
            memberCardNum = memberRankCode + year + memberCardNum;
            /*string year = date.Year.ToString().Substring(date.Year.ToString().Length - 2);
            memberCardNum = RankCode + year + memberCardNum;*/
            return new MemberCardHandleDto()
            {
                MemberCardNum = memberCardNum,
                Date = DateTime.Now,
                Valid = true,
                MemberRankId=(byte)memberCardId
            };
        }

        /// <summary>
        /// 判断是不是普通会员
        /// </summary>
        /// <param name="growthPoints"></param>
        /// <returns></returns>
        private bool IsOrdinaryMember(decimal growthPoints) {
            if (growthPoints >= 0m) return true;
            return false;
        }
        /// <summary>
        /// 判断是不是白金卡会员
        /// </summary>
        /// <param name="growthPoints"></param>
        /// <returns></returns>
        private async Task<bool> IsMEIYAWhiteCardMemberAsync(decimal growthPoints)
        {
            var memberCard = await memberCardRankInfoService.GetMemberRankInfoByRankCodeAsync(MemberRankCode.MEIYAWhiteCardMember);
            if (growthPoints >= memberCard.MinAmount) return true;
            return false;
        }
        /// <summary>
        /// 判断是不是黑卡会员
        /// </summary>
        /// <param name="growthPoints"></param>
        /// <returns></returns>
        private async Task<bool> IsBlackCardMemberAsync(decimal growthPoints) {
            var memberCard = await memberCardRankInfoService.GetMemberRankInfoByRankCodeAsync(MemberRankCode.BlackCardMember);
            if (growthPoints >= memberCard.MinAmount) return true;
            return false;
        }
        /// <summary>
        /// 计算升级下一等级所需的成长值
        /// </summary>
        /// <param name="growthPoints"></param>
        /// <returns></returns>
        public async Task<MemberCardUpgradeDto> GetUpgradeInfoAsync(decimal growthPoints,string customerId)
        {
            if (growthPoints<0)throw new Exception("成长值不能小于0") ;
            var memberCardList = await memberCardRankInfoService.GetMemberRankInfoListAsync();
            memberCardList = memberCardList.OrderBy(m => Convert.ToInt32(m.RankCode)).ToList();
            var card = await memberCardHandleService.GetMemberCardByCustomeridAsync(customerId);
            var nextLeave= memberCardList.Where(e => Convert.ToInt32(e.RankCode) > Convert.ToInt32(card.MemberRankCode)).FirstOrDefault();
            if (nextLeave != null)
            {
                MemberCardUpgradeDto upgradeDto = new MemberCardUpgradeDto();
                upgradeDto.NextLeaveText = nextLeave.Name;
                decimal upgardePoints = nextLeave.MinAmount - growthPoints;
                upgradeDto.UpgardeNeedGrowthPoints = upgardePoints < 0 ? 0 : upgardePoints;
                return upgradeDto;
            }
            else {
                return new MemberCardUpgradeDto();
            }

            /*MemberCardUpgradeDto upgrade = new MemberCardUpgradeDto();
            var ordinaryMemberAmount = await memberCardRankInfoService.GetMemberRankInfoByRankCodeAsync(MemberRankCode.OrdinaryMember);
            var ordinaryMemberMinAmount = ordinaryMemberAmount.MinAmount;
            var ordinaryMemberMaxAmount = ordinaryMemberAmount.MaxAmount;
            if (growthPoints >= ordinaryMemberMinAmount && growthPoints < ordinaryMemberMaxAmount) {
                upgrade.UpgardeNeedGrowthPoints = ordinaryMemberMaxAmount - growthPoints;
                upgrade.NextLeaveText = ServiceClass.GetMemberCradName(MemberRankCode.MEIYAWhiteCardMember);
                return upgrade;
            }
            var MEIYAWhiteCardMemberAmount = await memberCardRankInfoService.GetMemberRankInfoByRankCodeAsync(MemberRankCode.MEIYAWhiteCardMember);
            var MEIYAWhiteCardMemberMinAmount = MEIYAWhiteCardMemberAmount.MinAmount;
            var MEIYAWhiteCardMemberMaxAmount = MEIYAWhiteCardMemberAmount.MaxAmount;
            if (growthPoints >= MEIYAWhiteCardMemberMinAmount && growthPoints < MEIYAWhiteCardMemberMaxAmount)
            {
                upgrade.UpgardeNeedGrowthPoints = MEIYAWhiteCardMemberMaxAmount - growthPoints;
                upgrade.NextLeaveText = ServiceClass.GetMemberCradName(MemberRankCode.BlackCardMember);
                return upgrade;
            }
            upgrade.NextLeaveText = "";
            upgrade.UpgardeNeedGrowthPoints = 0;*/           
        }
    }
}
