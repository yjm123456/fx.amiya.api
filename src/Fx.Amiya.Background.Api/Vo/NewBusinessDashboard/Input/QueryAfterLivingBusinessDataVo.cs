using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard.Input
{
    public class QueryAfterLivingBusinessDataVo
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
        /// 是否是自播达人(查公司数据传空,查供应链达人传false,公司主播传true)
        /// </summary>
        public bool? IsSelfLiveanchor { get; set; }

    }
}
