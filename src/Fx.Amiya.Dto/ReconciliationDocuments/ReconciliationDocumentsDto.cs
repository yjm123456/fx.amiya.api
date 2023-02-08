using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class ReconciliationDocumentsDto:BaseDto
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 客户电话
        /// </summary>
        public string CustomerPhone { get; set; }
        /// <summary>
        /// 成交项目
        /// </summary>
        public string DealGoods { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public DateTime? DealDate { get; set; }
        /// <summary>
        /// 总成交金额（含材料费）
        /// </summary>
        public decimal? TotalDealPrice { get; set; }
        /// <summary>
        /// 信息服务费比例
        /// </summary>
        public decimal? ReturnBackPricePercent { get; set; }

        /// <summary>
        /// 信息服务费
        /// </summary>
        public decimal? ReturnBackPrice { get; set; }
        /// <summary>
        /// 系统维护费比例
        /// </summary>
        public decimal? SystemUpdatePricePercent { get; set; }
        /// <summary>
        /// 系统维护费
        /// </summary>
        public decimal? SystemUpdatePrice { get; set; }
        /// <summary>
        /// 服务费合计
        /// </summary>
        public decimal? TotalReconciliationDocumentsPrice { get; set; }
        /// <summary>
        /// 问题原因
        /// </summary>
        public string QuestionReason { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 对账状态
        /// </summary>

        public int ReconciliationState { get; set; }

        /// <summary>
        /// 对账状态文本
        /// </summary>
        public string ReconciliationStateText { get; set; }
        /// <summary>
        /// (院方账户)创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 创建人名
        /// </summary>
        public string CreateByName { get; set; }
        /// <summary>
        /// 是否开票
        /// </summary>
        public bool IsCreateBill { get; set; }
        /// <summary>
        /// 票据编号
        /// </summary>
        public string BillId { get; set; }

    }
}
