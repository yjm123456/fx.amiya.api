using Fx.Amiya.Dto.ConsumptionVoucher;
using Fx.Amiya.Dto.GoodsStandardsPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsInfo
{
    public class GoodsOrderInfoDto
    {
        public string Id { get; set; }
        public int ExchageType { get; set; }
        public string GoodsName { get; set; }
        public int InventoryQuantity { get; set; }
        public string ThumailPic { get; set; }
        public List<PriceDto> StandardList { get; set; }
        public List<GoodsConsumVoucherDto> VoucherList { get; set; }

    }
}
