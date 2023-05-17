using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Performance.AmiyaPerformance2.Result
{
    /// <summary>
    /// 业绩看板输出类
    /// </summary>
    public class AmiyaAchievementDataVo
    {
        #region{导航条1}
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
        #endregion

        #region{导航条2}
        /// <summary>
        /// 新客业绩
        /// </summary>
        public decimal NewCustomerPerformance { get; set; }

        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal NewCustomerPerformanceProportion { get; set; }

        /// <summary>
        /// 新客业绩目标完成率
        /// </summary>
        public decimal NewCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal NewCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal NewCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 新客业绩对比时间进度
        /// </summary>
        public decimal NewCustomerPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 新客业绩偏差
        /// </summary>
        public decimal NewCustomerPerformanceDeviation { get; set; }

        /// <summary>
        /// 新客业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayNewCustomerPerformance { get; set; }


        /// <summary>
        /// 老客业绩
        /// </summary>
        public decimal OldCustomerPerformance { get; set; }
        //...


        /// <summary>
        /// 有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        //...

        #endregion

        #region{折线图输出}
        /// <summary>
        /// 新客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NewCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 老客业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> OldCustomerPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 有效业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> EffectivePerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 潜在业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> PotentialPerformanceBrokenLineList { get; set; }
        //...

        #endregion
    }

    /// <summary>
    /// 运营看板输出类
    /// </summary>
    public class AmiyaOperationDataVo
    {

    }


    /// <summary>
    /// 业绩折线图
    /// </summary>
    public class PerformanceBrokenLineListInfoVo
    {
        /// <summary>
        /// 日期（可以是年也可以是月）例：年输出1-12，月输出1-31
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 业绩金额
        /// </summary>
        public decimal? Performance { get; set; }
    }
}
