using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    /// <summary>
    /// 会员每周领取优惠券
    /// </summary>
    public class MemberRecieveConsumptionVoucherDto
    {
        public decimal DeductMoney { get; set; }
        public string VoucherName { get; set; }
        public int VoucherType { get; set; }
        public string VoucherCode { get; set; }
    }
}
