using Fx.Amiya.Core.Dto.GoodsHospitalPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Goods
{
    public record GoodsInfoAddDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 简码
        /// </summary>
        public string SimpleCode { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal? SalePrice { get; set; }
        /// <summary>
        /// 最大展示金额
        /// </summary>
        public decimal? MaxShowPrice { get; set; }

        /// <summary>
        /// 最小展示金额
        /// </summary>
        public decimal? MinShowPrice { get; set; }


        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary>
        public ExchangeType ExchangeType { get; set; }

        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public decimal? IntegrationQuantity { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public byte GoodsType { get; set; }

        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 详情
        /// </summary>
        public string DetailsDescription { get; set; }

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
  

        public int CreateBy { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public int VisitCount { get; set; }
        /// <summary>
        /// 展示销量
        /// </summary>

        public int ShowSaleCount { get; set; }
        /// <summary>
        /// 门店价格
        /// </summary>
        public List<GoodsHospitalPriceAddDto> GoodsHospitalsAPrice { get; set; }

        /// <summary>
        /// 商品html内容
        /// </summary>
        public string GoodsDetailHtml { get; set; }
        public List<GoodsInfoCarouselImageAddDto> CarouselImageUrls { get; set; }
    }
}
