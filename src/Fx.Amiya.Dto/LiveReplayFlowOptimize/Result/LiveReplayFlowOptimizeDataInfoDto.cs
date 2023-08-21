using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveReplayFlowOptimize.Result
{
    public class LiveReplayFlowOptimizeDataInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 直播复盘表id
        /// </summary>
        public string LiveReplayId { get; set; }
        /// <summary>
        /// 流量来源
        /// </summary>
        public string FlowSource { get; set; }
        /// <summary>
        /// 所占比例
        /// </summary>
        public decimal Proportion { get; set; }
        /// <summary>
        /// 引流人数
        /// </summary>
        public int DrainageCount { get; set; }
        /// <summary>
        /// 上一场引流人数
        /// </summary>
        public int LastDrainageCount { get; set; }
        /// <summary>
        /// 上一场占比对比
        /// </summary>
        public decimal LastDrainageProportion { get; set; }
        /// <summary>
        /// 问题分析
        /// </summary>
        public string ProblemAnalysis { get; set; }
        /// <summary>
        /// 后续解决方案
        /// </summary>
        public string LaterSolution { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
