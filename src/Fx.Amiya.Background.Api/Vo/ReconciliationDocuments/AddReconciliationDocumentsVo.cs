using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class AddReconciliationDocumentsVo
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        [Description("客户姓名")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Description("客户电话")]
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 成交项目
        /// </summary>
        [Description("成交项目")]
        public string DealGoods { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        [Description("成交时间")]
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 总成交金额（含材料费）
        /// </summary>
        [Description("总成交金额（含材料费）")]
        public decimal? TotalDealPrice { get; set; }
        /// <summary>
        /// 返款比例（%）
        /// </summary>
        [Description("返款比例（%）")]
        public decimal? ReturnBackPricePercent { get; set; }
        /// <summary>
        /// 系统维护费比例（%）
        /// </summary>
        [Description("系统维护费比例（%）")]
        public decimal? SystemUpdatePricePercent { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
    }
}
