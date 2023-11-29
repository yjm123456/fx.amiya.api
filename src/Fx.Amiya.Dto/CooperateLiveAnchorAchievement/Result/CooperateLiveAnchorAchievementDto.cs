using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CooperateLiveAnchorAchievement
{
    public class CooperateLiveAnchorAchievementDto
    {
        /// <summary>
        /// 合作达人
        /// </summary>
        public string LiveanchorName { get; set; }

        /// <summary>
        /// 合作达人基础id
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal Performance { get; set; }
        /// <summary>
        /// 当日总业绩
        /// </summary>
        public decimal TodayPerformance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 当日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceRatio
        {
            get
            {
                if (Performance == 0m || NewCustomerPerformance == 0M)
                    return 0;
                return Math.Round(NewCustomerPerformance / Performance * 100, 2);
            }
        }

        /// <summary>
        /// 当日新客业绩占比
        /// </summary>
        public decimal TodayNewCustomerPerformanceRatio
        {
            get
            {
                if (TodayPerformance == 0m || TodayNewCustomerPerformance == 0M)
                    return 0;
                return Math.Round(TodayNewCustomerPerformance / TodayPerformance * 100, 2);
            }
        }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 当日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceRatio
        {
            get
            {
                if (Performance == 0m || OldCustomerPerformance == 0M)
                    return 0;
                return Math.Round(OldCustomerPerformance / Performance * 100, 2);
            }
        }
        /// <summary>
        /// 当日老客业绩占比
        /// </summary>
        public decimal TodayOldCustomerPerformanceRatio
        {
            get
            {
                if (TodayPerformance == 0m || TodayOldCustomerPerformance == 0M)
                    return 0;
                return Math.Round(TodayOldCustomerPerformance / TodayPerformance * 100, 2);
            }
        }
    }
}
