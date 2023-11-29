using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.CooperateLiveAnchorAchievement.Result
{
    public class CooperateLiveAnchorHospitalAchievementVo
    {
        /// <summary>
        /// 排名
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string HospitalName { get; set; }
        /// <summary>
        /// 到院id
        /// </summary>
        public int? HospitalId { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 今日总业绩
        /// </summary>
        public decimal TodayTotalPerformance { get; set; }
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 今日新客业绩
        /// </summary>
        public decimal TodayNewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal TodayOldCustomerPerformance { get; set; }
        /// <summary>
        /// 业绩占比
        /// </summary>
        public decimal PerformanceRatio { get; set; }
        /// <summary>
        /// 今日业绩占比
        /// </summary>
        public decimal TodayPerformanceRatio { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 今日新客业绩占比
        /// </summary>
        public decimal TodayNewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 今日老客业绩占比
        /// </summary>
        public decimal TodayOldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 医院logo
        /// </summary>
        public string Logo { get; set; }
    }
}
