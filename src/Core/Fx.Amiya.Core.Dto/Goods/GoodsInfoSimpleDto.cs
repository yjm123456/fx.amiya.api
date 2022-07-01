using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
   public class GoodsInfoSimpleDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 商品组编号（预留）
        /// </summary>
        public int? GoodsGroupId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 略缩图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal? SalePrice { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary>
        public ExchangeType ExchangeType { get; set; }

        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 优惠价(预留)
        /// </summary>
        public decimal? ActualPrice { get; set; }
        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }


        /// <summary>
        /// 限购数量
        /// </summary>
        public int? LimitBuyQuantity { get; set; }
        public bool Valid { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }


        /// <summary>
        /// 是否实物商品
        /// </summary>
        public bool IsMaterial { get; set; }

    }
}
