using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Input
{
    public class QueryHospitalPerfomanceYearDataVo
    {
        /// <summary>
        /// 年份
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 机构id
        /// </summary>
        public int HospitalId { get; set; }
    }
}
