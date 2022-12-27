using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher
{
    public class MemberReciveVoucherVo
    {
        /// <summary>
        /// 是否可领取优惠券
        /// </summary>
        public bool CanReceive { get; set; }
        /// <summary>
        /// 可领取的优惠券名称
        /// </summary>
        public string VoucherName { get; set; }
        /// <summary>
        /// 可领取的优惠券的抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
    }
}
