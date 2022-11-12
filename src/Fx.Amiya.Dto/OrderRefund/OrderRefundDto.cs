using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRefund
{
    public class OrderRefundDto
    {
        /// <summary>
        /// 退款订单id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 退款交易id
        /// </summary>
        public string TradeId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 审核状态(0,待审核,1审核通过,2审核失败)
        /// </summary>
        public int CheckState { get; set; }
        /// <summary>
        /// 审核状态文本
        /// </summary>
        public string CheckStateText { get; set; }
        /// <summary>
        /// 审核失败原因
        /// </summary>
        public string UncheckReason { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public int RefundState { get; set; }
        /// <summary>
        /// 退款状态文本
        /// </summary>
        public string RefundStateText { get; set; }
        /// <summary>
        /// 退款失败原因
        /// </summary>
        public string RefundFailReason { get; set; }
        /// <summary>
        /// 是否是订单部分退款
        /// </summary>
        public bool IsPartial { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int ExchangeType { get; set; }
        /// <summary>
        /// 退款商品名
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 支付方式文本
        /// </summary>
        public string ExchageTypeText { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime? PayDate { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckDate { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        public decimal RefundAmount { get; set; }
        /// <summary>
        /// 实际支付
        /// </summary>
        public decimal ActualPayAmount { get; set; }
        /// <summary>
        /// 退款发起时间
        /// </summary>
        public DateTime? RefundStartDate { get; set; }
        /// <summary>
        /// 退款回调时间
        /// </summary>
        public DateTime? RefundResultDate { get; set; }
        /// <summary>
        /// 退款交易订单号
        /// </summary>
        public string RefundTradeNo { get; set; }
        /// <summary>
        /// 审核人员
        /// </summary>
        public int? CheckBy { get; set; }
        /// <summary>
        /// 审核人员名称
        /// </summary>
        public string CheckByName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
