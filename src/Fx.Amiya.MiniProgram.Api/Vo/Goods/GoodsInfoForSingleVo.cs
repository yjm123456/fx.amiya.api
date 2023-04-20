﻿using Fx.Amiya.Core.Dto.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Goods
{
    public class GoodsInfoForSingleVo
    {
        public string Id { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbPicUrl { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
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
        /// 库存
        /// </summary>
        public int? InventoryQuantity { get; set; }

        /// <summary>
        /// 交易方式：0=积分支付
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
        /// 商品类型
        /// </summary>
        public byte GoodsType { get; set; }


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
        public List<int> CategoryIds { get; set; }


        /// <summary>
        /// 商品详情编号
        /// </summary>
        public int? GoodsDetailId { get; set; }

     

        /// <summary>
        /// 轮播图数组
        /// </summary>
        public List<GoodsInfoCarouselImageVo> CarouselImageUrls { get; set; }

        /// <summary>
        /// 商品html详情
        /// </summary>
        public string GoodsDetailHtml { get; set; }
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
        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal MemberRankPrice { get; set; }
        /// <summary>
        /// 是否是会员指定商品
        /// </summary>
        public bool IsMember { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 是否可使用抵用券
        /// </summary>
        public bool CanUseVoucher { get; set; }
        /// <summary>
        /// 关联规格价格
        /// </summary>
        public List<GoodsStandardsPriceVo> GoodsStandardsPrice { get; set; }
    }
}
