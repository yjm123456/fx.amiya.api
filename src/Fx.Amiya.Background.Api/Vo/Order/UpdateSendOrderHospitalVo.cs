using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class UpdateSendOrderHospitalVo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderId { get; set; }
        public int HospitalId { get; set; }
    }
}
