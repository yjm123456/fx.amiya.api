using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsConsumptionVoucher
{
    public class SimpleVoucherInfoDto
    {
        public string CustomerVoucherId { get; set; }
        public string  VoucherName { get; set; }
        public bool IsSpecifyProduct { get; set; }
        public int Type { get; set; }
        public bool IsNeedMinFee { get; set; }
        public decimal  MinPrice { get; set; }
        public string VoucherId { get; set; }
        public string Remark { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal DeductMoney { get; set; }
    }
}
