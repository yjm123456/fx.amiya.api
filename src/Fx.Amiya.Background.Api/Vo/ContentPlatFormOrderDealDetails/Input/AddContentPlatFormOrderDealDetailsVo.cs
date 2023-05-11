﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlatFormOrderDealDetails.Input
{
    public class AddContentPlatFormOrderDealDetailsVo
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 项目规格
        /// </summary>
        public string GoodsSpec { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string ContentPlatFormOrderId { get; set; }
    }
}
