using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BeforeLivingXiaoHongShuDailyTarget : BaseDbModel
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public int OperationEmpId { get; set; }

        public decimal FlowInvestmentNum { get; set; }

        public int SendNum { get; set; }

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 小红书涨粉
        /// </summary>

        public int XiaoHongShuIncreaseFans { get; set; }
        /// <summary>
        /// 小红书涨粉付费
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFees { get; set; }
        /// <summary>
        /// 小红书涨粉成本
        /// </summary>
        public decimal XiaoHongShuIncreaseFansFeesCost { get; set; }
        /// <summary>
        /// 小红书线索量
        /// </summary>
        public int XiaoHongShuClues { get; set; }
        /// <summary>
        /// 小红书今日橱窗收入
        /// </summary>
        public decimal XiaoHongShuShowcaseIncome { get; set; }
        /// <summary>
        /// 小红书橱窗付费
        /// </summary>
        public decimal XiaoHongShuShowCaseFee { get; set; }

        public LiveAnchorMonthlyTargetBeforeLiving LiveAnchorMonthlyTargetBeforeLiving { get; set; }

        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
