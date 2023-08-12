using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ItemInfo
{
    public class GoodsItemInfoDto
    {
        /// <summary>
        /// 品类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 品类id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 品项名称
        /// </summary>
        public string ItemDetail { get; set; }
        /// <summary>
        /// 品项id
        /// </summary>
        public string ItemDetailId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int GoodsId { get; set; }
    }
}
