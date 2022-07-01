using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    /// <summary>
    /// SKU信息
    /// </summary>
    public class AddTmallGoodsSkuVo
    {
        /// <summary>
        /// sku名称
        /// </summary>
        public string SkuName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int? AllCount { get; set; }
    }
}
