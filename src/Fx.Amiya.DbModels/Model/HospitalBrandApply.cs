using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalBrandApply
    {
        public string Id { get; set; }
        public string HospitalName { get; set; }
        public string GoodsId { get; set; }
        public string GoodsType { get; set; }

        public string GoodsUrl { get; set; }

        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        public string ExceededReason { get; set; }
    }
}
