using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalDealGoodsOperation
{
    public class UpdateHospitalDealItemOperationDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 成交品项名称
        /// </summary>
        public string DealItemName { get; set; }
        /// <summary>
        /// 成交数量
        /// </summary>
        public int DealCount { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal DealPrice { get; set; }
        /// <summary>
        /// 业绩占比
        /// </summary>
        public decimal PerformanceRatio { get; set; }
    }
}
