using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Balance
{
    public class RechargeVo
    {
        /// <summary>
        /// 金额
        /// </summary>
        public string AmountId { get; set; }
        /// <summary>
        /// 充值方式编码 ALIPAY,WECHAT
        /// </summary>
        public string ExchangeCode { get; set; }
    }
}
