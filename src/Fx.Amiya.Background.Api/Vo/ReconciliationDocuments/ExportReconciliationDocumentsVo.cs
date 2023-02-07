using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ReconciliationDocuments
{
    public class ExportReconciliationDocumentsVo 
    {
        /// <summary>
        /// 对账单编号
        /// </summary>
        [Description("对账单编号")]
        public string  Id { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        [Description("医院名称")]
        public string HospitalName { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        [Description("客户姓名")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        [Description("客户电话")]
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 成交项目
        /// </summary>
        [Description("成交项目")]
        public string DealGoods { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        [Description("成交时间")]
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 总成交金额（含材料费）
        /// </summary>
        [Description("总成交金额")]
        public decimal? TotalDealPrice { get; set; }
        /// <summary>
        /// 信息服务费比例（%）
        /// </summary>
        [Description("信息服务费比例（%）")]
        public decimal? ReturnBackPricePercent { get; set; }
        /// <summary>
        /// 信息服务费金额
        /// </summary>
        [Description("信息服务费金额")]
        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 系统维护费比例（%）
        /// </summary>
        [Description("系统维护费比例（%）")]
        public decimal? SystemUpdatePricePercent { get; set; }

        /// <summary>
        /// 系统维护费金额
        /// </summary>
        [Description("系统维护费金额")]
        public decimal? SystemUpdatePrice { get; set; }
        /// <summary>
        /// 服务费合计
        /// </summary>
        [Description("服务费合计")]
        public decimal? ReturnBackTotalPrice { get; set; }
        /// <summary>
        /// 问题原因
        /// </summary>
        [Description("问题原因")]
        public string QuestionReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 对账状态
        /// </summary>
        [Description("对账状态")]
        public string ReconciliationStateText { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        [Description("是否开票")]
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 票据编号
        /// </summary>
        [Description("票据编号")]
        public string BillId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string CreateByName { get; set; }
    }
}
