using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Performance
{
    /// <summary>
    /// 啊美雅业绩看板
    /// </summary>
    public class PerformanceVo
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
        /// 总业绩目标达成度
        /// </summary>
        public decimal? TotalPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 新诊业绩
        /// </summary>
        public decimal? NewPerformance{ get; set; }
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
        /// 各业绩所占比例
        /// </summary>
        public List<PerformanceRatioVo> PerformanceRatios { get; set; }

        /// <summary>
        /// 新客业绩数据
        /// </summary>
        public List<PerformanceListInfo> NewPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩数据
        /// </summary>
        public List<PerformanceListInfo> OldPerformanceData { get; set; }
        /// <summary>
        /// 带货业绩数据
        /// </summary>
        public List<PerformanceListInfo> CommercePerformanceData { get; set; }

    }
    /// <summary>
    /// 月业绩数
    /// </summary>
    public class PerformanceListInfo {
        //日期
        public string date { get; set; }
        //业绩金额
        public decimal? Performance { get; set; }
    }
    /// <summary>
    /// 业绩占比详情
    /// </summary>
    public class PerformanceRatioVo {
        /// <summary>
        /// 业绩名称
        /// </summary>
        public string PerformanceText { get; set; }
        /// <summary>
        /// 业绩金额
        /// </summary>
        public decimal? PerformancePrice { get; set; }
        /// <summary>
        /// 业绩所占比例
        /// </summary>
        public decimal? PerformanceRatio { get; set; }
    }
}
