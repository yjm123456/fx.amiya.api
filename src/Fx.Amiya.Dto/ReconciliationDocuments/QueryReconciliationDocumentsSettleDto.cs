using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    /// <summary>
    /// 查询对账单审核记录
    /// </summary>
    public class QueryReconciliationDocumentsSettleDto : BaseQueryDto
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public int? ChooseHospitalId { get; set; }

        /// <summary>
        /// 新/老客业绩
        /// </summary>
        public bool? IsOldCustoemr { get; set; }
        /// <summary>
        /// 归属客服
        /// </summary>
        public int? BelongEmpId { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int? CheckState { get; set; }
    }
}
