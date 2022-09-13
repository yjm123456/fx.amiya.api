using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 商品可用抵用券
    /// </summary>
    public class GoodsConsumptionVoucher
    {
        public string Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 抵用券id
        /// </summary>
        public string ConsumptionVoucherId { get; set; }

    }
}
