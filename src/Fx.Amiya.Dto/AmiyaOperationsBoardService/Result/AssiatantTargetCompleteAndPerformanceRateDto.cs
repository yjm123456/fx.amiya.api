using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AssiatantTargetCompleteAndPerformanceRateDto
    {
        /// <summary>
        /// 目标完成率数据
        /// </summary>
        public List<BaseKeyValueDto<string, decimal>> TargetCompleteData { get; set; } = new List<BaseKeyValueDto<string, decimal>>();
        /// <summary>
        /// 业绩占比数据
        /// </summary>
        public List<BaseKeyValueDto<string, decimal>> PerformanceRateData { get; set; } = new List<BaseKeyValueDto<string, decimal>>();
    }

}
