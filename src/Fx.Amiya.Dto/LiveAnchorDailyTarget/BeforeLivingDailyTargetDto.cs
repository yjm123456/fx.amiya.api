using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class BeforeLivingDailyTargetDto : BaseDto
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public string LiveAnchor { get; set; }

        public int OperationEmpId { get; set; }

        public string OperationEmpName { get; set; }

        public decimal FlowInvestmentNum { get; set; }
        /// <summary>
        /// 知乎投流费用目标
        /// </summary>
        public decimal FlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计知乎投流费用
        /// </summary>

        public decimal CumulativeFlowinvestment { get; set; }
        /// <summary>
        /// 知乎投流费用完成率
        /// </summary>
        public string FlowinvestmentCompleteRate { get; set; }

        public int SendNum { get; set; }


        /// <summary>
        /// 月知乎发布目标
        /// </summary>
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 月累计知乎发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }

        /// <summary>
        /// 知乎发布目标完成率
        /// </summary>
        public string ReleaseCompleteRate { get; set; }

        public DateTime RecordDate { get; set; }
    }
}
