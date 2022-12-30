using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.GoodsShopCar
{
    public class AddGoodsShopCarVo
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 城市id
        /// </summary>
        public int? CityId { get; set; }

        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 选择的规格
        /// </summary>
        public string SelectStandard { get; set; }
    }
}
