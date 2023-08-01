using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TakeGoods.Result
{
    public class BrandAnalizeDataVo
    {
        /// <summary>
        /// 下单GMVTOP20
        /// </summary>
        public List<TopCreateOrderGMVVo> TopCreateOrderGMVDtoList { get; set; }
        /// <summary>
        /// 下单GMV占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderGMVAnalizeData { get; set; }
        /// <summary>
        /// 下单件数占比分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderNumAnalizeData { get; set; }
        /// <summary>
        /// 下单件单价分析
        /// </summary>
        public List<BaseIdNameAndRateVo> CreateOrderSinglePriceAnalizeData { get; set; }
    }
    public class TopCreateOrderGMVVo
    {

        public string BrandName { get; set; }
        public decimal CreateOrderGMV { get; set; }
        public int CreateOrderQuantity { get; set; }
        public decimal SinglePrice { get; set; }
    }
}
