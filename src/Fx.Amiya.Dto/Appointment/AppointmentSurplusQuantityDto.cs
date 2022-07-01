using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Appointment
{
   public class AppointmentSurplusQuantityDto
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
