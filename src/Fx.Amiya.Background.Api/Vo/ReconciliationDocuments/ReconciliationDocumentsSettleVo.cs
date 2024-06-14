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
        /// 对账单审核记录编号
        /// </summary>
        public string Id { get; set; }
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
        /// 下单金额（内容平台）
        /// </summary>
        [Description(" 下单金额（内容平台）")]
        public decimal ContentPlatFormOrderAddOrderPrice { get; set; }
        /// <summary>
        /// 新/老客业绩
        /// </summary>
        [Description(" 新/老客业绩")]
        public string IsOldCustomerText { get; set; }

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
        [Description("服务费合计")]
        public decimal ReturnBackPrice { get; set; }
        /// <summary>
        /// 审核客服业绩金额
        /// </summary>
        [Description("助理服务费合计")]
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
        public string CreateEmpName { get; set; }
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
        /// <summary>
        /// 薪资审核状态
        /// </summary>
        public string CompensationCheckStateText { get; set; }

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
        public string CheckBelongEmpName { get; set; }

        /// <summary>
        /// 薪资单据id
        /// </summary>
        public string CustomerServiceCompensationId { get; set; }

        /// <summary>
        /// 稽查薪资单据id
        /// </summary>
        public string InspectCustomerServiceCompensationId { get; set; }

        /// <summary>
        /// 提成点数
        /// </summary>
        public decimal PerformancePercent { get; set; }

        /// <summary>
        /// 提成金额
        /// </summary>
        public decimal CustomerServicePerformance { get; set; }
        /// <summary>
        /// 薪资审核类型
        /// </summary>
        public string CheckTypeText { get; set; }
        /// <summary>
        /// 是否为稽查订单
        /// </summary>
        public bool IsInspectPerformance { get; set; }

        /// <summary>
        /// 行政客服稽查金额
        /// </summary>
        public decimal InspectPrice { get; set; }

        /// <summary>
        /// 行政客服稽查点数
        /// </summary>
        public decimal InspectPercent { get; set; }

        /// <summary>
        /// 稽查人员名称
        /// </summary>
        public string InspectEmpName { get; set; }
        /// <summary>
        /// 助理确认业绩-薪资审核时产生
        /// </summary>
        public decimal CustomerServiceOrderPerformance { get; set; }
    }
}
