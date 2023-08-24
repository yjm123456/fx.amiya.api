using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveReplayInteractionlData.Result
{
    public class LiveReplayInteractionlDataVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
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
    }

    /// <summary>
    /// 成交量自动填写相关参数
    /// </summary>
    public class AutoWriteInteractionlDataVo
    {
        /// <summary>
        /// 同比数据获取
        /// </summary>
        public List<LiveReplayInteractionlDataVo> LiveReplayInfoInteractionlDataVoList{ get;set;}
    }
}
