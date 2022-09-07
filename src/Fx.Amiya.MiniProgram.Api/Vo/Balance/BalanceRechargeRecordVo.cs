using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Balance
{
    public class BalanceRechargeRecordVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 充值类型 0,支付宝,1,微信,2商品退款
        /// </summary>
        public int ExchangeType { get; set; }
        public string ExchangeTypeText { get; set; }
        public decimal RechargeAmount { get; set; }
        public string OrderId { get; set; }
        public DateTime RechargeDate { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }

    }
}
