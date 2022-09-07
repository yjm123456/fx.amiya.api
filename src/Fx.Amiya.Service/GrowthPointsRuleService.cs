using Fx.Amiya.Dto.GrowthPoints;
using Fx.Amiya.IDal;
using Fx.Amiya.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Service
{
    public class GrowthPointsRuleService : IGrowthPointsRuleService
    {
        private readonly IDalGrowthPointsRule dalGrowthPointsRule;

        public GrowthPointsRuleService(IDalGrowthPointsRule dalGrowthPointsRule)
        {
            this.dalGrowthPointsRule = dalGrowthPointsRule;
        }
        /// <summary>
        /// 获取任务信息
        /// </summary>
        /// <param name="taskCode">任务编码</param>
        /// <returns></returns>
        public async Task<GrowthPointsRuleDto> GetTaskRuleByTaskCodeAsync(string taskCode)
        {
            return dalGrowthPointsRule.GetAll().Where(e=>e.TaskCode==taskCode).Select(e=>new GrowthPointsRuleDto { 
                Id=e.Id,
                TaskCode=e.TaskCode,
                Name=e.Name,
                RewardQuantity=e.RewardQuantity,
                Type=e.Type,
                RewardQuantityPercent=e.RewardQuantityPercent
            }).SingleOrDefault();
        }
    }
}
