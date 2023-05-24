using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class AddRecommandDocumentSettleDto
    {
        public string RecommandDocumentId { get; set; }
        public string OrderId { get; set; }
        public string DealInfoId { get; set; }

        public int OrderFrom { get; set; }
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 对账金额
        /// </summary>
        public decimal RecolicationPrice { get; set; }
        public bool IsOldCustomer { get; set; }
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 审核客服结算金额
        /// </summary>

        public decimal CustomerServiceSettlePrice { get; set; }
        /// <summary>
        /// 业绩上传人员
        /// </summary>
        public int? CreateEmpId { get; set; }

        /// <summary>
        /// 归属主播账号(可空)
        /// </summary>
        public int? BelongLiveAnchorAccount { get; set; }
        /// <summary>
        /// 归属客服(可空)
        /// </summary>
        public int? BelongEmpId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 账单类型
        /// </summary>
        public bool AccountType { get; set; }

        /// <summary>
        /// 出入账金额
        /// </summary>
        public decimal AccountPrice { get; set; }
    }
}
