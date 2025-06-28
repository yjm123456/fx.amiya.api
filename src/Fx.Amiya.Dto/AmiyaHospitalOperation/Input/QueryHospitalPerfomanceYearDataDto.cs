using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Input
{
    public class QueryHospitalPerfomanceYearDataDto
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
