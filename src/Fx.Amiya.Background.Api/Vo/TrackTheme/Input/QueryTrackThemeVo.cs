using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.TrackTheme.Input
{
    public class QueryTrackThemeVo:BaseQueryVo
    {
        /// <summary>
        /// 回访类型
        /// </summary>
        public int? TrackTypeId { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool? Valid { get; set; }
    }
}
