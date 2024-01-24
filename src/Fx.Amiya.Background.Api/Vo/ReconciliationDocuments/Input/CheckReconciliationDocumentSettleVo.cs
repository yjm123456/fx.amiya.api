using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input
{
    /// <summary>
    /// 对账单审核记录审核薪资相关基础类
    /// </summary>
    public class CheckReconciliationDocumentSettleVo
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
        #region 助理业绩
        /// <summary>
        /// 助理确认业绩
        /// </summary>
        public decimal CustomerServiceOrderPerformance { get; set; }

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
        #endregion

        #region 稽查人员业绩


        /// <summary>
        /// 稽查人员id
        /// </summary>
        public int? InspectEmpId { get; set; }

        /// <summary>
        /// 稽查比例-稽查人员
        /// </summary>
        public decimal InspectPercent { get; set; }

        /// <summary>
        /// 稽查金额-稽查人员
        /// </summary>
        public decimal InspectPrice { get; set; }
        #endregion


    }
}
