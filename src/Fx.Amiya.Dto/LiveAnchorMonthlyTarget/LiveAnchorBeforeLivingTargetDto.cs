using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class LiveAnchorBeforeLivingTargetDto
    {
        /// <summary>
        /// 涨粉目标
        /// </summary>
        public int IncreaseFansTarget { get; set; }
        /// <summary>
        /// 涨粉付费目标
        /// </summary>
        public decimal IncreaseFansFeesTarget { get; set; }
        /// <summary>
        /// 涨粉成本目标
        /// </summary>
        public decimal IncreaseFansFeesCostTarget
        {
            get
            {
                return Math.Round(IncreaseFansTarget / IncreaseFansFeesTarget, 2);

            }
        }
        /// <summary>
        /// 橱窗收入目标
        /// </summary>
        public decimal ShowcaseIncomeTarget { get; set; }
        /// <summary>
        /// 橱窗付费目标
        /// </summary>
        public decimal ShowcaseFeeTarget { get; set; }
        /// <summary>
        /// 线索量目标
        /// </summary>
        public int CluesTarget { get; set; }
        /// <summary>
        /// 发布量目标
        /// </summary>
        public int SendNumTarget { get; set; }
        
    }
}
