using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CooperateLiveAnchorAchievement.Result
{
    public class CooperateLiveAnchorAchievementVo
    {
        /// <summary>
        /// 合作达人
        /// </summary>
        public string LiveanchorName { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal Performance { get; set; }
        /// <summary>
        /// 今日总业绩
        /// </summary>
        public decimal TodayPerformance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 今日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 今日新客业绩占比
        /// </summary>
        public decimal TodayNewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 今日老客业绩占比
        /// </summary>
        public decimal TodayOldCustomerPerformanceRatio { get; set; }
    }
}
