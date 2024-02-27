using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class QueryAfterLivingBusinessDataDto
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
        /// 基础主播id(不传为查总体)
        /// </summary>
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 是否是自播达人
        /// </summary>
        public bool? IsSelfLiveanchor { get; set; }
    }
}
