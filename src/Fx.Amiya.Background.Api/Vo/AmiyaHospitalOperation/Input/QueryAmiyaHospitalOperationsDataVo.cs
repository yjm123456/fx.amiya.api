using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Input
{
    public class QueryAmiyaHospitalOperationsDataVo
    {

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 机构id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 是否为当月
        /// </summary>
        public bool IsCurrent { get; set; }
    }
}
