using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveTargetCompleteAndPerformanceRateVo
    {
        /// <summary>
        /// 业绩贡献占比
        /// </summary>
        public List<KeyValuePair<string, decimal>> PerformanceRate { get; set; }
    }
}
