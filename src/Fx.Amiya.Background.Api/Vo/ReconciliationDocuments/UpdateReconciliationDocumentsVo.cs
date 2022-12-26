using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class UpdateReconciliationDocumentsVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 成交项目
        /// </summary>
        public string DealGoods { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 总成交金额（含材料费）
        /// </summary>
        public decimal? TotalDealPrice { get; set; }
        /// <summary>
        /// 信息服务费比例（%）
        /// </summary>
        public decimal? ReturnBackPricePercent { get; set; }
        /// <summary>
        /// 系统维护费比例（%）
        /// </summary>
        public decimal? SystemUpdatePricePercent { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
