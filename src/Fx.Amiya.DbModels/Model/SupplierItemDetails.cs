using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class SupplierItemDetails : BaseDbModel
    {
        /// <summary>
        /// 品项名称
        /// </summary>
        public string ItemDetailsName { get; set; }

        /// <summary>
        /// 品牌id
        /// </summary>
        public string BrandId { get; set; }

        public SupplierBrand SupplierBrand { get; set; }
        public List<LivingDailyTakeGoods> LivingDailyTakeGoodsList { get; set; }
    }
}
