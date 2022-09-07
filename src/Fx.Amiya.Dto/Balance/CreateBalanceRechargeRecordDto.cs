using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    public class CreateBalanceRechargeRecordDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 充值用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 充值方式 0:支付宝支付,1:微信支付 
        /// </summary>
        public int ExchangeType { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeAmount { get; set; }
        /// <summary>
        /// 支付流水号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 充值前余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime RechargeDate { get; set; }
        /// <summary>
        /// 充值状态 0:待付款,1充值成功,2取消充值
        /// </summary>
        public int Status { get; set; }
    }
}
