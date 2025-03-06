using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class AssistantEffOrPotDistributeConsulationVo
    {
        /// <summary>
        /// 当日直播前客资
        /// </summary>
        public int BeforeLivingCurrentDayData { get; set; }
        /// <summary>
        /// 累计直播前客资
        /// </summary>
        public int BeforeLivingTotalData { get; set; }
        /// <summary>
        /// 同比直播前客资
        /// </summary>
        public decimal BeforeLivingYearOnYearData { get; set; }
        /// <summary>
        /// 环比直播前客资
        /// </summary>
        public decimal BeforeLivingChainRateData { get; set; }


        /// <summary>
        /// 当日直播中客资
        /// </summary>
        public int LivingCurrentDayData { get; set; }
        /// <summary>
        /// 累计直播中客资
        /// </summary>
        public int LivingTotalData { get; set; }
        /// <summary>
        /// 同比直播中客资
        /// </summary>
        public decimal LivingYearOnYearData { get; set; }
        /// <summary>
        /// 环比直播中客资
        /// </summary>
        public decimal LivingChainRateData { get; set; }


        /// <summary>
        /// 当日直播中客资
        /// </summary>
        public int AfrerLivingCurrentDayData { get; set; }
        /// <summary>
        /// 累计直播中客资
        /// </summary>
        public int AfterLivingTotalData { get; set; }
        /// <summary>
        /// 同比直播中客资
        /// </summary>
        public decimal AfrerLivingYearOnYearData { get; set; }
        /// <summary>
        /// 环比直播中客资
        /// </summary>
        public decimal AfrerLivingChainRateData { get; set; }

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
