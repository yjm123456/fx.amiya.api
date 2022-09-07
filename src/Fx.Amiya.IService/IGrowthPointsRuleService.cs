using Fx.Amiya.Dto.GrowthPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.IService
{
    public interface IGrowthPointsRuleService
    {
        /// <summary>
        /// 获取任务信息
        /// </summary>
        /// <param name="taskCode">任务编码</param>
        /// <returns></returns>
        Task<GrowthPointsRuleDto> GetTaskRuleByTaskCodeAsync(string taskCode);
    }
}
