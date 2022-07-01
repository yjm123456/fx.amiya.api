using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalAppointmentQuantity
{
    public class HospitalAppointmentQuantityVo
    {
        public int Id { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 上午可预约人数
        /// </summary>
        public int ForenoonCanAppointmentNumer { get; set; }

        /// <summary>
        /// 下午可预约人数
        /// </summary>
        public int AfternoonCanAppointmentNumer { get; set; }
    }
}
