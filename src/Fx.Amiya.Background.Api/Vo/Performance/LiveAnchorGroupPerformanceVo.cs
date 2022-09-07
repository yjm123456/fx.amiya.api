using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Performance
{
    /// <summary>
    /// 分组业绩看板
    /// </summary>
    public class LiveAnchorGroupPerformanceVo
    {
        /// <summary>
        /// 本月总业绩
        /// </summary>
        public decimal CueerntMonthTotalPerformance { get; set; }
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
        /// 当前月新客业绩
        /// </summary>
        public decimal CurrentMonthNewCustomerPerformance { get; set; }
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
        /// 当前月老客业绩
        /// </summary>
        public decimal CurrentMonthOldCustomerPerformance { get; set; }
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
        /// 本月带货总业绩
        /// </summary>
        public decimal CurrentMonthCommercePerformance { get; set; }
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

        /// <summary>
        /// 新老客,带货业绩所占比例
        /// </summary>
        public List<PerformanceRatioVo> PerformanceRatios { get; set; }

        /// <summary>
        /// 新客业绩数据
        /// </summary>
        public List<PerformanceListInfo> NewPerformanceData { get; set; }
        /// <summary>
        /// 老客业绩数据
        /// </summary>
        public List<PerformanceListInfo> OldPerformanceData { get; set; }
        /// <summary>
        /// 带货业绩数据
        /// </summary>
        public List<PerformanceListInfo> CommercePerformanceData { get; set; }
    }


    /// <summary>
    /// 派单成交数据
    /// </summary>
    public class GroupSendAndDealInfoVo
    {
        /// <summary>
        /// 历史派单当月成交
        /// </summary>
        public decimal? HistorySendDuringMonthDeal { get; set; }

        /// <summary>
        /// 历史派单当月成交同比
        /// </summary>
        public decimal? HistorySendDuringMonthDealYearOnYear { get; set; }
        /// <summary>
        /// 历史派单当月成交环比
        /// </summary>
        public decimal? HistorySendDuringMonthDealChainRatio { get; set; }

        /// <summary>
        /// 当月派单当月成交
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDeal { get; set; }

        /// <summary>
        /// 当月派单当月成交同比
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDealYearOnYear { get; set; }
        /// <summary>
        /// 当月派单当月成交环比
        /// </summary>
        public decimal? DuringMonthSendDuringMonthDealChainRatio { get; set; }



        /// <summary>
        /// 业绩占比
        /// </summary>
        public List<PerformanceRatioVo> PerformanceRatioVo { get; set; }

        /// <summary>
        /// 历史派单当月成交
        /// </summary>
        public List<PerformanceListInfo> HistorySendDuringMonthDealList { get; set; }
        /// <summary>
        /// 当月派单当月成交
        /// </summary>
        public List<PerformanceListInfo> DuringMonthSendDuringMonthDealList { get; set; }
    }

    /// <summary>
    /// 面诊业绩
    /// </summary>
    public class ConsultationPerformanceVo
    {
        /// <summary>
        /// 照片面诊业绩
        /// </summary>
        public decimal? PictureConsultationPerformance { get; set; }

        /// <summary>
        /// 照片面诊业绩同比
        /// </summary>
        public decimal? PictureConsultationPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 照片面诊业绩环比
        /// </summary>
        public decimal? PictureConsultationPerformanceChainRatio { get; set; }

        /// <summary>
        /// 视频面诊业绩
        /// </summary>
        public decimal? VideoConsultationPerformance { get; set; }

        /// <summary>
        /// 视频面诊业绩同比
        /// </summary>
        public decimal? VideoConsultationPerformanceYearOnYear { get; set; }
        /// <summary>
        /// 视频面诊业绩环比
        /// </summary>
        public decimal? VideoConsultationPerformanceChainRatio { get; set; }


        /// <summary>
        /// 业绩占比
        /// </summary>
        public List<PerformanceRatioVo> PerformanceRatioVo { get; set; }

        /// <summary>
        /// 照片面诊业绩折线图
        /// </summary>
        public List<PerformanceListInfo> PictureConsultationPerformanceBrokenLine { get; set; }
        /// <summary>
        /// 视频面诊业绩折线图
        /// </summary>
        public List<PerformanceListInfo> VideoConsultationPerformanceBrokenLine { get; set; }
    }


    /// <summary>
    /// 独立/协助业绩
    /// </summary>
    public class IndependentOrAssistPerformanceVo
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
        /// 业绩占比
        /// </summary>
        public List<PerformanceRatioVo> PerformanceRatioVo { get; set; }

        /// <summary>
        /// 主播独立业绩折线图
        /// </summary>
        public List<PerformanceListInfo> LiveAnchorIndenpendentPerformanceBrokenLine { get; set; }
        /// <summary>
        /// 助理独立业绩折线图
        /// </summary>
        public List<PerformanceListInfo> CustomerServiceIndenpendentPerformanceBrokenLine { get; set; }
        /// <summary>
        /// 助理协助业绩折线图
        /// </summary>
        public List<PerformanceListInfo> CustomerServiceAssistPerformanceBrokenLine { get; set; }
    }

    /// <summary>
    /// 基础经营看板业绩
    /// </summary>
    public class BaseBusinessPerformanceVo
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
        /// 历史面诊卡（当月）退款
        /// </summary>
        public int? HistoryConsulationCardRefundNum { get; set; }
        /// <summary>
        /// 历史面诊卡（当月）退款同比
        /// </summary>
        public decimal? HistoryConsulationCardRefundNumYearOnYear { get; set; }
        /// <summary>
        /// 历史面诊卡（当月）退款环比
        /// </summary>
        public decimal? HistoryConsulationCardRefundNumRatioVo { get; set; }

        /// <summary>
        /// 面诊卡库存量
        /// </summary>
        public int? ConsulationCardInventoryNum { get; set; }

        /// <summary>
        /// 加v折线图
        /// </summary>
        public List<PerformanceListInfo> AddWechatBrokenLine { get; set; }

        /// <summary>
        /// 面诊卡下单折线图
        /// </summary>
        public List<PerformanceListInfo> ConsulationCardNumBrokenLine { get; set; }

        /// <summary>
        /// 当月面诊卡消耗折线图
        /// </summary>
        public List<PerformanceListInfo> ThisMonthConsulationCardConsumedNumBrokenLine { get; set; }

        /// <summary>
        /// 历史面诊卡消耗折线图
        /// </summary>
        public List<PerformanceListInfo> HistoryConsulationCardConsumedNumBrokenLine { get; set; }

        /// <summary>
        /// 当月面诊卡退款折线图
        /// </summary>
        public List<PerformanceListInfo> ThisMonthConsulationCardRefundNumBrokenLine { get; set; }

        /// <summary>
        /// 历史面诊卡（当月）退款折线图
        /// </summary>
        public List<PerformanceListInfo> HistoryConsulationCardRefundNumBrokenLine { get; set; }

    }


    /// <summary>
    /// 派单成交经营看板
    /// </summary>
    public class SendOrDealPerformanceVo
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


        /// <summary>
        /// 派单数折线图
        /// </summary>
        public List<PerformanceListInfo> SendOrderBrokenLine { get; set; }

        /// <summary>
        /// 总上门数折线图
        /// </summary>
        public List<PerformanceListInfo> TotalVisitBrokenLine { get; set; }
        /// <summary>
        /// 新客上门数折线图
        /// </summary>
        public List<PerformanceListInfo> NewCustomerVisitBrokenLine { get; set; }
        /// <summary>
        /// 老客上门数折线图
        /// </summary>
        public List<PerformanceListInfo> OldCustomerVisitBrokenLine { get; set; }

        /// <summary>
        /// 总成交数折线图
        /// </summary>
        public List<PerformanceListInfo> TotalDealBrokenLine { get; set; }
        /// <summary>
        /// 新客成交数折线图
        /// </summary>
        public List<PerformanceListInfo> NewCustomerDealBrokenLine { get; set; }
        /// <summary>
        /// 老客成交数折线图
        /// </summary>
        public List<PerformanceListInfo> OldCustomerDealBrokenLine { get; set; }
    }



    /// <summary>
    /// 主播客单价业绩
    /// </summary>
    public class GuestUnitPricePerformanceVo 
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



        /// <summary>
        /// 总客单价折线图
        /// </summary>
        public List<PerformanceListInfo> TotalGuestUnitPricePerformanceBrokenLine { get; set; }
        /// <summary>
        /// 新诊客单价折线图
        /// </summary>
        public List<PerformanceListInfo> NewGuestUnitPricePerformanceBrokenLine { get; set; }
        /// <summary>
        /// 老客客单价折线图
        /// </summary>
        public List<PerformanceListInfo> OldGuestUnitPricePerformanceBrokenLine { get; set; }
    }

    /// <summary>
    /// 各版块完成率
    /// </summary>
    public class GroupTargetCompleteRateVo
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
        


        /// <summary>
        /// 加v率折线图
        /// </summary>
        public List<PerformanceListInfo> AddWeChatCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 下单面诊卡消耗率折线图
        /// </summary>
        public List<PerformanceListInfo> ConsulationCardUsedCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 派单率折线图
        /// </summary>
        public List<PerformanceListInfo> SendOrderCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 新客上门率折线图
        /// </summary>
        public List<PerformanceListInfo> NewCustomerVisitCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 新客成交率折线图
        /// </summary>
        public List<PerformanceListInfo> NewCustomerDealCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 当月面诊卡退单率折线图
        /// </summary>
        public List<PerformanceListInfo> ThisMonthConsulationCardRefundCompleteRateBrokenLine { get; set; }

        /// <summary>
        /// 历史面诊卡退单率折线图
        /// </summary>
        public List<PerformanceListInfo> HistoryConsulationCardRefundCompleteRateBrokenLine { get; set; }

    }


}
