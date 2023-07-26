using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class SupplierBrand:BaseDbModel
    {
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        public List<SupplierCategory> SupplierCategoryList { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }
    }
}
