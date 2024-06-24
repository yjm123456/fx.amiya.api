using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input
{
    public class BatchCheckFinanceReconciliationDocumentSettleVo
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
        /// 审核备注
        /// </summary>

        public string CheckRemark { get; set; }
        /// <summary>
        /// 财务id
        /// </summary>
        public int FinanceId { get; set; }

    }
}
