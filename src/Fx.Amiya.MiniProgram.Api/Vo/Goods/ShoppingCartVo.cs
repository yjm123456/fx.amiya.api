using Fx.Amiya.Core.Dto.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Goods
{
    public class ShoppingCartVo
    {
        public long Id { get; set; }
        /// <summary>
        /// 加购商品数量
        /// </summary>
        public int Qauntity { get; set; }

        public string GoodsId { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }


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
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }

        /// <summary>
        /// 交易方式：0=积分
        /// </summary>
        public ExchangeType ExchangeType { get; set; }

        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }
        /// <summary>
        /// 是否实物商品
        /// </summary>
        public bool IsMaterial { get; set; }

        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }

        /// <summary>
        /// 限购数量
        /// </summary>
        public int? LimitBuyQuantity { get; set; }
    }
}
