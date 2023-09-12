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
        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 对账金额
        /// </summary>
        public decimal? RecolicationPrice { get; set; }
        public bool IsOldCustomer { get; set; }
        /// <summary>
        /// 服务费合计
        /// </summary>
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 审核客服结算金额
        /// </summary>

        public decimal CustomerServiceSettlePrice { get; set; }
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
        /// 业绩上传人员
        /// </summary>
        public int? CreateEmpId { get; set; }
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

        /// <summary>
        /// 对账医院id
        /// </summary>
        public int HospitalId { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
        /// <summary>
        /// 薪资审核状态
        /// </summary>
        public int CompensationCheckState { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int? CheckBy { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? CheckDate { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string CheckRemark { get; set; }

        /// <summary>
        /// 审核归属客服
        /// </summary>
        public int? CheckBelongEmpId { get; set; }
        /// <summary>
        /// 对账单
        /// </summary>
        //public ReconciliationDocuments ReconciliationDocuments { get; set; }
    }
}
