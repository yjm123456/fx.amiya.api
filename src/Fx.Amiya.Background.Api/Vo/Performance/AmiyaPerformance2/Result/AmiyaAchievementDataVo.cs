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
    /// <summary>
    /// 啊美雅业绩详情
    /// </summary>
    public class AmiyaAchievementDetailDataVo
    {
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
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal OldCustomerPerformanceProportion { get; set; }

        /// <summary>
        /// 老客业绩目标完成率
        /// </summary>
        public decimal OldCustomerPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal OldCustomerPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal OldCustomerPerformanceChainRatio { get; set; }

        /// <summary>
        /// 老客业绩对比时间进度
        /// </summary>
        public decimal OldCustomerPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 老客业绩偏差
        /// </summary>
        public decimal OldCustomerPerformanceDeviation { get; set; }

        /// <summary>
        /// 老客业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayOldCustomerPerformance { get; set; }


        /// <summary>
        /// 有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 有效业绩占比
        /// </summary>
        public decimal EffectivePerformanceProportion { get; set; }

        /// <summary>
        /// 有效业绩目标完成率
        /// </summary>
        public decimal EffectivePerformanceCompleteRate { get; set; }

        /// <summary>
        /// 有效业绩同比
        /// </summary>
        public decimal EffectivePerformanceYearOnYear { get; set; }

        /// <summary>
        /// 有效业绩环比
        /// </summary>
        public decimal EffectivePerformanceChainRatio { get; set; }

        /// <summary>
        /// 有效业绩对比时间进度
        /// </summary>
        public decimal EffectivePerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 有效业绩偏差
        /// </summary>
        public decimal EffectivePerformanceDeviation { get; set; }

        /// <summary>
        /// 有效业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayEffectivePerformance { get; set; }

        /// <summary>
        /// 潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
        /// <summary>
        /// 潜在业绩占比
        /// </summary>
        public decimal PotentialPerformanceProportion { get; set; }

        /// <summary>
        /// 潜在业绩目标完成率
        /// </summary>
        public decimal PotentialPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 潜在业绩同比
        /// </summary>
        public decimal PotentialPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 潜在业绩环比
        /// </summary>
        public decimal PotentialPerformanceChainRatio { get; set; }

        /// <summary>
        /// 潜在业绩对比时间进度
        /// </summary>
        public decimal PotentialPerformanceToDateSchedule { get; set; }

        /// <summary>
        /// 潜在业绩偏差
        /// </summary>
        public decimal PotentialPerformanceDeviation { get; set; }

        /// <summary>
        /// 潜在业绩距离目标达成后期需完成业绩金额（若为负数则展示0）
        /// </summary>
        public decimal LaterCompleteEveryDayPotentialPerformance { get; set; }

        /// <summary>
        /// 当月派单业绩
        /// </summary>
        public decimal ThisMonthSendOrderPerformance { get; set; }
        /// <summary>
        /// 当月派单业绩占比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceProportion { get; set; }


        /// <summary>
        /// 当月派单业绩同比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 当月派单业绩环比
        /// </summary>
        public decimal ThisMonthSendOrderPerformanceChainRatio { get; set; }


        /// <summary>
        /// 历史派单业绩
        /// </summary>
        public decimal HistorySendOrderPerformance { get; set; }
        /// <summary>
        /// 历史派单业绩占比
        /// </summary>
        public decimal HistorySendOrderPerformanceProportion { get; set; }



        /// <summary>
        /// 历史派单业绩同比
        /// </summary>
        public decimal HistorySendOrderPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 历史派单业绩环比
        /// </summary>
        public decimal HistorySendOrderPerformanceChainRatio { get; set; }




        /// <summary>
        /// 抖音业绩
        /// </summary>
        public decimal TikTokPerformance { get; set; }
        /// <summary>
        /// 抖音业绩占比
        /// </summary>
        public decimal TikTokPerformanceProportion { get; set; }


        /// <summary>
        /// 抖音业绩同比
        /// </summary>
        public decimal TikTokPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 抖音业绩环比
        /// </summary>
        public decimal TikTokPerformanceChainRatio { get; set; }



        /// <summary>
        /// 视频号业绩
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 视频号业绩占比
        /// </summary>
        public decimal VideoPerformanceProportion { get; set; }


        /// <summary>
        /// 视频号业绩同比
        /// </summary>
        public decimal VideoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 视频号业绩环比
        /// </summary>
        public decimal VideoPerformanceChainRatio { get; set; }


        /// <summary>
        /// 主播视频业绩
        /// </summary>
        public decimal LiveAnchorVideoPerformance { get; set; }
        /// <summary>
        /// 主播视频业绩占比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceProportion { get; set; }


        /// <summary>
        /// 主播视频业绩同比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 主播视频业绩环比
        /// </summary>
        public decimal LiveAnchorVideoPerformanceChainRatio { get; set; }




        /// <summary>
        /// 助理照片业绩
        /// </summary>
        public decimal AssistantPhotoPerformance { get; set; }
        /// <summary>
        /// 助理照片业绩占比
        /// </summary>
        public decimal AssistantPhotoPerformanceProportion { get; set; }


        /// <summary>
        /// 助理照片业绩同比
        /// </summary>
        public decimal AssistantPhotoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 助理照片业绩环比
        /// </summary>
        public decimal AssistantPhotoPerformanceChainRatio { get; set; }



        /// <summary>
        /// 主播接诊业绩
        /// </summary>
        public decimal LiveAnchorReceptionPerformance { get; set; }
        /// <summary>
        /// 主播接诊业绩占比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceProportion { get; set; }

        /// <summary>
        /// 主播接诊业绩同比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 主播接诊业绩环比
        /// </summary>
        public decimal LiveAnchorReceptionPerformanceChainRatio { get; set; }



        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformance { get; set; }
        /// <summary>
        /// 非主播接诊业绩占比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceProportion { get; set; }


        /// <summary>
        /// 非主播接诊业绩同比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 非主播接诊业绩环比
        /// </summary>
        public decimal NoLiveAnchorReceptionPerformanceChainRatio { get; set; }
    }
    /// <summary>
    /// 啊美雅业绩看板折线图
    /// </summary>
    public class AmiyaAchievementBrokenLineListVo
    {
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
        /// <summary>
        /// 当月派单业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> ThisMonthSendOrderPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 历史派单业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> HistorySendOrderPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 抖音业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> TikTokPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 视频号业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> VideoPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 主播视频业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> LiveAnchorVideoPerformanceBrokenLineList { get; set; }

        /// <summary>
        /// 助理照片业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> AssistantPhotoPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 主播接诊业绩折线图
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> LiveAnchorReceptionPerformanceBrokenLineList { get; set; }
        /// <summary>
        /// 非主播接诊业绩
        /// </summary>
        public List<PerformanceBrokenLineListInfoVo> NoLiveAnchorReceptionPerformanceBrokenLineList { get; set; }
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



    /// <summary>
    /// 运营看板输出类
    /// </summary>
    public class AmiyaOperationDataVo
    {
        /// <summary>
        /// 新客业绩
        /// </summary>
        public NewCustomerOperationDataVo NewCustomerData { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>

        public OldCustomerOperationDataVo OldCustomerData { get; set; }

    }

    /// <summary>
    /// 新客业绩输出类
    /// </summary>
    public class NewCustomerOperationDataVo
    {
        /// <summary>
        /// 线索有效率
        /// </summary>
        public decimal? ClueEffictiveRate { get; set; }
        /// <summary>
        /// 线索有效率健康值（当月）
        /// </summary>
        public decimal? ClueEffictiveRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 退卡率
        /// </summary>
        public decimal? RefundCardRate { get; set; }
        /// <summary>
        /// 退卡率健康值(累计)
        /// </summary>
        public decimal RefundCardRateHealthValueSum { get; set; }
        /// <summary>
        /// 退卡率健康值(当月)
        /// </summary>
        public decimal RefundCardRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 加v率
        /// </summary>
        public decimal? AddWeChatRate { get; set; }
        /// <summary>
        /// 加v率健康值(累计)
        /// </summary>
        public decimal AddWeChatRateHealthValueSum { get; set; }
        /// <summary>
        /// 加v率健康值(当月)
        /// </summary>
        public decimal AddWeChatRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 派单率
        /// </summary>
        public decimal? SendOrderRate { get; set; }
        /// <summary>
        /// 派单率健康值(累计)
        /// </summary>
        public decimal SendOrderRateHealthValueSum { get; set; }
        /// <summary>
        /// 派单率健康值(当月)
        /// </summary>
        public decimal SendOrderRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 上门率
        /// </summary>
        public decimal? ToHospitalRate { get; set; }
        /// <summary>
        /// 上门率健康值(累计)
        /// </summary>
        public decimal ToHospitalRateHealthValueSum { get; set; }
        /// <summary>
        /// 上门率健康值(当月)
        /// </summary>
        public decimal ToHospitalRateHealthValueThisMonth { get; set; }
        /// <summary>
        /// 成交率
        /// </summary>
        public decimal? DealRate { get; set; }
        /// <summary>
        /// 成交率健康值(累计）
        /// </summary>
        public decimal DealRateHealthValueSum { get; set; }
        /// <summary>
        /// 成交率健康值(当月)
        /// </summary>
        public decimal DealRateHealthValueThisMonth { get; set; }

        /// <summary>
        /// 下卡成交能效（元）
        /// </summary>
        public decimal? FlowClueToDealPrice { get; set; }
        /// <summary>
        /// 分诊成交能效（元）
        /// </summary>
        public decimal? AllocationConsulationToDealPrice { get; set; }

        /// <summary>
        /// 分诊成交转化率
        /// </summary>
        public decimal? AllocationConsulationToDealRate { get; set; }

        /// <summary>
        /// 加v成交能效（元）
        /// </summary>
        public decimal? AddWeChatToDealPrice { get; set; }
        /// <summary>
        /// 派单成交转化率
        /// </summary>
        public decimal? SendOrderToDealRate { get; set; }
        /// <summary>
        /// 派单成交能效（元）
        /// </summary>
        public decimal? SendOrderToDealPrice { get; set; }
        /// <summary>
        /// 上门成交能效（元）
        /// </summary>
        public decimal? VisitToDealPrice { get; set; }
        /// <summary>
        /// 成交能效（元）
        /// </summary>
        public decimal? DealToPrice { get; set; }
        /// <summary>
        /// 漏斗图详情数据
        /// </summary>
        public List<NewCustomerOperationDataDetails> newCustomerOperationDataDetails { get; set; }

    }

    /// <summary>
    /// 老客业绩输出类
    /// </summary>
    public class OldCustomerOperationDataVo
    {
        /// <summary>
        /// 总成交人数
        /// </summary>
        public int TotalDealPeople { get; set; }

        /// <summary>
        /// 二次复购人数
        /// </summary>
        public int SecondDealPeople { get; set; }


        /// <summary>
        /// 三次复购人数
        /// </summary>
        public int ThirdDealPeople { get; set; }

        /// <summary>
        /// 四次复购人数
        /// </summary>
        public int FourthDealCustomer { get; set; }
        /// <summary>
        /// 五次及以上复购人数
        /// </summary>
        public int FifThOrMoreOrMoreDealCustomer { get; set; }


        /// <summary>
        /// 二次转换率
        /// </summary>
        public decimal SecondTimeBuyRate { get; set; }
        /// <summary>
        /// 二次复购占比
        /// </summary>
        public decimal SecondTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 三次转换率
        /// </summary>
        public decimal ThirdTimeBuyRate { get; set; }
        /// <summary>
        /// 三次复购占比
        /// </summary>
        public decimal ThirdTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 四次转换率
        /// </summary>
        public decimal FourthTimeBuyRate { get; set; }
        /// <summary>
        /// 四次复购占比
        /// </summary>
        public decimal FourthTimeBuyRateProportion { get; set; }
        /// <summary>
        /// 五次转换率
        /// </summary>
        public decimal FifthTimeOrMoreBuyRate { get; set; }
        /// <summary>
        /// 五次及以上复购占比
        /// </summary>
        public decimal FifthTimeOrMoreBuyRateProportion { get; set; }
        /// <summary>
        /// 二次复购周期
        /// </summary>
        public decimal SecondDealCycle { get; set; }
        /// <summary>
        /// 三次复购周期
        /// </summary>
        public decimal ThirdDealCycle { get; set; }
        /// <summary>
        /// 四次复购周期
        /// </summary>
        public decimal FourthDealCycle { get; set; }
        /// <summary>
        /// 五次复购周期
        /// </summary>
        public decimal FifthDealCycle { get; set; }
        /// <summary>
        /// 复购率
        /// </summary>
        public decimal BuyRate { get; set; }

    }

    /// <summary>
    /// 业绩输出详情
    /// </summary>
    public class NewCustomerOperationDataDetails
    {
        /// <summary>
        /// 标识码
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// 目标完成率
        /// </summary>
        public decimal? TargetCompleteRate { get; set; }

        /// <summary>
        /// 同比值
        /// </summary>
        public decimal? YearToYearValue { get; set; }

        /// <summary>
        /// 环比值
        /// </summary>
        public decimal? ChainRatioValue { get; set; }
    }
}
