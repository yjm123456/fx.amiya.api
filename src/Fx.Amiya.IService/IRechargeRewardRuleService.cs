using Fx.Amiya.Dto.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IRechargeRewardRuleService
    {
        /// <summary>
        /// 获取所有的储值赠送规则
        /// </summary>
        /// <returns></returns>
        Task<List<RechargeRewardRuleDto>> GetRewardListAsync();
        /// <summary>
        /// 添加储值赠送规则
        /// </summary>
        /// <returns></returns>
        Task AddRechargeRewardRule(AddRechargeRewardRuleDto addRechargeRewardRuleDto);
    }
}
