using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderRefund
{
    public class RefundOrderResult
    {
        /// <summary>
        /// 退款结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 退款失败信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 退款交易号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 系统内部交易编号
        /// </summary>
        public string TardeId { get; set; }
    }
}
