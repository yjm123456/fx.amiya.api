using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    
    public class AssiatantTargetCompleteAndPerformanceRateVo
    {
        /// <summary>
        /// 目标完成率数据
        /// </summary>
        public List<BaseIdAndNameVo<string, decimal>> TargetCompleteData { get; set; }
        /// <summary>
        /// 业绩占比数据
        /// </summary>
        public List<BaseIdAndNameVo<string, decimal>> PerformanceRateData { get; set; }
    }
}
