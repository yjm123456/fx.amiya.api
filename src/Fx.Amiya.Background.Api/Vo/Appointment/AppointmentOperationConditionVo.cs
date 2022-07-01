using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Appointment
{
    /// <summary>
    /// 预约经营情况
    /// </summary>
    public class AppointmentOperationConditionVo
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 预约量
        /// </summary>
        public int AppointmentNum { get; set; }
    }
}
