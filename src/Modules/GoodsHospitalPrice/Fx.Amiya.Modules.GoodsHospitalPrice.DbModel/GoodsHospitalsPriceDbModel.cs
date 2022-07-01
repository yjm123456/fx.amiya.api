using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Modules.GoodsHospitalPrice.Domin
{
    public class GoodsHospitalsPriceDbModel
    {
        public string GoodsId { get; set; }
        public int HospitalId { get; set; }

        public decimal Price { get; set; }
    }
}
