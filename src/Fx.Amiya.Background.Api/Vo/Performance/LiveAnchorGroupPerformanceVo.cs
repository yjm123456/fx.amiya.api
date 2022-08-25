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
        public int? PictureConsultationPerformance { get; set; }

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
        public int? VideoConsultationPerformance { get; set; }

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

}
