﻿using Fx.Amiya.Dto.MemberRankPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsShopCar
{
    public class GoodsShopCarDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string GoodsPictureUrl { get; set; }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public decimal? InterGrationAccount { get; set; }
        /// <summary>
        /// 规格的积分价格
        /// </summary>
        public decimal InterGrationPrice { get; set; }

        /// <summary>
        /// 交易类型(积分支付展示积分；三方支付展示价格)
        /// </summary>
        public int ExchangeType { get; set; }

        /// <summary>
        /// 城市id
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        public string Hospital { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 购物车状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        public bool  IsMaterial { get; set; }
        /// <summary>
        /// 医院门店价格
        /// </summary>
        public decimal? HospitalSalePrice { get; set; }
        /// <summary>
        /// 选中的规格
        /// </summary>
        public string SelectStandards { get; set; }
        /// <summary>
        /// 规格是否有效
        /// </summary>
        public bool StandardsIsValid { get; set; }
        /// <summary>
        /// 会员价格列表
        /// </summary>
        public List<GoodsMemberRankPriceDto> GoodsMemberRankPriceList { get; set; }
        /// <summary>
        /// 商品抵用券id集合
        /// </summary>
        public List<string> VoucherIdList { get; set; }
    }
}
