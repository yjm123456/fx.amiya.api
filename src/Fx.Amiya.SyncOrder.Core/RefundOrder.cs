using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.SyncOrder.Core
{
   public class RefundOrder
    {
        public string OrderId { get; set; }

        /// <summary>
        /// 退款状态：0=退款中，13=退款成功，14=退款失败
        /// </summary>
        public int Status { get; set; }

        public string StatusCode { get; set; }
    }
}
