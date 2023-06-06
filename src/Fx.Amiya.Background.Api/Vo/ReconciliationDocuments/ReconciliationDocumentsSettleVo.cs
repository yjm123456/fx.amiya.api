using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class ReconciliationDocumentsSettleVo
    {
        /// <summary>
        /// 审核时间
        /// </summary>
        [Description("审核时间")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 对账单编号
        /// </summary>
        [Description("对账单编号")]
        public string RecommandDocumentId { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        [Description("医院")]
        public string HospitalName { get; set; }

        /// <summary>
        /// 是否开票
        /// </summary>
        [Description("是否开票")]
        public string IsCerateBill { get; set; }

        /// <summary>
        /// 收款公司
        /// </summary>
        [Description("收款公司")]
        public string BelongCompany { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>

        [Description("收款公司")]
        public string BelongCompany2 { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string OrderId { get; set; }
        /// <summary>
        /// 订单项目
        /// </summary>
        [Description("订单项目")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Phone { get; set; }
        /// <summary>
        /// 成交编号
        /// </summary>
        [Description("成交编号")]
        public string DealInfoId { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        [Description("成交时间")]
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        [Description("订单来源")]

        public string OrderFromText { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [Description("订单金额")]
        public decimal OrderPrice { get; set; }
        /// <summary>
        /// 对账金额
        /// </summary>
        [Description("对账金额")]
        public decimal? RecolicationPrice { get; set; }
        /// <summary>
        /// 新/老客业绩
        /// </summary>
        [Description(" 新/老客业绩")]
        public string IsOldCustomerText { get; set; }
        /// <summary>
        /// 信息服务费
        /// </summary>
        [Description("信息服务费")]
        public decimal InformationPrice { get; set; }
        /// <summary>
        /// 系统使用费
        /// </summary>
        [Description("系统使用费")]
        public decimal SystemUpdatePrice { get; set; }
        /// <summary>
        /// 审核服务费金额
        /// </summary>
        [Description("审核服务费金额")]
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 审核客服业绩金额
        /// </summary>
        [Description("审核助理服务费金额")]
        public decimal? CustomerServiceSettlePrice { get; set; }
        /// <summary>
        /// 是否回款
        /// </summary>
        [Description("是否回款")]
        public string IsSettle { get; set; }
        /// <summary>
        /// 回款时间
        /// </summary>
        [Description("回款时间")]
        public DateTime? SettleDate { get; set; }
        /// <summary>
        /// 归属主播账号(可空存在)
        /// </summary>
        [Description("归属主播账号")]
        public string BelongLiveAnchor { get; set; }
        /// <summary>
        /// 归属客服(可空存在)
        /// </summary>
        [Description("归属客服")]
        public string BelongEmpName { get; set; }
        /// <summary>
        /// 业绩上传人员名称
        /// </summary>
        [Description("业绩上传人员")]
        public string? CreateEmpName { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public string CreateByEmpName { get; set; }
        /// <summary>
        /// 账单类型(false为入账，true为出账)
        /// </summary>

        [Description("账单类型")]
        public string AccountTypeText { get; set; }

        /// <summary>
        /// 出入账金额
        /// </summary>
        [Description("出入账金额")]
        public decimal AccountPrice { get; set; }
    }
}
