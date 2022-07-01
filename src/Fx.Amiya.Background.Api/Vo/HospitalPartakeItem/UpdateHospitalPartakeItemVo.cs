using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPartakeItem
{
    public class UpdateHospitalPartakeItemVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 上午可预约人数
        /// </summary>
        public int ForenoonCanAppointmentQuantity { get; set; }

        /// <summary>
        /// 下午可预约人数
        /// </summary>
        public int AfternoonCanAppointmentQuantity { get; set; }
    }
}
