using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget
{
    public class BeforeLivingDailyTargetVo : BaseVo
    {
        /// <summary>
        /// 主播月目标id
        /// </summary>
        public string LiveAnchorMonthlyTargetId { get; set; }
        /// <summary>
        /// 主播
        /// </summary>

        public string LiveAnchor { get; set; }
        /// <summary>
        /// 运营人员id
        /// </summary>

        public int OperationEmpId { get; set; }
        /// <summary>
        /// 运营人员名称
        /// </summary>

        public string OperationEmpName { get; set; }
        /// <summary>
        /// 今日投流费用
        /// </summary>

        public decimal FlowInvestmentNum { get; set; }
        /// <summary>
        /// 今日发布量
        /// </summary>

        public int SendNum { get; set; }
        /// <summary>
        /// 今日橱窗收入
        /// </summary>
        public decimal TikTokShowcaseIncome { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>

        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 成交人数
        /// </summary>
        public int DealNum { get; set; }
        /// <summary>
        /// 今日业绩
        /// </summary>

        public decimal PerformanceNum { get; set; }
        /// <summary>
        /// 今日涨粉
        /// </summary>
        public int IncreaseFans { get; set; }
        /// <summary>
        /// 今日涨粉费用
        /// </summary>
        public decimal IncreaseFansFees { get; set; }
        /// <summary>
        /// 今日线索量
        /// </summary>
        public int Clues { get; set; }
        /// <summary>
        /// 橱窗付费
        /// </summary>
        public decimal ShowCaseFee { get; set; }

    }
}
