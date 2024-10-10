using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantEffOrPotDistributeConsulationVo
    {
        /// <summary>
        /// 当日有效客资
        /// </summary>
        public int EffctiveCurrentDayData { get; set; }
        /// <summary>
        /// 累计有效客资
        /// </summary>
        public int EffctiveTotalData { get; set; }
        /// <summary>
        /// 同比有效客资
        /// </summary>
        public decimal EffctiveYearOnYearData { get; set; }
        /// <summary>
        /// 环比有效客资
        /// </summary>
        public decimal EffctiveChainRateData { get; set; }


        /// <summary>
        /// 当日潜在客资
        /// </summary>
        public int PotentialCurrentDayData { get; set; }
        /// <summary>
        /// 累计潜在客资
        /// </summary>
        public int PotentialTotalData { get; set; }
        /// <summary>
        /// 同比潜在客资
        /// </summary>
        public decimal PotentialYearOnYearData { get; set; }
        /// <summary>
        /// 环比潜在客资
        /// </summary>
        public decimal PotentialChainRateData { get; set; }


        /// <summary>
        /// 当日总客资
        /// </summary>
        public int TotalCurrentDayData { get; set; }
        /// <summary>
        /// 累计总客资
        /// </summary>
        public int TotalTotalData { get; set; }
        /// <summary>
        /// 同比总客资
        /// </summary>
        public decimal TotalYearOnYearData { get; set; }
        /// <summary>
        /// 环比总客资
        /// </summary>
        public decimal TotalChainRateData { get; set; }
    }
}
