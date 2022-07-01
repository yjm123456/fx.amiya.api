using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.GoodsHospitalPrice
{
    public class GoodsHospitalPriceAddDto
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>

        public decimal Price { get; set; }
    }
}
