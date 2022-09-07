using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Recharge
{
    public class RechargeAmountVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
