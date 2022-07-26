using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    /// <summary>
    /// 回访模板
    /// </summary>
    public class TrackTypeThemeModelVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 回访类型id
        /// </summary>
        public int TrackTypeId { get; set; }

        /// <summary>
        /// 回访类型名称
        /// </summary>
        public string TrackTypeName { get; set; }
        /// <summary>
        /// 回访主题id
        /// </summary>
        public int TrackThemeId { get; set; }
        /// <summary>
        /// 回访主题名称
        /// </summary>
        public string TrackThemeName { get; set; }
        /// <summary>
        /// 时隔/日
        /// </summary>
        public int DaysLater { get; set; }
        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }
    }
}
