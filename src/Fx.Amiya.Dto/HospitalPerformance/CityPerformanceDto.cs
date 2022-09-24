using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalPerformance
{
    /// <summary>
    /// 全国城市top10累计运营数据
    /// </summary>
    public class CityAccumulatePerformanceDto
    {
        /// <summary>
        /// 总业绩占比
        /// </summary>
        public CityPerformanceItem TotalPerformnaceRatio { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public CityPerformanceItem NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public CityPerformanceItem OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 派单量占比
        /// </summary>
        public CityPerformanceItem SendOrderPerformanceRatio { get; set; }
        /// <summary>
        /// 新客上门人数占比
        /// </summary>
        public CityPerformanceItem NewCustomerToHospitalPerformanceRatio { get; set; }
        /// <summary>
        /// 新客成交人数占比
        /// </summary>
        public CityPerformanceItem NewCustomerDealCountRatio { get; set; }

    }
    public class CityPerformanceItem
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformmance { get; set; }

        public List<CityPerformanceListItem> PerformanceList { get; set; }

    }
    public class CityPerformanceListItem
    {
        /// <summary>
        /// 机构业绩
        /// </summary>
        public decimal? Performance { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string CityName { get; set; }
    }
}
