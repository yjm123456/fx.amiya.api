using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ConsumptionVoucher
{
    /// <summary>
    /// 发放优惠券
    /// </summary>
    public class SendVoucherVo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 优惠券编码
        /// </summary>
        public string VoucherCode { get; set; }
    }
}
