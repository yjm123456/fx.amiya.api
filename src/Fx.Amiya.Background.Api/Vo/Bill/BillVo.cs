using Fx.Amiya.Background.Api.Vo.ReconciliationDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Bill
{
    /// <summary>
    /// 发票基础类
    /// </summary>
    public class BillVo : BaseVo
    {
        /// <summary>
        /// 客户id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal BillPrice { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// 税额（发票金额/（（1+税率）*税率）--保留2位小数）
        /// </summary>
        public decimal TaxPrice { get; set; }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal NotInTaxPrice { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherPrice { get; set; }
        /// <summary>
        /// 费用备注
        /// </summary>
        public string OtherPriceRemark { get; set; }
        /// <summary>
        /// 收款公司id
        /// </summary>
        public string CollectionCompanyId { get; set; }

        /// <summary>
        /// 收款公司名称
        /// </summary>
        public string CollectionCompanyName { get; set; }
        /// <summary>
        /// 票据归属时间（起）
        /// </summary>
        public DateTime BelongStartTime { get; set; }
        /// <summary>
        /// 票据归属时间（止）
        /// </summary>
        public DateTime BelongEndTime { get; set; }
        /// <summary>
        /// 票据类型
        /// </summary>
        public int BillType { get; set; }
        /// <summary>
        /// 票据类型文本（医美/其他）
        /// </summary>
        public string BillTypeText { get; set; }
        /// <summary>
        /// 开票事由
        /// </summary>
        public string CreateBillReason { get; set; }
        /// <summary>
        /// 回款状态
        /// </summary>
        public int ReturnBackState { get; set; }
        /// <summary>
        /// 累计回款金额
        /// </summary>
        public decimal? ReturnBackPrice { get; set; }

        /// <summary>
        /// 回款状态文本（未回款/回款中/已回款）
        /// </summary>
        public string ReturnBackStateText { get; set; }
        /// <summary>
        /// 开票人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 开票人名称
        /// </summary>
        public string CreateByEmployeeName { get; set; }
        /// <summary>
        /// 是否作废文本（正常，作废）
        /// </summary>
        public string ValidText { get; set; }

        /// <summary>
        /// 发票明细
        /// </summary>
        public List<ReconciliationDocumentsVo> reconciliationDocumentList { get; set; }
    }
}
