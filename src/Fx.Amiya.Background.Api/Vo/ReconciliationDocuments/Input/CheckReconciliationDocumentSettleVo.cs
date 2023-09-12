using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments.Input
{
    /// <summary>
    /// 对账单审核记录审核薪资相关基础类
    /// </summary>
    public class CheckReconciliationDocumentSettleVo:BaseQueryVo
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

    }
}
