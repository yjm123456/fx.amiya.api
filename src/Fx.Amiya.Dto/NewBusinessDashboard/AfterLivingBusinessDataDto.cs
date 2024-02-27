using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class AfterLivingBusinessDataDto
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 总业绩目标
        /// </summary>
        public decimal TotalPerformanceTarget { get; set; }
      

        /// <summary>
        /// 总业绩目标完成率
        /// </summary>
        public decimal? TotalPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal? TotalPerformanceChainRatio { get; set; }

        /// <summary>
        /// 总业绩对比时间进度
        /// </summary>
        public decimal TotalPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
       

        /// <summary>
        /// 新客业绩目标完成率
        /// </summary>
        public decimal? NewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal? NewCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal? NewCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 新客业绩对比时间进度
        /// </summary>
        public decimal NewCustomerPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
   

        /// <summary>
        /// 老客业绩目标完成率
        /// </summary>
        public decimal? OldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 老客业绩对比时间进度
        /// </summary>
        public decimal OldCustomerPerformanceToDateSchedule { get; set; }



        /// <summary>
        /// 有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 有效业绩目标
        /// </summary>
        public decimal EffectivePerformanceTarget { get; set; }


        /// <summary>
        /// 有效业绩目标完成率
        /// </summary>
        public decimal? EffectivePerformanceCompleteRate { get; set; }

        /// <summary>
        /// 有效业绩同比
        /// </summary>
        public decimal? EffectivePerformanceYearOnYear { get; set; }

        /// <summary>
        /// 有效业绩环比
        /// </summary>
        public decimal? EffectivePerformanceChainRatio { get; set; }

        /// <summary>
        /// 有效业绩对比时间进度
        /// </summary>
        public decimal EffectivePerformanceToDateSchedule { get; set; }

       

        /// <summary>
        /// 潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 潜在业绩目标
        /// </summary>
        public decimal PotentialPerformanceTarget { get; set; }
    

        /// <summary>
        /// 潜在业绩目标完成率
        /// </summary>
        public decimal? PotentialPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 潜在业绩同比
        /// </summary>
        public decimal? PotentialPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 潜在业绩环比
        /// </summary>
        public decimal? PotentialPerformanceChainRatio { get; set; }

        /// <summary>
        /// 潜在业绩对比时间进度
        /// </summary>
        public decimal PotentialPerformanceToDateSchedule { get; set; }
        /// <summary>
        /// 新客有效业绩
        /// </summary>
        public decimal NewCustomerEffectivePerformance { get; set; }
        /// <summary>
        /// 新客有效业绩环比
        /// </summary>
        public decimal? NewCustomerEffectivePerformanceChain { get; set; }
        /// <summary>
        /// 新客有效业绩同比
        /// </summary>
        public decimal? NewCustomerEffectivePerformanceYearToYear { get; set; }
        /// <summary>
        /// 新客潜在业绩
        /// </summary>
        public decimal NewCustomerPotentialPerformance { get; set; }
        /// <summary>
        /// 新客潜在业绩环比
        /// </summary>
        public decimal? NewCustomerPotentialPerformanceChain { get; set; }
        /// <summary>
        /// 新客潜在业绩同比
        /// </summary>
        public decimal? NewCustomerPotentialPerformanceYearToYear { get; set; }
        /// <summary>
        /// 老客有效业绩
        /// </summary>
        public decimal OldCustomerEffectivePerformance { get; set; }
        /// <summary>
        /// 老客有效业绩环比
        /// </summary>
        public decimal? OldCustomerEffectivePerformanceChain { get; set; }
        /// <summary>
        /// 老客有效业绩同比
        /// </summary>
        public decimal? OldCustomerEffectivePerformanceYearToYear { get; set; }
        /// <summary>
        /// 老客潜在业绩
        /// </summary>
        public decimal OldCustomerPotentialPerformance { get; set; }
        /// <summary>
        /// 老客潜在业绩环比
        /// </summary>
        public decimal? OldCustomerPotentialPerformanceChain { get; set; }
        /// <summary>
        /// 老客潜在业绩同比
        /// </summary>
        public decimal? OldCustomerPotentialPerformanceYearToYear { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceRate { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceRate { get; set; }
        /// <summary>
        /// 有效业绩占比
        /// </summary>
        public decimal EffectivePerformanceRate { get; set; }
        /// <summary>
        /// 潜在业绩占比
        /// </summary>
        public decimal PotentialPerformanceRate { get; set; }
        /// <summary>
        /// 新客有效业绩占比
        /// </summary>
        public decimal NewCustomerEffectivePerformanceRate { get; set; }
        /// <summary>
        /// 新客潜在业绩占比
        /// </summary>
        public decimal NewCustomerPotentialPerformanceRate { get; set; }
        /// <summary>
        /// 老客有效业绩占比
        /// </summary>
        public decimal OldCustomerEffectivePerformanceRate { get; set; }
        /// <summary>
        /// 老客潜在业绩占比
        /// </summary>
        public decimal OldCustomerPotentialPerformanceRate { get; set; }
    }
}
