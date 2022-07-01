using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.OrderReport
{
    /// <summary>
    /// 主播IP运营情况报表
    /// </summary>
    public class LiveAnchorOperatingReportVo
    {
        /// <summary>
        /// 填报日期
        /// </summary>
        [Description("填报日期")]
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        [Description("主播")]
        public string LiveAnchor { get; set; }

        /// <summary>
        /// 今日发布量
        /// </summary>
        [Description("今日发布量")]
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 月发布目标
        /// </summary>
        [Description("月发布目标")]
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 月累计发布条数
        /// </summary>
        [Description("月累计发布条数")]
        public int CumulativeRelease { get; set; }

        /// <summary>
        /// 发布目标完成率
        /// </summary>
        [Description("发布目标完成率")]
        public string ReleaseCompleteRate { get; set; }

        /// <summary>
        /// 今日视频号投流量
        /// </summary>
        [Description("今日视频号投流量")]
        public int FlowInvestmentNum { get; set; }

        /// <summary>
        /// 视频号投流目标
        /// </summary>
        [Description("视频号投流目标")]
        public int FlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计视频号投流数量
        /// </summary>
        [Description("月累计视频号投流数量")]
        public int CumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 视频号投流完成率
        /// </summary>
        [Description("视频号投流完成率")]
        public string FlowInvestmentCompleteRate { get; set; }
        /// <summary>
        /// 今日直播间投流量
        /// </summary>
        [Description("今日直播间投流量")]
        public int LivingRoomFlowInvestmentNum { get; set; }
        /// <summary>
        /// 直播间投流目标
        /// </summary>
        [Description("直播间投流目标")]
        public int LivingRoomFlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计直播间投流数量
        /// </summary>
        [Description("月累计直播间投流数量")]
        public int LivingRoomCumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 直播间投流完成率
        /// </summary>
        [Description("直播间投流完成率")]
        public string LivingRoomFlowInvestmentCompleteRate { get; set; }

        /// <summary>
        /// 今日线索量
        /// </summary>
        [Description("今日线索量")]
        public int CluesNum { get; set; }
        /// <summary>
        /// 线索目标
        /// </summary>
        [Description("线索目标")]
        public int CluesNumTarget { get; set; }

        /// <summary>
        /// 月累计线索数量
        /// </summary>
        [Description("月累计线索数量")]
        public int CumulativeCluesNum { get; set; }

        /// <summary>
        /// 线索完成率
        /// </summary>
        [Description("线索完成率")]
        public string CluesCompleteRate { get; set; }

        /// <summary>
        /// 今日涨粉量
        /// </summary>
        [Description("今日涨粉量")]
        public int AddFansNum { get; set; }
        /// <summary>
        /// 涨粉目标
        /// </summary>
        [Description("涨粉目标")]
        public int AddFansTarget { get; set; }

        /// <summary>
        /// 月累计涨粉数量
        /// </summary>
        [Description("月累计涨粉数量")]
        public int CumulativeAddFansNum { get; set; }

        /// <summary>
        /// 涨粉完成率
        /// </summary>
        [Description("涨粉完成率")]
        public string AddFansCompleteRate { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        [Description("今日加V量")]
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 目标加V量
        /// </summary>
        [Description("目标加V量")]
        public int AddWechatTarget { get; set; }

        /// <summary>
        /// 月加V累计
        /// </summary>
        [Description("月加V累计")]
        public int CumulativeAddWechat { get; set; }

        /// <summary>
        /// 加V完成率
        /// </summary>
        [Description("加V完成率")]
        public string AddWechatCompleteRate { get; set; }

        /// <summary>
        /// 今日面诊卡数量
        /// </summary>
        [Description("今日面诊卡下单数量")]
        public int Consultation { get; set; }
        /// <summary>
        /// 面诊卡目标
        /// </summary>
        [Description("面诊卡下单数量目标")]
        public int ConsultationTarget { get; set; }

        /// <summary>
        /// 累计面诊卡
        /// </summary>
        [Description("累计面诊卡下单数量")]
        public int CumulativeConsultation { get; set; }

        /// <summary>
        /// 面诊卡完成率
        /// </summary>
        [Description("面诊卡下单数量完成率")]
        public string ConsultationCompleteRate { get; set; }

        /// <summary>
        /// 今日消耗卡数量
        /// </summary>
        [Description("今日消耗卡数量")]
        public int ConsultationCardConsumed { get; set; }

        /// <summary>
        /// 消耗卡目标
        /// </summary>
        [Description("消耗卡目标")]
        public int ConsultationCardConsumedTarget { get; set; }

        /// <summary>
        /// 累计消耗卡
        /// </summary>
        [Description("累计消耗卡")]
        public int CumulativeConsultationCardConsumed { get; set; }

        /// <summary>
        /// 消耗卡完成率
        /// </summary>
        [Description("消耗卡完成率")]
        public string ConsultationCardConsumedCompleteRate { get; set; }

        /// <summary>
        /// 今日激活历史面诊数量
        /// </summary>
        [Description("今日激活历史面诊数量")]
        public int ActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 累计激活历史面诊数量
        /// </summary>
        [Description("累计激活历史面诊数量")]
        public int CumulativeActivateHistoricalConsultation { get; set; }
        /// <summary>
        /// 激活历史面诊数量目标
        /// </summary>
        [Description("激活历史面诊数量目标")]
        public int ActivateHistoricalConsultationTarget { get; set; }
        /// <summary>
        /// 激活历史面诊数量完成率
        /// </summary>
        [Description("激活历史面诊数量完成率")]
        public string ActivateHistoricalConsultationCompleteRate { get; set; }

        /// <summary>
        /// 今日派单量
        /// </summary>
        [Description("今日派单量")]
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        [Description("派单目标")]
        public int SendOrderTarget { get; set; }

        /// <summary>
        /// 累计派单
        /// </summary>
        [Description("累计派单")]
        public int CumulativeSendOrder { get; set; }

        /// <summary>
        /// 派单完成率
        /// </summary>
        [Description("派单完成率")]
        public string SendOrderCompleteRate { get; set; }

        /// <summary>
        /// 今日新诊上门人数
        /// </summary>
        [Description("今日新诊上门人数")]
        public int NewVisitNum { get; set; }

        /// <summary>
        /// 今日复诊上门人数
        /// </summary>
        [Description("今日复诊上门人数")]
        public int SubsequentVisitNum { get; set; }

        /// <summary>
        /// 今日老客上门人数
        /// </summary>
        [Description("今日老客上门人数")]
        public int OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 今日上门人数
        /// </summary>
        [Description("今日上门人数")]
        public int VisitNum { get; set; }

        /// <summary>
        /// 上门目标
        /// </summary>
        [Description("上门目标")]
        public int VisitTarget { get; set; }

        /// <summary>
        /// 累计上门数
        /// </summary>
        [Description("累计上门数")]
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 上门完成率
        /// </summary>
        [Description("上门完成率")]
        public string VisitCompleteRate { get; set; }
        /// <summary>
        /// 今日新客成交人数
        /// </summary>
        [Description("今日新客成交人数")]
        public int NewDealNum { get; set; }
        /// <summary>
        /// 今日复诊成交人数
        /// </summary>
        [Description("今日复诊成交人数")]
        public int SubsequentDealNum { get; set; }
        /// <summary>
        /// 今日老客成交人数
        /// </summary>
        [Description("今日老客成交人数")]
        public int OldCustomerDealNum { get; set; }

        /// <summary>
        /// 今日成交人数
        /// </summary>
        [Description("今日成交人数")]
        public int DealNum { get; set; }

        /// <summary>
        /// 成交人数目标
        /// </summary>
        [Description("成交人数目标")]
        public int DealTarget { get; set; }

        /// <summary>
        /// 累计成交人数
        /// </summary>
        [Description("累计成交人数")]
        public int CumulativeDealTarget { get; set; }

        /// <summary>
        /// 成交率
        /// </summary>
        [Description("成交率")]
        public string DealRate { get; set; }


        /// <summary>
        /// 今日带货结算佣金
        /// </summary>
        [Description("今日带货结算佣金")]
        public decimal CargoSettlementCommission { get; set; }

        /// <summary>
        /// 带货结算佣金目标
        /// </summary>
        [Description("带货结算佣金目标")]
        public decimal CargoSettlementCommissionTarget { get; set; }

        /// <summary>
        /// 月累计带货结算佣金金额
        /// </summary>
        [Description("月累计带货结算佣金金额")]
        public decimal CumulativeCargoSettlementCommission { get; set; }

        /// <summary>
        /// 带货结算佣金完成率
        /// </summary>
        [Description("带货结算佣金完成率")]
        public string CargoSettlementCommissionCompleteRate { get; set; }
        /// <summary>
        /// 今日新诊业绩
        /// </summary>
        [Description("今日新诊业绩")]
        public decimal NewPerformanceNum { get; set; }
        /// <summary>
        /// 今日复诊业绩
        /// </summary>
        [Description("今日复诊业绩")]
        public decimal SubsequentPerformanceNum { get; set; }
        /// <summary>
        /// 今日总新客业绩(新诊业绩+复诊业绩)
        /// </summary>
        [Description("总新客业绩")]
        public decimal NewCustomerPerformanceCountNum { get; set; }

        /// <summary>
        /// 今日老客业绩
        /// </summary>
        [Description("今日老客业绩")]
        public decimal OldCustomerPerformanceNum { get; set; }

        /// <summary>
        /// 今日业绩
        /// </summary>
        [Description("今日业绩")]
        public decimal PerformanceNum { get; set; }

        /// <summary>
        /// 业绩目标（包含面诊卡定金）
        /// </summary>
        [Description("业绩目标（包含面诊卡定金）")]
        public decimal PerformanceTarget { get; set; }

        /// <summary>
        /// 月累计业绩金额
        /// </summary>
        [Description("月累计业绩金额")]
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 业绩完成率
        /// </summary>
        [Description("业绩完成率")]
        public string PerformanceCompleteRate { get; set; }

        /// <summary>
        /// 今日小黄车退单量
        /// </summary>
        [Description("今日小黄车退单量")]
        public int MinivanRefund { get; set; }

        /// <summary>
        /// 小黄车退单总量
        /// </summary>
        [Description("小黄车退单量上限")]
        public int MinivanRefundTarget { get; set; }

        /// <summary>
        /// 月累计小黄车退单
        /// </summary>
        [Description("月累计小黄车退单")]
        public int CumulativeMinivanRefund { get; set; }

        /// <summary>
        /// 小黄车退单率
        /// </summary>
        [Description("小黄车退单率")]
        public string MinivanRefundCompleteRate { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        [Description("今日小黄车差评量")]
        public int MiniVanBadReviews { get; set; }

        /// <summary>
        /// 小黄车差评总量
        /// </summary>
        [Description("小黄车差评总量上限")]
        public int MiniVanBadReviewsTarget { get; set; }

        /// <summary>
        /// 月累计小黄车差评
        /// </summary>
        [Description("月累计小黄车差评")]
        public int CumulativeMiniVanBadReviews { get; set; }

        /// <summary>
        /// 小黄车差评率
        /// </summary>
        [Description("小黄车差评率")]
        public string MiniVanBadReviewsCompleteRate { get; set; }

        /// <summary>
        /// 运营人员
        /// </summary>
        [Description("运营人员")]
        public string OperationEmployeeName { get; set; }
        /// <summary>
        /// 直播中人员
        /// </summary>
        [Description("直播中人员")]
        public string LivingTrackingEmployeeName { get; set; }

        /// <summary>
        /// 网咨人员
        /// </summary>
        [Description("网咨人员")]
        public string NetWorkConsultingEmployeeName { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Description("创建日期")]
        public DateTime CreateDate { get; set; }
    }
}
