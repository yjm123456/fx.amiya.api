using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    /// <summary>
    /// 对账单审核记录审核薪资相关基础类
    /// </summary>
    public class CheckReconciliationDocumentSettleDto
    {
        /// <summary>
        /// 对账单审核记录id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>

        public int CheckState { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public int CheckBy { get; set; }
        /// <summary>
        /// 审核备注
        /// </summary>

        public string CheckRemark { get; set; }

        /// <summary>
        /// 最终审核归属客服
        /// </summary>
        public int? CheckBelongEmpId { get; set; }
        /// <summary>
        /// 提成点数
        /// </summary>
        public decimal PerformancePercent { get; set; }

        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal CustomerServicePerformance { get; set; }

    }
}
