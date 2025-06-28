using Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Result
{
    public class HospitalPerformanceYearDataListVo
    {


        /// <summary>
        /// 总业绩
        /// </summary>
        public List<PerformanceYearDataVo> TotalPerformanceData { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public List<PerformanceYearDataVo> NewCustomerPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public List<PerformanceYearDataVo> OldCustomerPerformanceData { get; set; }
    }
}
