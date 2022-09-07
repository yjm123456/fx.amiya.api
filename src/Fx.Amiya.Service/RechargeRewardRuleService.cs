using Fx.Amiya.DbModels.Model;
using Fx.Amiya.Dto.Recharge;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class RechargeRewardRuleService:IRechargeRewardRuleService
    {
        private readonly IDalRechargeRewardRule dalRechargeRewardRule;

        public RechargeRewardRuleService(IDalRechargeRewardRule dalRechargeRewardRule)
        {
            this.dalRechargeRewardRule = dalRechargeRewardRule;
        }
        /// <summary>
        /// 添加储值赠送规则
        /// </summary>
        /// <returns></returns>
        public async Task AddRechargeRewardRule(AddRechargeRewardRuleDto rechargeRewardRuleDto)
        {
            RechargeRewardRule rechargeRewardRule = new RechargeRewardRule { 
                Id=rechargeRewardRuleDto.Id,
                MinAmount=rechargeRewardRuleDto.MinAmount,
                GiveMoney=rechargeRewardRuleDto.GiveMoney,
                GiveIntegration=rechargeRewardRuleDto.GiveIntegration
            };
            await dalRechargeRewardRule.AddAsync(rechargeRewardRule, true);
        }

        /// <summary>
        /// 获取所有储值奖励规则
        /// </summary>
        /// <returns></returns>
        public async Task<List<RechargeRewardRuleDto>> GetRewardListAsync()
        {
            return dalRechargeRewardRule.GetAll().Select(e=>new RechargeRewardRuleDto {
                MinAmount=e.MinAmount,
                GiveMoney=e.GiveMoney,
                GiveIntegration=e.GiveIntegration
            }).OrderBy(e=>e.MinAmount).ToList();
        }
    }
}
