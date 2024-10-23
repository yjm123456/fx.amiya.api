using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.AmiyaOperationsBoard.Result
{
    public class BeforeLiveLiveanchorIPDataVo
    {
        /// <summary>
        /// 主播ip
        /// </summary>
        public string LiveanchorIP { get; set; }
        /// <summary>
        /// 累计线索
        /// </summary>
        public int ClueCount { get; set; }
        /// <summary>
        /// 去年同比
        /// </summary>
        public decimal YearOnYear { get; set; }
        /// <summary>
        /// 上月环比
        /// </summary>
        public decimal Chain { get; set; }
        /// <summary>
        /// 目标完成率
        /// </summary>
        public decimal TargetComplete { get; set; }
    }
}
