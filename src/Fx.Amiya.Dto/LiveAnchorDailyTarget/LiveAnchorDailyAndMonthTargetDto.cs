using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    /// <summary>
    /// 主播经营情况数据
    /// </summary>
    public class LiveAnchorDailyAndMonthTargetDto
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchor { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 直播中人员id
        /// </summary>
        public int LivingTrackingEmployeeId { get; set; }
        /// <summary>
        /// 网咨人员Id
        /// </summary>
        public int NetWorkConsultingEmployeeId { get; set; }

        /// <summary>
        /// 直播中人员名称
        /// </summary>
        public string LivingTrackingEmployeeName { get; set; }

        /// <summary>
        /// 网咨人员名称
        /// </summary>
        public string NetWorkConsultingEmployeeName { get; set; }



        /// <summary>
        /// 知乎运营人员Id
        /// </summary>
        public int ZhihuOperationEmployeeId { get; set; }
        /// <summary>
        /// 知乎运营人员名称
        /// </summary>
        public string ZhihuOperationEmployeeName { get; set; }

        /// <summary>
        /// 今日知乎发布量
        /// </summary>
        public int ZhihuSendNum { get; set; }

        /// <summary>
        /// 月知乎发布目标
        /// </summary>
        public int ZhihuReleaseTarget { get; set; }

        /// <summary>
        /// 月累计知乎发布条数
        /// </summary>
        public int ZhihuCumulativeRelease { get; set; }

        /// <summary>
        /// 知乎发布目标完成率
        /// </summary>
        public string ZhihuReleaseCompleteRate { get; set; }

        /// <summary>
        /// 知乎今日投流费用
        /// </summary>
        public decimal ZhihuFlowInvestmentNum { get; set; }
        /// <summary>
        /// 知乎投流费用目标
        /// </summary>
        public decimal ZhihuFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计知乎投流费用
        /// </summary>

        public decimal CumulativeZhihuFlowinvestment { get; set; }
        /// <summary>
        /// 知乎投流费用完成率
        /// </summary>
        public string ZhihuFlowinvestmentCompleteRate { get; set; }



        /// <summary>
        /// 微博运营人员Id
        /// </summary>
        public int SinaWeiBoOperationEmployeeId { get; set; }
        /// <summary>
        /// 微博运营人员名称
        /// </summary>
        public string SinaWeiBoOperationEmployeeName { get; set; }

        /// <summary>
        /// 今日微博发布量
        /// </summary>
        public int SinaWeiBoSendNum { get; set; }

        /// <summary>
        /// 月微博发布目标
        /// </summary>
        public int SinaWeiBoReleaseTarget { get; set; }

        /// <summary>
        /// 月累计微博发布条数
        /// </summary>
        public int SinaWeiBoCumulativeRelease { get; set; }

        /// <summary>
        /// 微博发布目标完成率
        /// </summary>
        public string SinaWeiBoReleaseCompleteRate { get; set; }

        /// <summary>
        /// 微博今日投流费用
        /// </summary>
        public decimal SinaWeiBoFlowInvestmentNum { get; set; }
        /// <summary>
        /// 微博投流费用目标
        /// </summary>
        public decimal SinaWeiBoFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计微博投流费用
        /// </summary>

        public decimal CumulativeSinaWeiBoFlowinvestment { get; set; }
        /// <summary>
        /// 微博投流费用完成率
        /// </summary>
        public string SinaWeiBoFlowinvestmentCompleteRate { get; set; }


        /// <summary>
        /// 视频号运营人员Id
        /// </summary>
        public int VideoOperationEmployeeId { get; set; }
        /// <summary>
        /// 视频号运营人员名称
        /// </summary>
        public string VideoOperationEmployeeName { get; set; }
        /// <summary>
        /// 视频号今日发布量
        /// </summary>
        public int VideoSendNum { get; set; }

        /// <summary>
        /// 视频号发布目标
        /// </summary>
        public int VideoReleaseTarget { get; set; }

        /// <summary>
        /// 月累计视频号发布条数
        /// </summary>
        public int CumulativeVideoRelease { get; set; }

        /// <summary>
        /// 视频号发布目标完成率
        /// </summary>
        public string VideoReleaseCompleteRate { get; set; }

        /// <summary>
        /// 视频号今日投流费用
        /// </summary>
        public decimal VideoFlowInvestmentNum { get; set; }
        /// <summary>
        /// 视频号投流费用目标
        /// </summary>
        public decimal VideoFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计视频号投流费用
        /// </summary>

        public decimal CumulativeVideoFlowinvestment { get; set; }
        /// <summary>
        /// 视频号投流费用完成率
        /// </summary>
        public string VideoFlowinvestmentCompleteRate { get; set; }



        /// <summary>
        /// 抖音运营人员Id
        /// </summary>
        public int TikTokOperationEmployeeId { get; set; }
        /// <summary>
        /// 抖音运营人员名称
        /// </summary>
        public string TikTokOperationEmployeeName { get; set; }
        /// <summary>
        /// 今日抖音发布量
        /// </summary>
        public int TikTokSendNum { get; set; }

        /// <summary>
        /// 月抖音发布目标
        /// </summary>
        public int TikTokReleaseTarget { get; set; }

        /// <summary>
        /// 月累计抖音发布条数
        /// </summary>
        public int TikTokCumulativeRelease { get; set; }

        /// <summary>
        /// 抖音发布目标完成率
        /// </summary>
        public string TikTokReleaseCompleteRate { get; set; }


        /// <summary>
        /// 抖音今日投流费用
        /// </summary>
        public decimal TikTokFlowInvestmentNum { get; set; }


        /// <summary>
        /// 抖音投流费用目标
        /// </summary>
        public decimal TikTokFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计抖音投流费用
        /// </summary>

        public decimal CumulativeTikTokFlowinvestment { get; set; }
        /// <summary>
        /// 抖音投流费用完成率
        /// </summary>
        public string TikTokFlowinvestmentCompleteRate { get; set; }


        /// <summary>
        /// 小红书运营人员Id
        /// </summary>
        public int XiaoHongShuOperationEmployeeId { get; set; }
        /// <summary>
        /// 小红书运营人员名称
        /// </summary>
        public string XiaoHongShuOperationEmployeeName { get; set; }
        /// <summary>
        /// 今日小红书发布量
        /// </summary>
        public int XiaoHongShuSendNum { get; set; }

        /// <summary>
        /// 月小红书发布目标
        /// </summary>
        public int XiaoHongShuReleaseTarget { get; set; }

        /// <summary>
        /// 月累计小红书发布条数
        /// </summary>
        public int XiaoHongShuCumulativeRelease { get; set; }

        /// <summary>
        /// 小红书发布目标完成率
        /// </summary>
        public string XiaoHongShuReleaseCompleteRate { get; set; }

        /// <summary>
        /// 小红书今日投流费用
        /// </summary>
        public decimal XiaoHongShuFlowInvestmentNum { get; set; }
        /// <summary>
        /// 小红书投流费用目标
        /// </summary>
        public decimal XiaoHongShuFlowinvestmentTarget { get; set; }
        /// <summary>
        /// 累计小红书投流费用
        /// </summary>

        public decimal CumulativeXiaoHongShuFlowinvestment { get; set; }
        /// <summary>
        /// 小红书投流费用完成率
        /// </summary>
        public string XiaoHongShuFlowinvestmentCompleteRate { get; set; }

        /// <summary>
        /// 今日发布量
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 月发布目标
        /// </summary>
        public int ReleaseTarget { get; set; }

        /// <summary>
        /// 月累计发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }

        /// <summary>
        /// 发布目标完成率
        /// </summary>
        public string ReleaseCompleteRate { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }

        /// <summary>
        /// 运营渠道投流费用目标
        /// </summary>
        public decimal FlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计运营渠道投流费用
        /// </summary>
        public decimal CumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 运营渠道投流费用完成率
        /// </summary>
        public string FlowInvestmentCompleteRate { get; set; }
        /// <summary>
        /// 今日直播间投流费用
        /// </summary>
        public decimal LivingRoomFlowInvestmentNum { get; set; }
        /// <summary>
        /// 直播间投流费用目标
        /// </summary>
        public decimal LivingRoomFlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计直播间投流费用
        /// </summary>
        public decimal LivingRoomCumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 直播间投流费用完成率
        /// </summary>
        public string LivingRoomFlowInvestmentCompleteRate { get; set; }

        /// <summary>
        /// 今日线索量
        /// </summary>
        public int CluesNum { get; set; }
        /// <summary>
        /// 线索目标
        /// </summary>
        public int CluesNumTarget { get; set; }

        /// <summary>
        /// 月累计线索数量
        /// </summary>
        public int CumulativeCluesNum { get; set; }

        /// <summary>
        /// 线索完成率
        /// </summary>
        public string CluesCompleteRate { get; set; }

        /// <summary>
        /// 今日涨粉量
        /// </summary>
        public int AddFansNum { get; set; }
        /// <summary>
        /// 涨粉目标
        /// </summary>
        public int AddFansTarget { get; set; }

        /// <summary>
        /// 月累计涨粉数量
        /// </summary>
        public int CumulativeAddFansNum { get; set; }

        /// <summary>
        /// 涨粉完成率
        /// </summary>
        public string AddFansCompleteRate { get; set; }

        /// <summary>
        /// 今日99面诊卡数量
        /// </summary>
        public int Consultation { get; set; }
        /// <summary>
        /// 99面诊卡目标
        /// </summary>
        public int ConsultationTarget { get; set; }

        /// <summary>
        /// 累计99面诊卡
        /// </summary>
        public int CumulativeConsultation { get; set; }

        /// <summary>
        /// 99面诊卡完成率
        /// </summary>
        public string ConsultationCompleteRate { get; set; }
        /// <summary>
        /// 今日199面诊卡数量
        /// </summary>
        public int Consultation2 { get; set; }
        /// <summary>
        /// 199面诊卡目标
        /// </summary>
        public int ConsultationTarget2 { get; set; }

        /// <summary>
        /// 累计199面诊卡
        /// </summary>
        public int CumulativeConsultation2 { get; set; }

        /// <summary>
        /// 199面诊卡完成率
        /// </summary>
        public string ConsultationCompleteRate2 { get; set; }

        /// <summary>
        /// 今日99消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed { get; set; }

        /// <summary>
        /// 99消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget { get; set; }

        /// <summary>
        /// 累计99消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed { get; set; }

        /// <summary>
        /// 99消耗卡完成率
        /// </summary>
        public string ConsultationCardConsumedCompleteRate { get; set; }
        /// <summary>
        /// 今日199消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed2 { get; set; }

        /// <summary>
        /// 199消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget2 { get; set; }

        /// <summary>
        /// 累计199消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed2 { get; set; }

        /// <summary>
        /// 199消耗卡完成率
        /// </summary>
        public string ConsultationCardConsumedCompleteRate2 { get; set; }

        /// <summary>
        /// 今日激活历史面诊数量
        /// </summary>
        public int ActivateHistoricalConsultation { get; set; }
        /// <summary>
        /// 激活历史面诊数量目标
        /// </summary>
        public int ActivateHistoricalConsultationTarget { get; set; }

        /// <summary>
        /// 累计激活历史面诊数量
        /// </summary>
        public int CumulativeActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 激活历史面诊数量完成率
        /// </summary>
        public string ActivateHistoricalConsultationCompleteRate { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }
        /// <summary>
        /// 目标加V量
        /// </summary>
        public int AddWechatTarget { get; set; }

        /// <summary>
        /// 月加V累计
        /// </summary>
        public int CumulativeAddWechat { get; set; }

        /// <summary>
        /// 加V完成率
        /// </summary>
        public string AddWechatCompleteRate { get; set; }

        /// <summary>
        /// 今日派单量
        /// </summary>
        public int SendOrderNum { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }

        /// <summary>
        /// 累计派单
        /// </summary>
        public int CumulativeSendOrder { get; set; }

        /// <summary>
        /// 派单完成率
        /// </summary>
        public string SendOrderCompleteRate { get; set; }

        /// <summary>
        /// 今日新诊上门人数
        /// </summary>
        public int NewVisitNum { get; set; }

        /// <summary>
        /// 今日复诊上门人数
        /// </summary>
        public int SubsequentVisitNum { get; set; }

        /// <summary>
        /// 今日老客上门人数
        /// </summary>
        public int OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 今日上门人数
        /// </summary>
        public int VisitNum { get; set; }

        /// <summary>
        /// 上门目标
        /// </summary>
        public int VisitTarget { get; set; }

        /// <summary>
        /// 累计上门数
        /// </summary>
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 上门完成率
        /// </summary>
        public string VisitCompleteRate { get; set; }
        /// <summary>
        /// 今日新客成交人数
        /// </summary>
        public int NewDealNum { get; set; }
        /// <summary>
        /// 今日复诊成交人数
        /// </summary>
        public int SubsequentDealNum { get; set; }
        /// <summary>
        /// 今日老客成交人数
        /// </summary>
        public int OldCustomerDealNum { get; set; }


        /// <summary>
        /// 今日成交人数
        /// </summary>
        public int DealNum { get; set; }

        /// <summary>
        /// 成交人数目标
        /// </summary>
        public int DealTarget { get; set; }

        /// <summary>
        /// 累计成交人数
        /// </summary>
        public int CumulativeDealTarget { get; set; }

        /// <summary>
        /// 成交率
        /// </summary>
        public string DealRate { get; set; }
        /// <summary>
        /// 今日带货结算佣金
        /// </summary>
        public decimal CargoSettlementCommission { get; set; }

        /// <summary>
        /// 带货结算佣金目标
        /// </summary>
        public decimal CargoSettlementCommissionTarget { get; set; }

        /// <summary>
        /// 月累计带货结算佣金金额
        /// </summary>
        public decimal CumulativeCargoSettlementCommission { get; set; }

        /// <summary>
        /// 带货结算佣金完成率
        /// </summary>
        public string CargoSettlementCommissionCompleteRate { get; set; }
        /// <summary>
        /// 今日新诊业绩
        /// </summary>
        public decimal NewPerformanceNum { get; set; }
        /// <summary>
        /// 今日复诊业绩
        /// </summary>
        public decimal SubsequentPerformanceNum { get; set; }

        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal OldCustomerPerformanceNum { get; set; }
        /// <summary>
        /// 今日总新客业绩(新诊业绩+复诊业绩)
        /// </summary>
        public decimal NewCustomerPerformanceCountNum { get; set; }

        /// <summary>
        /// 今日业绩
        /// </summary>
        public decimal PerformanceNum { get; set; }

        /// <summary>
        /// 业绩目标
        /// </summary>
        public decimal PerformanceTarget { get; set; }

        /// <summary>
        /// 月累计业绩金额
        /// </summary>
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 业绩完成率
        /// </summary>
        public string PerformanceCompleteRate { get; set; }

        /// <summary>
        /// 今日小黄车退单量
        /// </summary>
        public int MinivanRefund { get; set; }


        /// <summary>
        /// 小黄车退单总量
        /// </summary>
        public int MinivanRefundTarget { get; set; }

        /// <summary>
        /// 月累计小黄车退单
        /// </summary>
        public int CumulativeMinivanRefund { get; set; }

        /// <summary>
        /// 小黄车退单率
        /// </summary>
        public string MinivanRefundCompleteRate { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        public int MiniVanBadReviews { get; set; }

        /// <summary>
        /// 小黄车差评总量
        /// </summary>
        public int MiniVanBadReviewsTarget { get; set; }

        /// <summary>
        /// 月累计小黄车差评
        /// </summary>
        public int CumulativeMiniVanBadReviews { get; set; }

        /// <summary>
        /// 小黄车差评率
        /// </summary>
        public string MiniVanBadReviewsCompleteRate { get; set; }
        /// <summary>
        /// 抖音直播前运营数据更新时间
        /// </summary>
        public DateTime? TikTokUpdateDate { get; set; }
        /// <summary>
        /// 直播中运营数据更新
        /// </summary>
        public DateTime? LivingUpdateDate { get; set; }
        /// <summary>
        /// 直播后运营数据更新时间
        /// </summary>
        public DateTime? AfterLivingUpdateDate { get; set; }
        

    }
}
