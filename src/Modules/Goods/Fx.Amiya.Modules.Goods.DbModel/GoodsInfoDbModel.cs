using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Modules.Goods.DbModel
{
   public class GoodsInfoDbModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SimpleCode { get; set; }
        public string Description { get; set; }

        public string DetailsDescription { get; set; }
        public string Standard { get; set; }
        public string Unit { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? MaxShowPrice { get; set; }
        public decimal? MinShowPrice { get; set; }
        public bool Valid { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }
        public int VisitCount { get; set; }
        public int SaleCount { get; set; }
        public int ShowSaleCount { get; set; }
        /// <summary>
        /// 交易方式：0=积分
        /// </summary>
        public byte ExchangeType { get; set; }

        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

 
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 是否实物商品
        /// </summary>
        public bool IsMaterial { get; set; }

        public byte GoodsType { get; set; }

        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }
        public int? LimitBuyQuantity { get; set; }

     
        public int CategoryId { get; set; }

        public int? GoodsDetailId { get; set; }


        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Version { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 归属小程序(为空时表示在所有小程序都显示)
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        /// 是否是热门商品
        /// </summary>
        public bool IsHot { get; set; }
        public GoodsCategoryDbModel GoodsCategory { get; set; }
        public GoodsDetailDbModel GoodsDetail { get; set; }
        public List<GoodsInfoCarouselImageDbModel> GoodsInfoCarouselImageList { get; set; }
        public List<GoodsMemberRankPriceDbModel> GoodsMemberRankPriceList { get; set; }
    }
}
