using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.Performance
{
    /// <summary>
    /// 机构业绩
    /// </summary>
    public class HospitalPerformanceVo
    {
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
        /// 业绩贡献值
        /// </summary>
        public decimal? TotalAchievementRatio { get; set; }

        /// <summary>
        /// 新老客占比
        /// </summary>
        public string NewOrOldCustomerRate { get; set; }

    }
}
