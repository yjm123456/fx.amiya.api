using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ContentPlateFormOrder.Input
{
    public class QueryOnlyMainHospitalOrderByPageVo:BaseQueryVo
    {
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
    }
}
