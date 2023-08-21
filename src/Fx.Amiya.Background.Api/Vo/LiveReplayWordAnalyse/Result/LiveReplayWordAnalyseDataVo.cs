using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplayWordAnalyse.Result
{
    public class LiveReplayWordAnalyseDataVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 复盘表id
        /// </summary>
        public string LiveReplayId { get; set; }
        /// <summary>
        /// 复盘内容
        /// </summary>
        public string ReplayContent { get; set; }
        /// <summary>
        /// 话术表现
        /// </summary>
        public string WordManifestation { get; set; }
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
