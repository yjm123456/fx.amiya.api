using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.Input
{
    public class FinishContentPlateFormOrderByApi
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospitalId { get; set; }
        /// <summary>
        /// 消费类型{ 0=收费  1=退费}
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public string CustomerPhone { get; set; }

        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 本次货币金额总额
        /// </summary>
        public decimal TotalCashAmount { get; set; }

        /// <summary>
        /// 操作类型 0交预交金，1=办卡，2=项目收费，3=划价单收费，4卡类欠款回收，5=欠款回收
        /// </summary>
        public int ConsumptionType { get; set; }

        /// <summary>
        ///退款类型 0=退预交金，1=退卡，2=退项目，3=退划价单，4退多余欠款，
        /// </summary>
        public int RefundType { get; set; }
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 成交详情
        /// </summary>
        public List<FinishContentPlateFormOrderByApiDetails> Details { get; set; }
    }

    /// <summary>
    /// 成交详情
    /// </summary>
    public class FinishContentPlateFormOrderByApiDetails
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目规格
        /// </summary>
        public string ItemStandard { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 货币金额
        /// </summary>
        public decimal CashAmount { get; set; }
    }
}
