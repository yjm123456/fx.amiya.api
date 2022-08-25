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

        /// <summary>
        /// 合作达人业绩
        /// </summary>
        [Description("合作达人业绩")]
        public decimal? CooperationLiveAnchorPerformance { get; set; }

        /// <summary>
        /// 合作达人业绩同比
        /// </summary>
        public decimal? CooperationLiveAnchorPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 合作达人业绩环比
        /// </summary>
        public decimal? CooperationLiveAnchorPerformanceChainRatio { get; set; }

        /// <summary>
        /// 合作达人业绩目标达成
        /// </summary>
        public decimal? CooperationLiveAnchorPerformanceCompleteRate { get; set; }
        /// <summary>
        /// 合作达人业绩占比
        /// </summary>
        public decimal? AccountedForCooperationLiveAnchorPerformance { get; set; }

        /// <summary>
        /// 黄V组业绩
        /// </summary>
        [Description("黄V组业绩")]
        public decimal? GroupYellowVPerformance { get; set; }

        /// <summary>
        /// 黄V组业绩同比
        /// </summary>
        public decimal? GroupYellowVPerformanceYearOnYear { get; set; }

        /// <summary>
        /// 黄V组业绩环比
        /// </summary>
        public decimal? GroupYellowVPerformanceChainRatio { get; set; }

        /// <summary>
        /// 黄V组业绩目标达成
        /// </summary>
        public decimal? GroupYellowVPerformanceCompleteRate { get; set; }
        /// <summary>
        /// 黄V组业绩占比
        /// </summary>
        public decimal? AccountedForGroupYellowVPerformance { get; set; }
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
        public int VideoPerformance { get; set; }
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
        public int PicturePerformance { get; set; }
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
}
