﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class SupplierCategory : BaseDbModel
    {
        /// <summary>
        /// 品类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }

        public SupplierBrand SupplierBrand { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }
    }
}
