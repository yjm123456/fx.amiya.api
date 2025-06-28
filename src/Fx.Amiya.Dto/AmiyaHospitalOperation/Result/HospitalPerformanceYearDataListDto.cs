using Fx.Amiya.Dto.AmiyaOperationsBoardService.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalPerformanceYearDataListDto
    {

        /// <summary>
        /// 总业绩
        /// </summary>
        public List<PerformanceYearDataDto> TotalPerformanceData { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<PerformanceYearDataDto> NewCustomerPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<PerformanceYearDataDto> OldCustomerPerformanceData { get; set; }
    }
}
