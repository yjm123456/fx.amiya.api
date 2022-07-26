using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 回访模板
    /// </summary>
    public class TrackTypeThemeModel
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
        /// 回访模板id
        /// </summary>
        public int TrackThemeId { get; set; }
        /// <summary>
        /// 时隔/日
        /// </summary>
        public int DaysLater { get; set; }
        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        public TrackType TrackType { get; set; }
        public TrackTheme TrackTheme { get; set; }
    }
}
