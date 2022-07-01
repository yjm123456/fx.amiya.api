using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Track
{
    public class AddWaitTrackCustomerVo
    {

        /// <summary>
        /// 待回访日期
        /// </summary>
        public DateTime PlanTrackDate { get; set; }


        public int? TrackTypeId { get; set; }
        public int? TrackThemeId { get; set; }

        /// <summary>
        /// 回访计划
        /// </summary>
        public string TrackPlan { get; set; }

        /// <summary>
        /// 其他客服下次回访
        /// </summary>
        public int? OtherTrackEmployeeId { get; set; }

    }
}
