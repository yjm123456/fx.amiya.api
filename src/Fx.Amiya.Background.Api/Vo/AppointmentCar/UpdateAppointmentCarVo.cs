using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AppointmentCar
{
    public class UpdateAppointmentCarVo
    {
        public string Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 预约时间
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// 预约地点
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string Hospital { get; set; }
    }
}
