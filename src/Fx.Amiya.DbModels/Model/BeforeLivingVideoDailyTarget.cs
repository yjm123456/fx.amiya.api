using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeforeLivingVideoDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 视频号涨粉
        /// </summary>

        public int VideoIncreaseFans { get; set; }
        /// <summary>
        /// 视频号涨粉付费
        /// </summary>
        public decimal VideoIncreaseFansFees { get; set; }
        /// <summary>
        /// 视频号涨粉成本
        /// </summary>
        public decimal VideoIncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 视频号线索量
        /// </summary>
        public int VideoClues { get; set; }
        /// <summary>
        /// 视频号今日橱窗收入
        /// </summary>
        public decimal VideoShowcaseIncome { get; set; }
        /// <summary>
        /// 视频号橱窗付费
        /// </summary>
        public decimal VideoShowCaseFee { get; set; }

        public LiveAnchorMonthlyTargetBeforeLiving LiveAnchorMonthlyTargetBeforeLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
