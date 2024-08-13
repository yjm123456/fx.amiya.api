using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Performance
{
    public class MonthPerformanceDto
    {
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CueerntMonthTotalPerformance { get; set; }
        /// <summary>
        /// 同比总业绩
        /// </summary>
        public decimal PerformanceYearOnYear { get; set; }
        /// <summary>
        /// 环比总业绩
        /// </summary>
        public decimal PerformanceChainRatio { get; set; }
        /// <summary>
        /// 本月带货总业绩
        /// </summary>
        public decimal CurrentMonthCommercePerformance { get; set; }
        /// <summary>
        /// 同比带货业绩
        /// </summary>
        public decimal CommercePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 环比带货业绩
        /// </summary>
        public decimal CommercePerformanceChainRation { get; set; }
        /// <summary>
        /// 当前月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 当前月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 老客同比
        /// </summary>
        public decimal OldCustomerYearOnYear { get; set; }
        /// <summary>
        /// 老客环比
        /// </summary>
        public decimal OldCustomerChainRation { get; set; }
        /// <summary>
        /// 新客同比
        /// </summary>
        public decimal NewCustomerYearOnYear { get; set; }
        /// <summary>
        /// 新客环比
        /// </summary>
        public decimal NewCustomerChainRatio { get; set; }
    }

    /// <summary>
    /// 当前月业绩数据和同环比增长率
    /// </summary>
    public class MonthPerformanceRatioDto
    {
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CueerntMonthTotalPerformance { get; set; }
        /// <summary>
        /// 当前月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
        /// <summary>
        /// 当前月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
        /// <summary>
        /// 本月带货总业绩
        /// </summary>
        public decimal CurrentMonthCommercePerformance { get; set; }
        /// <summary>
        /// 新客业绩占比
        /// </summary>
        public decimal? NewCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 老客业绩占比
        /// </summary>
        public decimal? OldCustomerPerformanceRatio { get; set; }
        /// <summary>
        /// 带货业绩占比
        /// </summary>
        public decimal? CommercePerformanceRatio { get; set; }
        /// <summary>
        /// 总业绩同比增长
        /// </summary>
        public decimal? TotalPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总业绩环比增长
        /// </summary>
        public decimal? TotalPerformanceChainratio { get; set; }
        /// <summary>
        /// 总业绩目标达成率
        /// </summary>
        public decimal? TotalPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 新客业绩同比
        /// </summary>
        public decimal? NewCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新客业绩环比
        /// </summary>
        public decimal? NewCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 新客业绩目标达成率
        /// </summary>
        public decimal? NewCustomerPerformanceTargetComplete { get; set; }
        /// <summary>
        /// 老客业绩同比
        /// </summary>
        public decimal? OldCustomerPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客业绩环比
        /// </summary>
        public decimal? OldCustomerPerformanceChainRatio { get; set; }
        /// <summary>
        /// 老客业绩目标达成率
        /// </summary>
        public decimal? OldCustomerTargetComplete { get; set; }
        /// <summary>
        /// 带货业绩同比
        /// </summary>
        public decimal? CommercePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 带货业绩环比
        /// </summary>
        public decimal? CommercePerformanceChainRatio { get; set; }
        /// <summary>
        /// 带货业绩目标达成率
        /// </summary>
        public decimal? CommercePerformanceTargetComplete { get; set; }
    }

    /// <summary>
    /// 分组业绩情况
    /// </summary>
    public class GroupPerformanceDto
    {

        /// <summary>
        /// 刀刀组业绩
        /// </summary>
        [Description("刀刀组业绩")]
        public decimal? GroupDaoDaoPerformance { get; set; }

        /// <summary>
        /// 刀刀组业绩同比
        /// </summary>
        public decimal? GroupDaoDaoPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 刀刀组业绩环比
        /// </summary>
        public decimal? GroupDaoDaoPerformanceChainRatio { get; set; }

        /// <summary>
        /// 刀刀组业绩目标达成
        /// </summary>
        public decimal? GroupDaoDaoPerformanceCompleteRate { get; set; }

        /// <summary>
        /// 刀刀组业绩占比
        /// </summary>
        public decimal? AccountedForGroupDaoDaoPerformance { get; set; }

        /// <summary>
        /// 吉娜组业绩
        /// </summary>
        [Description("吉娜组业绩")]
        public decimal? GroupJinaPerformance { get; set; }

        /// <summary>
        /// 吉娜组业绩同比
        /// </summary>
        public decimal? GroupJinaPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 吉娜组业绩环比
        /// </summary>
        public decimal? GroupJinaPerformanceChainRatio { get; set; }

        /// <summary>
        /// 吉娜组业绩目标达成
        /// </summary>
        public decimal? GroupJinaPerformanceCompleteRate { get; set; }
        /// <summary>
        /// 吉娜组业绩占比
        /// </summary>
        public decimal? AccountedForGroupJinaPerformance { get; set; }

    }

    /// <summary>
    /// 派单成交情况
    /// </summary>
    public class MonthDealPerformanceDto
    {
        /// <summary>
        /// 当月派单当月成交
        /// </summary>
        public decimal ThisMonthSendOrderDealPrice { get; set; }
        /// <summary>
        /// 当月派单当月成交同比量
        /// </summary>
        public decimal? LastYearTotalPerformance { get; set; }
        /// <summary>
        /// 当月派单当月成交环比量
        /// </summary>
        public decimal? LastMonthTotalPerformance { get; set; }
        /// <summary>
        /// 当月派单当月成交占比
        /// </summary>
        public decimal? AccountedForDuringMonthSendDuringMonthDealDetails { get; set; }

        /// <summary>
        /// 历史派单当月成交
        /// </summary>
        public decimal HistoryMonthSendOrderDealPrice { get; set; }
        /// <summary>
        /// 历史派单当月成交同比量
        /// </summary>
        public decimal? LastYearHistorySendTotalPerformance { get; set; }
        /// <summary>
        /// 历史派单当月成交环比量
        /// </summary>
        public decimal? LastMonthHistorySendTotalPerformance { get; set; }
        /// <summary>
        /// 历史派单当月成交占比
        /// </summary>
        public decimal? AccountedForHistorySendDuringMonthDealDetails { get; set; }
    }

    /// <summary>
    /// 照片/视频业绩
    /// </summary>
    public class GroupVideoAndPicturePerformanceDto
    {
        /// <summary>
        /// 视频面诊
        /// </summary>
        public decimal VideoPerformance { get; set; }
        /// <summary>
        /// 视频面诊同比量
        /// </summary>
        public decimal? LastYearVideoPerformance { get; set; }
        /// <summary>
        /// 视频面诊环比量
        /// </summary>
        public decimal? LastMonthVideoPerformance { get; set; }
        /// <summary>
        /// 视频面诊占比
        /// </summary>
        public decimal? AccountedForVideoPerformance { get; set; }


        /// <summary>
        /// 照片面诊
        /// </summary>
        public decimal PicturePerformance { get; set; }
        /// <summary>
        /// 照片面诊同比量
        /// </summary>
        public decimal? LastYearPicturePerformance { get; set; }
        /// <summary>
        /// 照片面诊环比量
        /// </summary>
        public decimal? LastMonthPicturePerformance { get; set; }
        /// <summary>
        /// 照片面诊占比
        /// </summary>
        public decimal? AccountedForPicturePerformance { get; set; }
    }


    /// <summary>
    /// 独立/协助业绩情况
    /// </summary>
    public class IndependentOrAssistPerformanceDto
    {
        /// <summary>
        /// 主播独立业绩
        /// </summary>
        public decimal? LiveAnchorIndenpendentPerformance { get; set; }

        /// <summary>
        /// 主播独立业绩同比
        /// </summary>
        public decimal? LiveAnchorIndenpendentPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 主播独立业绩环比
        /// </summary>
        public decimal? LiveAnchorIndenpendentPerformanceChainRatio { get; set; }
        /// <summary>
        /// 主播独立业绩占比
        /// </summary>
        public decimal? AccountForLiveAnchorIndenpendentPerformance { get; set; }


        /// <summary>
        /// 助理独立业绩
        /// </summary>
        public decimal? CustomerServiceIndenpendentPerformance { get; set; }

        /// <summary>
        /// 助理独立业绩同比
        /// </summary>
        public decimal? CustomerServiceIndenpendentPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 助理独立业绩环比
        /// </summary>
        public decimal? CustomerServiceIndenpendentPerformanceChainRatio { get; set; }
        /// <summary>
        /// 助理独立业绩占比
        /// </summary>
        public decimal? AccountForCustomerServiceIndenpendentPerformance { get; set; }


        /// <summary>
        /// 助理协助业绩
        /// </summary>
        public decimal? CustomerServiceAssistPerformance { get; set; }

        /// <summary>
        /// 助理协助业绩同比
        /// </summary>
        public decimal? CustomerServiceAssistPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 助理协助业绩环比
        /// </summary>
        public decimal? CustomerServiceAssistPerformanceChainRatio { get; set; }
        /// <summary>
        /// 助理协助业绩占比
        /// </summary>
        public decimal? AccountForCustomerServiceAssistPerformance { get; set; }
    }


    /// <summary>
    /// 基础经营看板业绩
    /// </summary>
    public class BaseBusinessPerformanceDto
    {
        /// <summary>
        /// 加v
        /// </summary>
        public int? AddWeChatNum { get; set; }
        /// <summary>
        /// 加v同比
        /// </summary>
        public decimal? AddWeChatNumYearOnYear { get; set; }
        /// <summary>
        /// 加v环比
        /// </summary>
        public decimal? AddWeChatNumRatioVo { get; set; }
        /// <summary>
        /// 加v目标达成
        /// </summary>
        public decimal? AddWeChatNumTargetComplete { get; set; }


        /// <summary>
        /// 面诊卡下单
        /// </summary>
        public int? ConsulationCardNum { get; set; }
        /// <summary>
        /// 面诊卡下单同比
        /// </summary>
        public decimal? ConsulationCardNumYearOnYear { get; set; }
        /// <summary>
        /// 面诊卡下单环比
        /// </summary>
        public decimal? ConsulationCardNumRatioVo { get; set; }
        /// <summary>
        /// 面诊卡下单目标达成
        /// </summary>
        public decimal? ConsulationCardNumTargetComplete { get; set; }

        /// <summary>
        /// 当月面诊卡消耗
        /// </summary>
        public int? ThisMonthConsulationCardConsumedNum { get; set; }
        /// <summary>
        /// 当月面诊卡消耗同比
        /// </summary>
        public decimal? ThisMonthConsulationCardConsumedNumYearOnYear { get; set; }
        /// <summary>
        /// 当月面诊卡消耗环比
        /// </summary>
        public decimal? ThisMonthConsulationCardConsumedNumRatioVo { get; set; }
        /// <summary>
        /// 当月面诊卡消耗目标达成
        /// </summary>
        public decimal? ThisMonthConsulationCardConsumedNumTargetComplete { get; set; }


        /// <summary>
        /// 历史面诊卡消耗
        /// </summary>
        public int? HistoryConsulationCardConsumedNum { get; set; }
        /// <summary>
        /// 历史面诊卡消耗同比
        /// </summary>
        public decimal? HistoryConsulationCardConsumedNumYearOnYear { get; set; }
        /// <summary>
        /// 历史面诊卡消耗环比
        /// </summary>
        public decimal? HistoryConsulationCardConsumedNumRatioVo { get; set; }
        /// <summary>
        /// 历史面诊卡消耗目标达成
        /// </summary>
        public decimal? HistoryConsulationCardConsumedNumTargetComplete { get; set; }

        /// <summary>
        /// 当月面诊卡退单
        /// </summary>
        public int? ThisMonthConsulationCardRefundNum { get; set; }
        /// <summary>
        /// 当月面诊卡退单同比
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundNumYearOnYear { get; set; }
        /// <summary>
        /// 当月面诊卡退单环比
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundNumRatioVo { get; set; }
        /// <summary>
        /// 当月面诊卡退单目标达成
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundNumTargetComplete { get; set; }

        /// <summary>
        /// 库存面诊卡退单
        /// </summary>
        public int? HistoryConsulationCardRefundNum { get; set; }
        /// <summary>
        /// 库存面诊卡退单同比
        /// </summary>
        public decimal? HistoryConsulationCardRefundNumYearOnYear { get; set; }
        /// <summary>
        /// 库存面诊卡退单环比
        /// </summary>
        public decimal? HistoryConsulationCardRefundNumRatioVo { get; set; }

        /// <summary>
        /// 面诊卡库存量
        /// </summary>
        public int? ConsulationCardInventoryNum { get; set; }

    }


    /// <summary>
    /// 派单成交业绩看板
    /// </summary>
    public class SendAndDealPerformanceByLiveAnchorDto
    {

        /// <summary>
        /// 派单数
        /// </summary>
        public int? SendOrderNum { get; set; }
        /// <summary>
        /// 派单数同比
        /// </summary>
        public decimal? SendOrderNumYearOnYear { get; set; }

        /// <summary>
        /// 派单数环比
        /// </summary>
        public decimal? SendOrderNumChainRatio { get; set; }
        /// <summary>
        /// 派单数目标达成
        /// </summary>
        public decimal? SendOrderNumCompleteRate { get; set; }

        /// <summary>
        /// 总上门数
        /// </summary>
        public int? TotalVisitNum { get; set; }
        /// <summary>
        /// 总上门数同比
        /// </summary>
        public decimal? TotalVisitNumYearOnYear { get; set; }

        /// <summary>
        /// 总上门数环比
        /// </summary>
        public decimal? TotalVisitNumChainRatio { get; set; }
        /// <summary>
        /// 总上门数目标达成
        /// </summary>
        public decimal? TotalVisitNumCompleteRate { get; set; }


        /// <summary>
        /// 新客上门数
        /// </summary>
        public int? NewCustomerVisitNum { get; set; }
        /// <summary>
        /// 新客上门数同比
        /// </summary>
        public decimal? NewCustomerVisitNumYearOnYear { get; set; }

        /// <summary>
        /// 新客上门数环比
        /// </summary>
        public decimal? NewCustomerVisitNumChainRatio { get; set; }
        /// <summary>
        /// 新客上门数目标达成
        /// </summary>
        public decimal? NewCustomerVisitNumCompleteRate { get; set; }

        /// <summary>
        /// 老客上门数
        /// </summary>
        public int? OldCustomerVisitNum { get; set; }
        /// <summary>
        /// 老客上门数同比
        /// </summary>
        public decimal? OldCustomerVisitNumYearOnYear { get; set; }

        /// <summary>
        /// 老客上门数环比
        /// </summary>
        public decimal? OldCustomerVisitNumChainRatio { get; set; }
        /// <summary>
        /// 老客上门数目标达成
        /// </summary>
        public decimal? OldCustomerVisitNumCompleteRate { get; set; }


        /// <summary>
        /// 总成交数
        /// </summary>
        public int? TotalDealNum { get; set; }
        /// <summary>
        /// 总成交数同比
        /// </summary>
        public decimal? TotalDealNumYearOnYear { get; set; }

        /// <summary>
        /// 总成交数环比
        /// </summary>
        public decimal? TotalDealNumChainRatio { get; set; }
        /// <summary>
        /// 总成交数目标达成
        /// </summary>
        public decimal? TotalDealNumCompleteRate { get; set; }


        /// <summary>
        /// 新客成交数
        /// </summary>
        public int? NewCustomerDealNum { get; set; }
        /// <summary>
        /// 新客成交数同比
        /// </summary>
        public decimal? NewCustomerDealNumYearOnYear { get; set; }

        /// <summary>
        /// 新客成交数环比
        /// </summary>
        public decimal? NewCustomerDealNumChainRatio { get; set; }
        /// <summary>
        /// 新客成交数目标达成
        /// </summary>
        public decimal? NewCustomerDealNumCompleteRate { get; set; }

        /// <summary>
        /// 老客成交数
        /// </summary>
        public int? OldCustomerDealNum { get; set; }
        /// <summary>
        /// 老客成交数同比
        /// </summary>
        public decimal? OldCustomerDealNumYearOnYear { get; set; }

        /// <summary>
        /// 老客成交数环比
        /// </summary>
        public decimal? OldCustomerDealNumChainRatio { get; set; }
        /// <summary>
        /// 老客成交数目标达成
        /// </summary>
        public decimal? OldCustomerDealNumCompleteRate { get; set; }
    }

    /// <summary>
    /// 客单价经营看板
    /// </summary>
    public class GuestUnitPricePerformanceDto
    {

        /// <summary>
        /// 总客单价
        /// </summary>
        public decimal? TotalGuestUnitPricePerformance { get; set; }
        /// <summary>
        /// 总客单价同比
        /// </summary>
        public decimal? TotalGuestUnitPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 总客单价环比
        /// </summary>
        public decimal? TotalGuestUnitPricePerformanceChainRatio { get; set; }


        /// <summary>
        /// 新诊客单价
        /// </summary>
        public decimal? NewGuestUnitPricePerformance { get; set; }
        /// <summary>
        /// 新诊客单价同比
        /// </summary>
        public decimal? NewGuestUnitPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 新诊客单价环比
        /// </summary>
        public decimal? NewGuestUnitPricePerformanceChainRatio { get; set; }

        /// <summary>
        /// 老客客单价
        /// </summary>
        public decimal? OldGuestUnitPricePerformance { get; set; }
        /// <summary>
        /// 老客客单价同比
        /// </summary>
        public decimal? OldGuestUnitPricePerformanceYearOnYear { get; set; }
        /// <summary>
        /// 老客客单价环比
        /// </summary>
        public decimal? OldGuestUnitPricePerformanceChainRatio { get; set; }
    }


    /// <summary>
    /// 各版块完成率
    /// </summary>
    public class GroupTargetCompleteRateDto
    {
        /// <summary>
        /// 加v率
        /// </summary>
        public decimal? AddWeChatCompleteRate { get; set; }
        /// <summary>
        /// 加v率同比
        /// </summary>
        public decimal? AddWeChatCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 加v率环比
        /// </summary>
        public decimal? AddWeChatCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 加v率目标达成
        /// </summary>
        public decimal? AddWeChatCompleteRateTarget { get; set; }

        /// <summary>
        /// 下单面诊卡消耗率
        /// </summary>
        public decimal? ConsulationCardUsedCompleteRate { get; set; }
        /// <summary>
        /// 下单面诊卡消耗率同比
        /// </summary>
        public decimal? ConsulationCardUsedCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 下单面诊卡消耗率环比
        /// </summary>
        public decimal? ConsulationCardUsedCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 下单面诊卡消耗率目标达成
        /// </summary>
        public decimal? ConsulationCardUsedCompleteRateTarget { get; set; }



        /// <summary>
        /// 派单率
        /// </summary>
        public decimal? SendOrderCompleteRate { get; set; }
        /// <summary>
        /// 派单率同比
        /// </summary>
        public decimal? SendOrderCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 派单率环比
        /// </summary>
        public decimal? SendOrderCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 派单率目标达成
        /// </summary>
        public decimal? SendOrderCompleteRateTarget { get; set; }


        /// <summary>
        /// 新客上门率
        /// </summary>
        public decimal? NewCustomerVisitCompleteRate { get; set; }
        /// <summary>
        /// 新客上门率同比
        /// </summary>
        public decimal? NewCustomerVisitCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 新客上门率环比
        /// </summary>
        public decimal? NewCustomerVisitCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 新客上门率目标达成
        /// </summary>
        public decimal? NewCustomerVisitCompleteRateTarget { get; set; }


        /// <summary>
        /// 新客成交率
        /// </summary>
        public decimal? NewCustomerDealCompleteRate { get; set; }
        /// <summary>
        /// 新客成交率同比
        /// </summary>
        public decimal? NewCustomerDealCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 新客成交率环比
        /// </summary>
        public decimal? NewCustomerDealCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 新客成交率目标达成
        /// </summary>
        public decimal? NewCustomerDealCompleteRateTarget { get; set; }


        /// <summary>
        /// 当月面诊卡退单率
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundCompleteRate { get; set; }
        /// <summary>
        /// 当月面诊卡退单率同比
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 当月面诊卡退单率环比
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 当月面诊卡退单率目标达成
        /// </summary>
        public decimal? ThisMonthConsulationCardRefundCompleteRateTarget { get; set; }


        /// <summary>
        /// 历史面诊卡退单率
        /// </summary>
        public decimal? HistoryConsulationCardRefundCompleteRate { get; set; }
        /// <summary>
        /// 历史面诊卡退单率同比
        /// </summary>
        public decimal? HistoryConsulationCardRefundCompleteRateYearOnYear { get; set; }
        /// <summary>
        /// 历史面诊卡退单率环比
        /// </summary>
        public decimal? HistoryConsulationCardRefundCompleteRateChainRatio { get; set; }
        /// <summary>
        /// 历史面诊卡退单率目标达成
        /// </summary>
        public decimal? HistoryConsulationCardRefundCompleteRateTarget { get; set; }



    }

    public class AmiyaOperationDataDto
    {

        /// <summary>
        /// 新客业绩
        /// </summary>
        public NewCustomerOperationDataDto NewCustomerData { get; set; }
        /// <summary>
        /// 老客业绩
        /// </summary>

        public OldCustomerOperationDataDto OldCustomerData { get; set; }
    }


    /// <summary>
    /// 新客业绩输出类
    /// </summary>
    public class NewCustomerOperationDataDto
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
    public class OldCustomerOperationDataDto
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
