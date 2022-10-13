using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class BalanceRechargeRecord:BaseDbModel
    {
        /// <summary>
        /// 充值用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 充值方式 0:支付宝支付,1:微信支付,2:商品退货返回余额,3:储值奖励
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
        /// 充值状态 0:待付款,1充值成功,2取消充值,3支付中
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompleteDate { get; set; }

    }
}
