using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TrackTypeThemeModel
{
    public class TrackTypeThemeModelDto
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

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
