﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    /// <summary>
    /// 商品规格对应价格
    /// </summary>
    public class GoodsStandardsPriceAddVo
    {
        /// <summary>
        /// 规格
        /// </summary>
        public string Standards { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 积分价格
        /// </summary>
        public decimal? IntegralAmount { get; set; }
        /// <summary>
        /// 规格图片
        /// </summary>
        public string StandardsImg { get; set; }
    }
}
