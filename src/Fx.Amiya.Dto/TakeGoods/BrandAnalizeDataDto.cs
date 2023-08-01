using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TakeGoods
{
    public class BrandAnalizeDataDto
    {

        /// <summary>
        /// 下单GMVTOP20
        /// </summary>
        public List<TopCreateOrderGMVDto> TopCreateOrderGMVDtoList { get; set; }
        /// <summary>
        /// 下单GMV占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderGMVAnalizeData { get; set; }
        /// <summary>
        /// 下单件数占比分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderNumAnalizeData { get; set; }
        /// <summary>
        /// 下单件单价分析
        /// </summary>
        public List<BaseKeyValueAndPercentDto> CreateOrderSinglePriceAnalizeData { get; set; }
    }

    public class TopCreateOrderGMVDto
    {

        public string BrandName { get; set; }
        public decimal CreateOrderGMV { get; set; }
        public int CreateOrderQuantity { get; set; }
        public decimal SinglePrice { get; set; }
    }
}
