using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Input
{
    /// <summary>
    /// 查询业绩输入类
    /// </summary>
    public class QueryAmiyaAchievementDataVo
    {
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 主播基础id（不传查询所有业绩）
        /// </summary>
        public string LiveAnchorBaseId { get; set; }
        /// <summary>
        /// 是否为自播主播
        /// </summary>
        public bool IsSelfLKiveAnchor { get; set; }
    }
}
