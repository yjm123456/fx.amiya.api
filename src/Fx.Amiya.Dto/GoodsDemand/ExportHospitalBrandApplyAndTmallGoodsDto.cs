using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsDemand
{
    public class ExportHospitalBrandApplyAndTmallGoodsDto
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 商品链接
        /// </summary>
        public string GooodsUrl { get; set; }
        /// <summary>
        /// 预估销量
        /// </summary>
        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        public string ExceededReason { get; set; }
        /// <summary>
        /// SKU名称
        /// </summary>

        public string SkuName { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        public string GoodsType { get; set; }
        /// <summary>
        /// 标价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int? AllCount { get; set; }

    }
}
