using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
  
    public class AssistantEffOrPotDistributeConsulationDto
    {
        /// <summary>
        /// 有效客资
        /// </summary>
        public EffOrPotDistributeConsulationItemDto EffctiveData { get; set; }
        /// <summary>
        /// 潜在客资
        /// </summary>
        public EffOrPotDistributeConsulationItemDto PotentialData { get; set; }
        /// <summary>
        /// 总客资
        /// </summary>
        public EffOrPotDistributeConsulationItemDto TotalData { get; set; }
    }
    public class EffOrPotDistributeConsulationItemDto
    {
        /// <summary>
        /// 当日
        /// </summary>
        public int CurrentDay { get; set; }
        /// <summary>
        /// 累计
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 同比
        /// </summary>
        public decimal YearOnYear { get; set; }
        /// <summary>
        /// 环比
        /// </summary>
        public decimal ChainRate { get; set; }
    }
}
