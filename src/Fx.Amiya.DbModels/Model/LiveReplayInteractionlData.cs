using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 直播复盘-互动数据
    /// </summary>
    public class LiveReplayInteractionlData : BaseDbModel
    {
        /// <summary>
        /// 复盘主表id
        /// </summary>
        public string LiveReplayId { get; set; }
        /// <summary>
        /// 复盘指标
        /// </summary>
        public string ReplayTarget { get; set; }
        /// <summary>
        /// 数据指标
        /// </summary>
        public decimal DataTarget { get; set; }
        /// <summary>
        /// 同比数据
        /// </summary>
        public decimal LastLivingData { get; set; }
        /// <summary>
        /// 同比增长
        /// </summary>
        public decimal LastLivingCompare { get; set; }
        /// <summary>
        /// 问题分析
        /// </summary>
        public string QuestionAnalize { get; set; }
        /// <summary>
        /// 后续解决方案
        /// </summary>
        public string LaterPeriodSolution { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 直播复盘主表
        /// </summary>
        public LiveReplay LiveReplay { get; set; }
    }
}
