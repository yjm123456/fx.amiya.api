using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaHospitalOperation.Result
{
    public class HospitalPerformanceRateDto
    {
        /// <summary>
        /// 业绩占比数据
        /// </summary>
        public List<BaseKeyValueDto<string, decimal>> PerformanceRateData { get; set; } = new List<BaseKeyValueDto<string, decimal>>();
    }
}
