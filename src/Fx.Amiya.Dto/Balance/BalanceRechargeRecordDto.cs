using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Balance
{
    public class BalanceRechargeRecordDto
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        /// <summary>
        /// 支付方式 0支付宝,1微信,2商品退款,3储值赠送
        /// </summary>
        public int ExchageType { get; set; }
        /// <summary>
        /// 支付方式名称 0:支付宝,1:微信,2:商品退款,3储值赠送
        /// </summary>
        public string ExchageTypeText { get; set; }
        public decimal RechargeAmount { get; set; }
        public string OrderId { get; set; }
        public DateTime RechargeDate { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 订单状态文本
        /// </summary>
        public string StatusText { get; set; }
    }
}
