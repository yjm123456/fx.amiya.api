using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRefund
{
    public class RefundStartUpdateDto
    {
        public string Id { get; set; }
        public int RefundState { get; set; }
        /// <summary>
        /// 退款发起时间
        /// </summary>
        public DateTime RefundStartDate { get; set; }
        /// <summary>
        /// 退款失败原因
        /// </summary>
        public string RefundFailReason { get; set; }
        /// <summary>
        /// 微信退款订单号
        /// </summary>
        public string RefundTradeNo { get; set; }
    }
}
