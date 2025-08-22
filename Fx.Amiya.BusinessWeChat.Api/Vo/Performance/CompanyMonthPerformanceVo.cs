using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.BusinessWeChat.Api.Vo.Performance
{
    /// <summary>
    /// 公司总业绩
    /// </summary>
    public class CompanyMonthPerformanceVo
    {
        /// <summary>
        /// 时间进度
        /// </summary>
        public decimal TimeSchedule { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }

        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }

        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal? TotalPerformanceChainRatio { get; set; }

        #region【饼状图占比】

        /// <summary>
        /// 自播达人业绩占比
        /// </summary>
        public decimal? SelfLiveAnchorPerformanceRatio { get; set; }

        /// <summary>
        /// 合作达人业绩占比
        /// </summary>
        public decimal? OtherLiveAnchorPerformanceRatio { get; set; }
        /// <summary>
        /// 带货业绩占比
        /// </summary>
        public decimal? CommercePerformanceRatio { get; set; }

        /// <summary>
        /// 医生业绩占比
        /// </summary>
        public decimal? DoctorPerformanceRatio { get; set; }
        /// <summary>
        /// 其他业绩占比
        /// </summary>
        public decimal? OtherPerformanceRatio { get; set; }

        #endregion

        #region【自播达人】


        /// <summary>
        /// 自播达人新客业绩
        /// </summary>
        public decimal SelfLiveAnchorNewCustomerPerformance { get; set; }

        /// <summary>
        /// 自播达人新客业绩目标完成率
        /// </summary>
        public decimal? SelfLiveAnchorNewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 自播达人新客业绩同比
        /// </summary>
        public decimal? SelfLiveAnchorNewCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 自播达人新客业绩环比
        /// </summary>
        public decimal? SelfLiveAnchorNewCustomerPerformanceChainRatio { get; set; }


        /// <summary>
        /// 自播达人老客业绩
        /// </summary>
        public decimal SelfLiveAnchorOldCustomerPerformance { get; set; }


        /// <summary>
        /// 自播达人老客业绩目标完成率
        /// </summary>
        public decimal? SelfLiveAnchorOldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 自播达人老客业绩同比
        /// </summary>
        public decimal? SelfLiveAnchorOldCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 自播达人老客业绩环比
        /// </summary>
        public decimal? SelfLiveAnchorOldCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 自播达人总业绩
        /// </summary>
        public decimal SelfLiveAnchorPerformance { get; set; }

        /// <summary>
        /// 自播达人总业绩目标值
        /// </summary>
        public decimal SelfLiveAnchorPerformanceTarget { get; set; }

        /// <summary>
        /// 自播达人总业绩目标完成率
        /// </summary>
        public decimal? SelfLiveAnchorPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 自播达人总业绩同比
        /// </summary>
        public decimal? SelfLiveAnchorPerformanceYearToYear { get; set; }

        /// <summary>
        /// 自播达人总业绩环比
        /// </summary>
        public decimal? SelfLiveAnchorPerformanceChainRatio { get; set; }
        #endregion

        #region【合作达人】
        /// <summary>
        /// 合作达人新客业绩
        /// </summary>
        public decimal OtherLiveAnchorNewCustomerPerformance { get; set; }


        /// <summary>
        /// 合作达人新客业绩目标完成率
        /// </summary>
        public decimal? OtherLiveAnchorNewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 合作达人新客业绩同比
        /// </summary>
        public decimal? OtherLiveAnchorNewCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 合作达人新客业绩环比
        /// </summary>
        public decimal? OtherLiveAnchorNewCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 合作达人老客业绩
        /// </summary>
        public decimal OtherLiveAnchorOldCustomerPerformance { get; set; }
        /// <summary>
        /// 合作达人老客业绩目标完成率
        /// </summary>
        public decimal? OtherLiveAnchorOldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 合作达人老客业绩同比
        /// </summary>
        public decimal? OtherLiveAnchorOldCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 合作达人老客业绩环比
        /// </summary>
        public decimal? OtherLiveAnchorOldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 合作达人总业绩
        /// </summary>
        public decimal OtherLiveAnchorPerformance { get; set; }

        /// <summary>
        /// 合作达人总业绩目标值
        /// </summary>
        public decimal OtherLiveAnchorPerformanceTarget { get; set; }

        /// <summary>
        /// 合作达人总业绩目标完成率
        /// </summary>
        public decimal? OtherLiveAnchorPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 合作达人总业绩同比
        /// </summary>
        public decimal? OtherLiveAnchorPerformanceYearToYear { get; set; }

        /// <summary>
        /// 合作达人总业绩环比
        /// </summary>
        public decimal? OtherLiveAnchorPerformanceChainRatio { get; set; }

        #endregion

        #region 【带货-停用】
        /// <summary>
        /// 带货业绩
        /// </summary>
        public decimal CommercePerformance { get; set; }

        /// <summary>
        /// 带货业绩目标值
        /// </summary>
        public decimal CommercePerformanceTarget { get; set; }

        /// <summary>
        /// 带货业绩目标完成率
        /// </summary>
        public decimal? CommercePerformanceCompleteRate { get; set; }

        /// <summary>
        /// 带货业绩同比
        /// </summary>
        public decimal? CommercePerformanceYearToYear { get; set; }

        /// <summary>
        /// 带货业绩环比
        /// </summary>
        public decimal? CommercePerformanceChainRatio { get; set; }

        #endregion

        #region【医生】

        /// <summary>
        /// 医生新客业绩
        /// </summary>
        public decimal DoctorNewCustomerPerformance { get; set; }

        /// <summary>
        /// 医生新客业绩目标完成率
        /// </summary>
        public decimal? DoctorNewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 医生新客业绩同比
        /// </summary>
        public decimal? DoctorNewCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 医生新客业绩环比
        /// </summary>
        public decimal? DoctorNewCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 医生老客业绩
        /// </summary>
        public decimal DoctorOldCustomerPerformance { get; set; }


        /// <summary>
        /// 医生老客业绩目标完成率
        /// </summary>
        public decimal? DoctorOldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 医生老客业绩同比
        /// </summary>
        public decimal? DoctorOldCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 医生老客业绩环比
        /// </summary>
        public decimal? DoctorOldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 医生总业绩
        /// </summary>
        public decimal DoctorPerformance { get; set; }

        /// <summary>
        /// 医生总业绩目标值
        /// </summary>
        public decimal DoctorPerformanceTarget { get; set; }

        /// <summary>
        /// 医生总业绩目标完成率
        /// </summary>
        public decimal? DoctorPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 医生总业绩同比
        /// </summary>
        public decimal? DoctorPerformanceYearToYear { get; set; }

        /// <summary>
        /// 医生总业绩环比
        /// </summary>
        public decimal? DoctorPerformanceChainRatio { get; set; }
        #endregion

        #region 【其他】

        /// <summary>
        /// 其他新客业绩
        /// </summary>
        public decimal OtherNewCustomerPerformance { get; set; }

        /// <summary>
        /// 其他新客业绩目标完成率
        /// </summary>
        public decimal? OtherNewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 其他新客业绩同比
        /// </summary>
        public decimal? OtherNewCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 其他新客业绩环比
        /// </summary>
        public decimal? OtherNewCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 其他老客业绩
        /// </summary>
        public decimal OtherOldCustomerPerformance { get; set; }

        /// <summary>
        /// 其他老客业绩目标完成率
        /// </summary>
        public decimal? OtherOldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 其他老客业绩同比
        /// </summary>
        public decimal? OtherOldCustomerPerformanceYearToYear { get; set; }

        /// <summary>
        /// 其他老客业绩环比
        /// </summary>
        public decimal? OtherOldCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 其他总业绩
        /// </summary>
        public decimal OtherPerformance { get; set; }

        /// <summary>
        /// 其他总业绩目标值
        /// </summary>
        public decimal OtherPerformanceTarget { get; set; }

        /// <summary>
        /// 其他总业绩目标完成率
        /// </summary>
        public decimal? OtherPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 其他总业绩同比
        /// </summary>
        public decimal? OtherPerformanceYearToYear { get; set; }

        /// <summary>
        /// 其他总业绩环比
        /// </summary>
        public decimal? OtherPerformanceChainRatio { get; set; }
        #endregion
    }
}
