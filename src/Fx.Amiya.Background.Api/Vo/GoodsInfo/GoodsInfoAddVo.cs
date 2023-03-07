using Fx.Amiya.Background.Api.Vo.GoodsConsumptionVoucher;
using Fx.Amiya.Background.Api.Vo.GoodsMemberRankPrice;
using Fx.Amiya.Core.Dto.Goods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    public class GoodsInfoAddVo
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "商品名称不能为空")]
        [StringLength(100, ErrorMessage = "商品名称最多不超过{1}个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 简码
        /// </summary>
        [Required(ErrorMessage = "商品简码不能为空")]
        [StringLength(100, ErrorMessage = "商品简码最多不超过{1}个字符")]
        public string SimpleCode { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Required(ErrorMessage = "商品规格不能为空")]
        [StringLength(100, ErrorMessage = "商品规格最多不超过{1}个字符")]
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
        [Required(ErrorMessage = "略缩图不能为空")]
        public string ThumbPicUrl { get; set; }


        /// <summary>
        /// 说明
        /// </summary>
        [StringLength(200, ErrorMessage = "描述说明最多不超过{1}个字符")]
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
        /// <summary>
        /// 浏览量
        /// </summary>
        public int VisitCount { get; set; }
        /// <summary>
        /// 展示销量
        /// </summary>

        public int ShowSaleCount { get; set; }

        /// <summary>
        /// 门店医院价格
        /// </summary>
        public List<GoodsHospitalPriceAddVo> AddGoodsHospitalPrice { get; set; }
        /// <summary>
        /// 规格价格
        /// </summary>
        public List<GoodsStandardsPriceAddVo> GoodsStandardsPrice { get; set; }

        /// <summary>
        /// 商品html内容
        /// </summary>
        [StringLength(8000, ErrorMessage = "商品详情内容最多不超过{1}个字符")]
        public string GoodsDetailHtml { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        public List<GoodsInfoCarouselImageAddVo> CarouselImageUrls { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public List<GoodsMemberRankPriceAddVo> AddGoodsMemberRankPrice { get; set; }
        /// <summary>
        /// 抵用券
        /// </summary>
        public List<GoodsConsumptionVoucherAddVo> AddGoodsConsumptionVoucher { get; set; }
        /// <summary>
        /// 商品标签
        /// </summary>
        public List<string> AddGoodsTag { get; set; }
    }
}
