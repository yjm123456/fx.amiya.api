using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.ConsumptionVoucher
{
    public class MemberReciveVoucherVo
    {
        /// <summary>
        /// 可领取的优惠券名称
        /// </summary>
        public string VoucherName { get; set; }
        /// <summary>
        /// 可领取的优惠券的抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
        /// <summary>
        /// 抵用券类型
        /// </summary>
        public int VoucherType { get; set; }
        /// <summary>
        /// 抵用券编码
        /// </summary>
        public string VoucherCode { get; set; }
        /// <summary>
        /// 抵用券备注
        /// </summary>
        public string Remark { get; set; }
    }
}
