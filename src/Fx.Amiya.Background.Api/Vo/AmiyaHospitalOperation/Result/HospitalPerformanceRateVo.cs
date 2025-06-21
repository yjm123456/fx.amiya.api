using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaHospitalOperation.Result
{
    public class HospitalPerformanceRateVo
    {
        /// <summary>
        /// 业绩占比数据
        /// </summary>
        public List<BaseIdAndNameVo<string, decimal>> PerformanceRateData { get; set; }
    }
}
