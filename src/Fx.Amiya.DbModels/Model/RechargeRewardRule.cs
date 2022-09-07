using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 储值奖励规则
    /// </summary>
    public class RechargeRewardRule
    {
        public string Id { get; set; }
        /// <summary>
        /// 触发奖励的最小金额
        /// </summary>
        public decimal MinAmount   { get; set; }
        /// <summary>
        /// 奖励储值
        /// </summary>
        public decimal GiveMoney { get; set; }
        /// <summary>
        /// 奖励积分
        /// </summary>
        public decimal GiveIntegration { get; set; }
    }
}
