using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPartakeItem.Input
{
    public class QueryexportItemListByHospitalIdVo
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int? ActivityId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int? HospitalId { get; set; }
    }
}
