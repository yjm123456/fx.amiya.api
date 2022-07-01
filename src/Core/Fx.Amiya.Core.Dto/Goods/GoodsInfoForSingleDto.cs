using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    public record GoodsInfoForSingleDto
    {
        public string Id { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 简码
        /// </summary>
        public string SimpleCode { get; set; }

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
        public bool Valid { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary>
        public ExchangeType ExchangeType { get; set; }

        public string ExchangeTypeText { get; set; }

        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

    

        /// <summary>
        /// 是否实物商品
        /// </summary>
        public bool IsMaterial { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public byte GoodsType { get; set; }
        public string GoodsTypeName { get; set; }

        /// <summary>
        /// 是否限购
        /// </summary>
        public bool IsLimitBuy { get; set; }

        /// <summary>
        /// 限购数量
        /// </summary>
        public int? LimitBuyQuantity { get; set; }


        /// <summary>
        /// 商品分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }

        /// <summary>
        /// 商品详情编号
        /// </summary>
        public int? GoodsDetailId { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string DetailsDescription { get; set; }
        /// <summary>
        /// 最大展示价格
        /// </summary>
        public decimal? MaxShowPrice { get; set; }
        /// <summary>
        /// 最小展示价格
        /// </summary>
        public decimal? MinShowPrice { get; set; }
        /// <summary>
        /// 展示销量
        /// </summary>
        public int ShowSaleCount { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int VisitCount { get; set; }

        public DateTime CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public string UpdateByName { get; set; }

        /// <summary>
        /// 轮播图数组
        /// </summary>
        public List<GoodsInfoCarouselImageDto> CarouselImageUrls { get; set; }

        /// <summary>
        /// 关联门店价格
        /// </summary>
        public List<GoodsHospitalPriceDto> GoodsHospitalPrice { get; set; }

        /// <summary>
        /// 商品html详情
        /// </summary>
        public string GoodsDetailHtml { get; set; }
    }
}
