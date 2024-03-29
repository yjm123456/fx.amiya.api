﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.WareHouse.AmiyaWareHouse
{
    public class ExportAmiyaWareHouseVo
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        [Description("物料名称")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        public string Unit { get; set; }


        /// <summary>
        /// 归属仓库
        /// </summary>
        [Description("归属仓库")]
        public string GoodsSourceName { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Description("单价")]
        public decimal SinglePrice { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        public int Amount { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")]
        public decimal TotalPrice { get; set; }
    }
}
