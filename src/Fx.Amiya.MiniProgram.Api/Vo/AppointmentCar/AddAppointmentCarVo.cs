using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.AppointmentCar
{
    public class AddAppointmentCarVo
    {
        public string Name { get; set; }
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
        /// 预约医院
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// 预约车型
        /// </summary>
        public int CarType { get; set; }
        
        /// <summary>
        /// 抵扣类型
        /// </summary>
        public int ExchageType { get; set; }
    }
}
