using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    public class GoodsHospitalPriceAddVo
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院价格
        /// </summary>

        public decimal Price { get; set; }
    }
}
