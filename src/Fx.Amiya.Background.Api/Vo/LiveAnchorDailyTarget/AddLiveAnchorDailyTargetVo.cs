﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget
{
    /// <summary>
    /// 新增主播日运营情况数据
    /// </summary>
    public class AddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int OperationEmployeeId { get; set; }

        /// <summary>
        /// 直播中人员id
        /// </summary>
        public int LivingTrackingEmployeeId { get; set; }

        /// <summary>
        /// 网咨人员Id
        /// </summary>
        public int? NetWorkConsultingEmployeeId { get; set; }

        /// <summary>
        /// 今日发布量
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日视频号投流量
        /// </summary>
        public int FlowInvestmentNum { get; set; }
        /// <summary>
        /// 今日直播间投流量
        /// </summary>
        public int LivingRoomFlowInvestmentNum { get; set; }
        /// <summary>
        /// 今日线索量
        /// </summary>
        public int CluesNum { get; set; }

        /// <summary>
        /// 今日涨粉量
        /// </summary>
        public int AddFansNum { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 今日99面诊卡数量
        /// </summary>
        public int Consultation { get; set; }
        /// <summary>
        /// 今日199面诊卡数量
        /// </summary>
        public int Consultation2 { get; set; }

        /// <summary>
        /// 今日99消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed { get; set; }
        /// <summary>
        /// 今日199消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed2 { get; set; }

        /// <summary>
        /// 今日激活历史面诊数量
        /// </summary>
        public int ActivateHistoricalConsultation { get; set; }


        /// <summary>
        /// 今日派单量
        /// </summary>
        public int? SendOrderNum { get; set; }

        /// <summary>
        /// 今日新诊上门人数
        /// </summary>
        public int? NewVisitNum { get; set; }

        /// <summary>
        /// 今日复诊上门人数
        /// </summary>
        public int? SubsequentVisitNum { get; set; }

        /// <summary>
        /// 今日老客上门人数
        /// </summary>
        public int? OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 今日上门人数
        /// </summary>
        public int? VisitNum { get; set; }
        /// <summary>
        /// 今日新客成交人数
        /// </summary>
        public int? NewDealNum { get; set; }
        /// <summary>
        /// 今日复诊成交人数
        /// </summary>
        public int? SubsequentDealNum { get; set; }
        /// <summary>
        /// 今日老客成交人数
        /// </summary>
        public int? OldCustomerDealNum { get; set; }

        /// <summary>
        /// 今日成交人数
        /// </summary>
        public int? DealNum { get; set; }
        /// <summary>
        /// 今日带货结算佣金
        /// </summary>
        public decimal CargoSettlementCommission { get; set; }
        /// <summary>
        /// 今日新诊业绩
        /// </summary>
        public decimal? NewPerformanceNum { get; set; }
        /// <summary>
        /// 今日复诊业绩
        /// </summary>
        public decimal? SubsequentPerformanceNum { get; set; }

        /// <summary>
        /// 今日总新客业绩(新诊业绩+复诊业绩)
        /// </summary>
        public decimal? NewCustomerPerformanceCountNum { get; set; }

        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal? OldCustomerPerformanceNum { get; set; }

        /// <summary>
        /// 今日小黄车退单量
        /// </summary>
        public int MinivanRefund { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        public int MiniVanBadReviews { get; set; }
        /// <summary>
        /// 今日业绩
        /// </summary>
        public decimal? PerformanceNum { get; set; }


        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }

    /// <summary>
    /// 直播前抖音新增主播日运营情况数据
    /// </summary>
    public class BeforeLivingTikTokAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int TikTokOperationEmployeeId { get; set; }
        /// <summary>
        /// 抖音发布量
        /// </summary>
        public int TikTokSendNum { get; set; }
        /// <summary>
        /// 抖音今日投流费用
        /// </summary>
        public decimal TikTokFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量（当前渠道发布量）
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用（当前渠道投流费用）
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        ///// <summary>
        ///// 今日线索量
        ///// </summary>
        //public int CluesNum { get; set; }

        ///// <summary>
        ///// 今日涨粉量
        ///// </summary>
        //public int AddFansNum { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }

    /// <summary>
    /// 直播前知乎新增主播日运营情况数据
    /// </summary>
    public class BeforeLivingZhihuAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int ZhihuOperationEmployeeId { get; set; }
        /// <summary>
        /// 知乎发布量
        /// </summary>
        public int ZhihuSendNum { get; set; }
        /// <summary>
        /// 知乎今日投流费用
        /// </summary>
        public decimal ZhihuFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量（当前渠道发布量）
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用（当前渠道投流费用）
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        ///// <summary>
        ///// 今日线索量
        ///// </summary>
        //public int CluesNum { get; set; }

        ///// <summary>
        ///// 今日涨粉量
        ///// </summary>
        //public int AddFansNum { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }


    /// <summary>
    /// 直播前视频号新增主播日运营情况数据
    /// </summary>
    public class BeforeLivingVideoAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int VideoOperationEmployeeId { get; set; }
        /// <summary>
        /// 视频号发布量
        /// </summary>
        public int VideoSendNum { get; set; }
        /// <summary>
        /// 视频号今日投流费用
        /// </summary>
        public decimal VideoFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量（当前渠道发布量）
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用（当前渠道投流费用）
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        ///// <summary>
        ///// 今日线索量
        ///// </summary>
        //public int CluesNum { get; set; }

        ///// <summary>
        ///// 今日涨粉量
        ///// </summary>
        //public int AddFansNum { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }


    /// <summary>
    /// 直播前微博新增主播日运营情况数据
    /// </summary>
    public class BeforeLivingSinaWeiBoAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int SinaWeiBoOperationEmployeeId { get; set; }
        /// <summary>
        /// 微博发布量
        /// </summary>
        public int SinaWeiBoSendNum { get; set; }
        /// <summary>
        /// 微博今日投流费用
        /// </summary>
        public decimal SinaWeiBoFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量（当前渠道发布量）
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用（当前渠道投流费用）
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        ///// <summary>
        ///// 今日线索量
        ///// </summary>
        //public int CluesNum { get; set; }

        ///// <summary>
        ///// 今日涨粉量
        ///// </summary>
        //public int AddFansNum { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }


    /// <summary>
    /// 直播前小红书新增主播日运营情况数据
    /// </summary>
    public class BeforeLivingXiaoHongShuAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 运营人员Id
        /// </summary>
        public int XiaoHongShuOperationEmployeeId { get; set; }
        /// <summary>
        /// 小红书发布量
        /// </summary>
        public int XiaoHongShuSendNum { get; set; }
        /// <summary>
        /// 小红书今日投流费用
        /// </summary>
        public decimal XiaoHongShuFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量（当前渠道发布量）
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用（当前渠道投流费用）
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        ///// <summary>
        ///// 今日线索量
        ///// </summary>
        //public int CluesNum { get; set; }

        ///// <summary>
        ///// 今日涨粉量
        ///// </summary>
        //public int AddFansNum { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }


    /// <summary>
    /// 直播中新增主播日运营数据
    /// </summary>
    public class LivingAddLiveAnchorDailyTargetVo
    {
        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }
        /// <summary>
        /// 直播中人员id
        /// </summary>
        public int LivingTrackingEmployeeId { get; set; }

        /// <summary>
        /// 今日直播间投流量
        /// </summary>
        public decimal LivingRoomFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日99面诊卡数量
        /// </summary>
        public int Consultation { get; set; }
        /// <summary>
        /// 今日199面诊卡数量
        /// </summary>
        public int Consultation2 { get; set; }

        /// <summary>
        /// 今日带货结算佣金
        /// </summary>
        public decimal CargoSettlementCommission { get; set; }
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 今日退卡量
        /// </summary>
        public int RefundCard { get; set; }
        /// <summary>
        /// 今日GMV
        /// </summary>
        public decimal GMV { get; set; }

        /// <summary>
        /// 今日去卡GMV
        /// </summary>
        public decimal EliminateCardGMV { get; set; }
    }

    /// <summary>
    /// 直播后新增主播日运营数据
    /// </summary>
    public class AfterLivingAddLiveAnchorDailyTargetVo
    {

        /// <summary>
        /// 主播月目标关联id
        /// </summary>
        public string LiveanchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 网咨人员Id
        /// </summary>
        public int NetWorkConsultingEmployeeId { get; set; }

        /// <summary>
        /// 今日99消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed { get; set; }
        /// <summary>
        /// 今日199消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed2 { get; set; }

        /// <summary>
        /// 今日激活历史面诊数量
        /// </summary>
        public int ActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 今日派单量
        /// </summary>
        public int SendOrderNum { get; set; }

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
        /// 今日新诊成交人数
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
        /// 今日带货结算佣金
        /// </summary>
        public decimal CargoSettlementCommission { get; set; }
        /// <summary>
        /// 今日新诊业绩
        /// </summary>
        public decimal NewPerformanceNum { get; set; }
        /// <summary>
        /// 今日复诊业绩
        /// </summary>
        public decimal SubsequentPerformanceNum { get; set; }

        /// <summary>
        /// 今日总新客业绩(新诊业绩+复诊业绩)
        /// </summary>
        public decimal NewCustomerPerformanceCountNum { get; set; }

        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal OldCustomerPerformanceNum { get; set; }
        /// <summary>
        /// 今日业绩
        /// </summary>
        public decimal PerformanceNum { get; set; }

        /// <summary>
        /// 今日小黄车退单量
        /// </summary>
        public int MinivanRefund { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        public int MiniVanBadReviews { get; set; }
        /// <summary>
        /// 今日有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 今日潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }


        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
    }


}
