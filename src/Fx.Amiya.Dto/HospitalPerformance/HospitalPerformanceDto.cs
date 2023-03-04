using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.HospitalPerformance
{
    public class HospitalPerformanceDto
    {
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId { get; set; }
        /// <summary>
        /// 医院
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 医院图片
        /// </summary>
        public string HospitalLogo { get; set; }

        /// <summary>
        /// 派单量
        /// </summary>
        public int SendNum { get; set; }

        /// <summary>
        /// 上门数
        /// </summary>
        public int VisitNum { get; set; }

        /// <summary>
        /// 上门率
        /// </summary>
        public decimal VisitRate { get; set; }

        /// <summary>
        /// 新客成交（人数）
        /// </summary>
        public int NewCustomerDealNum { get; set; }

        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal NewCustomerDealRate { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerAchievement { get; set; }

        /// <summary>
        /// 新客客单价
        /// </summary>
        public decimal NewCustomerUnitPrice { get; set; }

        /// <summary>
        /// 老客成交（人数）
        /// </summary>
        public int OldCustomerDealNum { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerAchievement { get; set; }

        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal OldCustomerUnitPrice { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalAchievement { get; set; }

        /// <summary>
        /// 新老客占比
        /// </summary>
        public string NewOrOldCustomerRate { get; set; }
    }
    /// <summary>
    /// 全国机构top10累计运营数据
    /// </summary>
    public class HospitalAccumulatePerformanceDto
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
    public class HospitalPerformanceItem {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal? TotalPerformmance { get; set; }
        public List<HospitalPerformanceListItem> PerformanceList { get; set; }

    }
    public class HospitalPerformanceListItem {
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
