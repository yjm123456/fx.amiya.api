using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class PerformanceInfoDto
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformance { get; set; }
        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal? TotalPerformanceChainRatio { get; set; }
        /// <summary>
        /// 总业绩目标达成
        /// </summary>
        public decimal? TotalPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 新诊业绩
        /// </summary>
        public decimal? NewPerformance { get; set; }
        /// <summary>
        /// 新诊业绩同比
        /// </summary>
        public decimal? NewPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新诊业绩环比
        /// </summary>
        public decimal? NewPerformanceChainRatio { get; set; }
        /// <summary>
        /// 新诊业绩目标达成
        /// </summary>
        public decimal? NewPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal? OldPerformance { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal? OldPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 带货业绩
        /// </summary>
        public decimal? CommercePerformance { get; set; }
        /// <summary>
        /// 带货业绩同比
        /// </summary>
        public decimal? CommercePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 带货业绩环比
        /// </summary>
        public decimal? CommercePerformanceChainRatio { get; set; }
        /// <summary>
        /// 带货业绩目标达成
        /// </summary>
        public decimal? CommercePerformanceTargetComplete { get; set; }
        /// <summary>
        /// 新客业绩数据
        /// </summary>
        public List<PerformanceListInfo> newPerformanceList { get; set; }
        /// <summary>
        /// 老客业绩数据
        /// </summary>
        public List<PerformanceListInfo> oldPerformanceList { get; set; }
        /// <summary>
        /// 带货业绩数据
        /// </summary>
        public List<PerformanceListInfo> commercePerformanceList { get; set; }
        /// <summary>
        /// 各业绩占比
        /// </summary>
        public List<PerformanceRatioDto> PerformanceRatios { get; set; }
    }
}
