using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class UpdateSendOrderHospitalDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderId { get; set; }
        public int HospitalId { get; set; }
    }
}
