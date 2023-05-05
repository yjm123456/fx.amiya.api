using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.CustomerAppointmentSchedule.Input
{
    public class QueryLiveAnchorToHospitalLiveAnchorVo
    {
        /// <summary>
        /// 主播id
        /// </summary>
        public string LiveAnchorId { get; set; }
        /// <summary>
        /// 预约类型(1:视频设计预约,2:到院接诊预约)
        /// </summary>
        public int AppointmentType { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }

    }
}
