using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerAppointmentSchedule.Input
{
    /// <summary>
    /// 批量指派
    /// </summary>
    public class AssignLiveAnchorListVo {
        public List<string> IdList { get; set; }
        /// <summary>
        /// 指派主播
        /// </summary>
        public string AssignBy { get; set; }
    }
    /// <summary>
    /// 指派
    /// </summary>
    public class AssignLiveAnchorVo
    {
        public string Id { get; set; }

        /// <summary>
        /// 指派主播
        /// </summary>
        public string AssignBy { get; set; }
    }
}
