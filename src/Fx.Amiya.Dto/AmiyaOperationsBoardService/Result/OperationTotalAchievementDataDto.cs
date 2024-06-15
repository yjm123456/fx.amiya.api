using Fx.Amiya.Dto.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService
{
    public class OperationTotalAchievementDataDto
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 当日总业绩
        /// </summary>
        public decimal TodayTotalPerformance { get; set; }

        /// <summary>
        /// 总业绩目标完成率
        /// </summary>
        public decimal? TotalPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal? TotalPerformanceChainRatio { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 当日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }


        /// <summary>
        /// 新客业绩目标完成率
        /// </summary>
        public decimal? NewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal? NewCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal? NewCustomerPerformanceChainRatio { get; set; }


        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 当日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }


        /// <summary>
        /// 老客业绩目标完成率
        /// </summary>
        public decimal? OldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> TotalPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoDto> OldCustomerPerformanceBrokenLineList { get; set; }
    }
    public class OerationTotalAchievementBrokenLineListDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// 总业绩折线图
        /// </summary>
        public decimal TotalCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
    }
}
