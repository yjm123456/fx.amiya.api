using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class BatchCheckFinanceReconciliationDocumentSettleDto
    {
        /// <summary>
        /// 对账单审核记录id
        /// </summary>
        public List<string> IdList { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>

        public int CheckState { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int CheckBy { get; set; }

        /// <summary>
        /// 审核类型（0:其他，1：自播达人审核，2：供应链达人审核，3：天猫升单审核）
        /// </summary>
        public int CheckType { get; set; }

        /// <summary>
        /// 是否为稽查业绩
        /// </summary>
        public bool IsInspectPerformance { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>

        public string CheckRemark { get; set; }


        /// <summary>
        /// 最终审核归属客服
        /// </summary>
        public int? CheckBelongEmpId { get; set; }
        /// <summary>
        /// 财务id
        /// </summary>
        public int FinanceId { get; set; }
    }
}
