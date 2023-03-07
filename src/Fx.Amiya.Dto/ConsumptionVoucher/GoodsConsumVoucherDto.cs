using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class GoodsConsumVoucherDto
    {
        public string GoodsId { get; set; }
        public string VoucherId { get; set; }
        public int VoucherType { get; set; }
        public decimal? DeductMoney { get; set; }
    }
}
