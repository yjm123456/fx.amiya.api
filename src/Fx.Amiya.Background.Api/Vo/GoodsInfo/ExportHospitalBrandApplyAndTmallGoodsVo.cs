using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsInfo
{
    public class ExportHospitalBrandApplyAndTmallGoodsVo
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        [Description("医院名称")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 产品类型
        /// </summary>
        [Description("产品类型")]
        public string GoodsType { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        [Description("商品ID")]
        public string GoodsId { get; set; }
        /// <summary>
        /// 商品链接
        /// </summary>

        [Description("商品链接")]
        public string GooodsUrl { get; set; }

        /// <summary>
        /// 预估销量
        /// </summary>
        [Description("预估销量")]
        public int? AllSaleNum { get; set; }

        /// <summary>
        /// 超出预估销量原因
        /// </summary>
        [Description("超出预估销量原因")]
        public string ExceededReason { get; set; }
        /// <summary>
        /// SKU名称
        /// </summary>

        [Description("SKU名称")]
        public string SkuName { get; set; }

        /// <summary>
        /// 标价
        /// </summary>
        [Description("标价")]
        public decimal Price { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        [Description("总数量")]
        public int? AllCount { get; set; }

    }
}
