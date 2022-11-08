using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class OrderRefund:BaseDbModel
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
        public string TardeId { get; set; }
        /// <summary>
        /// 审核状态(0,待审核,1审核通过,2审核失败)
        /// </summary>
        public byte CheckState { get; set; }
        /// <summary>
        /// 审核失败原因
        /// </summary>
        public string UncheckReason { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public string RefundState { get; set; }
        public string RefundFailReason { get; set; }
        public byte IsPartial { get; set; }
        public byte ExchangeType { get; set; }
        public DateTime? PayDate { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal RefundAmount { get; set; }
        public decimal ActualPayAmount { get; set; }
        public DateTime RefundDate { get; set; }
        public DateTime RefundSuccessDate { get; set; }
        public string RefundTradeNo { get; set; }
    }
}
