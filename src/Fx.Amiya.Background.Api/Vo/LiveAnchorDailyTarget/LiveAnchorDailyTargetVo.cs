﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget
{
    /// <summary>
    /// 主播日运营目标数据情况
    /// </summary>
    public class LiveAnchorDailyTargetVo
    {

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

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
        /// 运营人员名称
        /// </summary>
        public string OperationEmployeeName { get; set; }
        /// <summary>
        /// 直播中跟进人员名称
        /// </summary>
        public string LivingTrackingEmployeeName { get; set; }

        /// <summary>
        /// 网咨人员名称
        /// </summary>
        public string NetWorkConsultingEmployeeName { get; set; }


        /// <summary>
        /// 微博运营人员名称
        /// </summary>
        public string SinaWeiBoOperationEmployeeName { get; set; }

        /// <summary>
        /// 微博今日发布量
        /// </summary>
        public int SinaWeiBoSendNum { get; set; }
        /// <summary>
        /// 微博今日投流费用
        /// </summary>
        public decimal SinaWeiBoFlowInvestmentNum { get; set; }


        /// <summary>
        /// 小红书运营人员名称
        /// </summary>
        public string XiaoHongShuOperationEmployeeName { get; set; }

        /// <summary>
        /// 小红书今日发布量
        /// </summary>
        public int XiaoHongShuSendNum { get; set; }
        /// <summary>
        /// 小红书今日投流费用
        /// </summary>
        public decimal XiaoHongShuFlowInvestmentNum { get; set; }


        /// <summary>
        /// 抖音运营人员名称
        /// </summary>
        public string TikTokOperationEmployeeName { get; set; }

        /// <summary>
        /// 抖音今日发布量
        /// </summary>
        public int TikTokSendNum { get; set; }
        /// <summary>
        /// 抖音今日投流费用
        /// </summary>
        public decimal TikTokFlowInvestmentNum { get; set; }

        /// <summary>
        /// 视频号运营人员名称
        /// </summary>
        public string VideoOperationEmployeeName { get; set; }

        /// <summary>
        /// 视频号今日发布量
        /// </summary>
        public int VideoSendNum { get; set; }
        /// <summary>
        /// 视频号今日投流费用
        /// </summary>
        public decimal VideoFlowInvestmentNum { get; set; }

        /// <summary>
        /// 知乎运营人员名称
        /// </summary>
        public string ZhihuOperationEmployeeName { get; set; }

        /// <summary>
        /// 知乎今日发布量
        /// </summary>
        public int ZhihuSendNum { get; set; }
        /// <summary>
        /// 知乎今日投流费用
        /// </summary>
        public decimal ZhihuFlowInvestmentNum { get; set; }

        /// <summary>
        /// 今日发布量
        /// </summary>
        public int TodaySendNum { get; set; }

        /// <summary>
        /// 今日运营渠道投流费用
        /// </summary>
        public decimal FlowInvestmentNum { get; set; }
        /// <summary>
        /// 今日直播间投流费用
        /// </summary>
        public decimal LivingRoomFlowInvestmentNum { get; set; }

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
        /// 今日小黄车退单量
        /// </summary>
        public int MinivanRefund { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        public int MiniVanBadReviews { get; set; }
        /// <summary>
        /// 抖音数据更新时间
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// 直播中数据更新时间
        /// </summary>
        public DateTime? LivingUpdateDate { get; set; }
        /// <summary>
        /// 直播后数据更新时间
        /// </summary>
        public  DateTime? AfterLivingUpdateDate { get; set; }
    }
}
