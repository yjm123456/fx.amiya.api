using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalDealItem:BaseDbModel
    {
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }

        /// <summary>
        /// 归属指标id
        /// </summary>
        public string IndicatorId { get; set; }
        /// <summary>
        /// 成交品项名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 成交数量
        /// </summary>
        public int? DealCount { get; set; }
        /// <summary>
        /// 执行单价
        /// </summary>
        public decimal? DealUnitPrice { get; set; }
        /// <summary>
        /// 成交金额
        /// </summary>
        public decimal? DealPrice { get; set; }
        /// <summary>
        /// 业绩占比
        /// </summary>
        public decimal? PerformanceRatio { get; set; }
        public HospitalInfo HospitalInfo { get; set; }

        public HospitalOperationalIndicator HospitalOperationalIndicator { get; set; }

    }
}
