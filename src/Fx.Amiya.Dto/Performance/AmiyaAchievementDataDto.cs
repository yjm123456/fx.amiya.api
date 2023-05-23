using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class AmiyaAchievementDataDto
    {
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }

        /// <summary>
        /// 总业绩目标完成率
        /// </summary>
        public decimal TotalPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 总业绩同比
        /// </summary>
        public decimal TotalPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 总业绩环比
        /// </summary>
        public decimal TotalPerformanceChainRatio { get; set; }

        /// <summary>
        /// 总业绩对比时间进度
        /// </summary>
        public decimal TotalPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 总业绩偏差
        /// </summary>
        public decimal TotalPerformanceDeviation { get; set; }

        /// <summary>
        /// 总业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayTotalPerformance { get; set; }


        /// <summary>
        /// 刀刀组总业绩
        /// </summary>
        public decimal GroupDaoDaoPerformance { get; set; }

        /// <summary>
        /// 刀刀组业绩占比
        /// </summary>
        public decimal GroupDaoDaoPerformanceProportion { get; set; }

        /// <summary>
        /// 刀刀组业绩目标完成率
        /// </summary>
        public decimal GroupDaoDaoPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 刀刀组业绩同比
        /// </summary>
        public decimal GroupDaoDaoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 刀刀组业绩环比
        /// </summary>
        public decimal GroupDaoDaoPerformanceChainRatio { get; set; }

        /// <summary>
        /// 刀刀组业绩对比时间进度
        /// </summary>
        public decimal GroupDaoDaoPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 刀刀组业绩偏差
        /// </summary>
        public decimal GroupDaoDaoPerformanceDeviation { get; set; }

        /// <summary>
        /// 刀刀组业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayGroupDaoDaoPerformance { get; set; }


        /// <summary>
        /// 吉娜组总业绩
        /// </summary>
        public decimal GroupJinaPerformance { get; set; }

        /// <summary>
        /// 吉娜组业绩占比
        /// </summary>
        public decimal GroupJinaPerformanceProportion { get; set; }

        /// <summary>
        /// 吉娜组业绩目标完成率
        /// </summary>
        public decimal GroupJinaPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 吉娜组业绩同比
        /// </summary>
        public decimal GroupJinaPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 吉娜组业绩环比
        /// </summary>
        public decimal GroupJinaPerformanceChainRatio { get; set; }

        /// <summary>
        /// 吉娜组业绩对比时间进度
        /// </summary>
        public decimal GroupJinaPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 吉娜组业绩偏差
        /// </summary>
        public decimal GroupJinaPerformanceDeviation { get; set; }

        /// <summary>
        /// 吉娜组业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayGroupJinaPerformance { get; set; }

        /// <summary>
        /// 退款业绩
        /// </summary>
        public decimal RefundPerformance { get; set; }
    }
}
