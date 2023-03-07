using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsStandardsPrice
{
    public class PriceDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 抵扣积分
        /// </summary>
        public decimal? IntegralAmount { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string StandardName { get; set; }
    }
}
