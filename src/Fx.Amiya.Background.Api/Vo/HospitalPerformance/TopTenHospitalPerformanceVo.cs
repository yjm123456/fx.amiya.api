using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.HospitalPerformance
{
    /// <summary>
    /// 全国机构top10累计运营数据
    /// </summary>
    public class TopTenHospitalPerformanceVo
    {
        /// <summary>
        /// 总业绩占比
        /// </summary>
        public HospitalPerformanceItem TotalPerformnaceRatio { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public HospitalPerformanceItem NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public HospitalPerformanceItem OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 派单量占比
        /// </summary>
        public HospitalPerformanceItem SendOrderPerformanceRatio { get; set; }
        /// <summary>
        /// 新客上门人数占比
        /// </summary>
        public HospitalPerformanceItem NewCustomerToHospitalPerformanceRatio { get; set; }
        /// <summary>
        /// 新客成交人数占比
        /// </summary>
        public HospitalPerformanceItem NewCustomerDealCountRatio { get; set; }

    }
    public class HospitalPerformanceItem
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformmance { get; set; }
        public List<HospitalPerformanceListItem> PerformanceList { get; set; }

    }
    public class HospitalPerformanceListItem
    {
        /// <summary>
        /// 机构业绩
        /// </summary>
        public decimal? Performance { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string HospitalName { get; set; }
    }
}
