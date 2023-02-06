using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class RecommandDocumentSettle
    {
        public string Id { get; set; }
        public string RecommandDocumentId { get; set; }
        public string OrderId { get; set; }
        public string DealInfoId { get; set; }

        public int OrderFrom { get; set; }
        public decimal OrderPrice { get; set; }
        public bool IsOldCustomer { get; set; }
        public decimal ReturnBackPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSettle { get; set; }
        public DateTime? SettleDate { get; set; }
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
        /// 账单类型(false为入账，true为出账)
        /// </summary>
        public bool AccountType { get; set; }

        /// <summary>
        /// 出入账金额
        /// </summary>
        public decimal AccountPrice { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
        /// <summary>
        /// 对账单
        /// </summary>
        //public ReconciliationDocuments ReconciliationDocuments { get; set; }
    }
}
