using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalIndex
{
    public class HospitalDataVo
    {
        /// <summary>
        /// 本月派单量
        /// </summary>
        public int ThisMonthSendOrderCount { get; set; }
        /// <summary>
        /// 派单量上月环比
        /// </summary>
        public decimal SendOrderCountChainRatio { get; set; }
        /// <summary>
        /// 本月成交量
        /// </summary>
        public int ThisMonthDealCount { get; set; }
        /// <summary>
        /// 成交量上月环比
        /// </summary>
        public decimal DealCountChainRatio { get; set; }
        /// <summary>
        /// 全年派单量
        /// </summary>
        public int YearSendOrderCount { get; set; }
        /// <summary>
        /// 总派单量
        /// </summary>
        public int TotalSendOrderCount { get; set; }
        /// <summary>
        /// 全年成交量
        /// </summary>
        public int YearDealCount { get; set; }
        /// <summary>
        /// 总成交量
        /// </summary>
        public int TotalDealCount { get; set; }
        /// <summary>
        /// 本月派单成交量
        /// </summary>
        public decimal ThisMonthSendOrderDealRatio { get; set; }
        /// <summary>
        /// 全年派单成交量
        /// </summary>
        public decimal YearSendOrderDealRatio { get; set; }
    }
}
