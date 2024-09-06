using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaOperationsBoardService.Result
{
    public class AssistantDistributeConsulationDto
    {
        /// <summary>
        /// 一类客资
        /// </summary>
        public DistributeConsulationItemDto FirstType { get; set; }
        /// <summary>
        /// 二类客资
        /// </summary>
        public DistributeConsulationItemDto SecondType { get; set; }
        /// <summary>
        /// 三类客资
        /// </summary>
        public DistributeConsulationItemDto ThirdType { get; set; }
        /// <summary>
        /// 总客资
        /// </summary>
        public DistributeConsulationItemDto TotalType { get; set; }
    }
    public class DistributeConsulationItemDto {
        /// <summary>
        /// 当日
        /// </summary>
        public int CurrentDay { get; set; }
        /// <summary>
        /// 累计
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 环比
        /// </summary>
        public decimal YearOnYear { get; set; }
        /// <summary>
        /// 同比
        /// </summary>
        public decimal ChainRate { get; set; }
    }
}
