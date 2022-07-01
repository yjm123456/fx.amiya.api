using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Appointment
{
    public class AppointmentSurplusQuantityVo
    {
        /// <summary>
        /// 上午还剩预约数量
        /// </summary>
        public int AmSurplusQuantity { get; set; }

        /// <summary>
        /// 下午还剩预约数量
        /// </summary>
        public int PmSurplusQuantity { get; set; }
    }
}
