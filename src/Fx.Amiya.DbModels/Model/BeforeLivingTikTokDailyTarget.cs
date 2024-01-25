using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeforeLivingTikTokDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 今日抖音橱窗收入
        /// </summary>
        public decimal TikTokShowcaseIncome { get; set; }
        /// <summary>
        /// 抖音涨粉
        /// </summary>

        public int TikTokIncreaseFans { get; set; }
        /// <summary>
        /// 抖音涨粉付费
        /// </summary>
        public decimal TikTokIncreaseFansFees { get; set; }
      
        /// <summary>
        /// 抖音橱窗付费
        /// </summary>
        public decimal TikTokShowCaseFee { get; set; }
        /// <summary>
        /// 抖音线索量
        /// </summary>
        public int TikTokClues { get; set; }

        public LiveAnchorMonthlyTargetBeforeLiving LiveAnchorMonthlyTargetBeforeLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
