﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 商学院月度运营目标情况
    /// </summary>
    public class BusinessCollegeMonthlyTarget
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 月度
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 经营目标名称
        /// </summary>
        public string MonthlyTargetName { get; set; }

        /// <summary>
        /// 主播ID
        /// </summary>
        public int LiveAnchorId { get; set; }

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
        public decimal ReleaseCompleteRate { get; set; }

        /// <summary>
        /// 视频号投流目标
        /// </summary>
        public int FlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计视频号投流数量
        /// </summary>
        public int CumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 视频号投流完成率
        /// </summary>
        public decimal FlowInvestmentCompleteRate { get; set; }

        /// <summary>
        /// 直播间投流目标
        /// </summary>
        public int LivingRoomFlowInvestmentTarget { get; set; }

        /// <summary>
        /// 月累计直播间投流数量
        /// </summary>
        public int LivingRoomCumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 直播间投流完成率
        /// </summary>
        public decimal LivingRoomFlowInvestmentCompleteRate { get; set; }

        /// <summary>
        /// 目标线索量
        /// </summary>
        public int CluesTarget { get; set; }

        /// <summary>
        /// 月累计线索量
        /// </summary>
        public int CumulativeClues { get; set; }

        /// <summary>
        /// 线索完成率
        /// </summary>
        public decimal CluesCompleteRate { get; set; }

        /// <summary>
        /// 涨粉目标
        /// </summary>
        public int AddFansTarget { get; set; }

        /// <summary>
        /// 累计涨粉量
        /// </summary>
        public int CumulativeAddFans { get; set; }

        /// <summary>
        /// 涨粉完成率
        /// </summary>
        public decimal AddFansCompleteRate { get; set; }

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
        public decimal AddWechatCompleteRate { get; set; }


        /// <summary>
        /// 面诊卡目标
        /// </summary>
        public int ConsultationTarget { get; set; }

        /// <summary>
        /// 累计面诊卡
        /// </summary>
        public int CumulativeConsultation { get; set; }

        /// <summary>
        /// 面诊卡完成率
        /// </summary>
        public decimal ConsultationCompleteRate { get; set; }

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
        public decimal SendOrderCompleteRate { get; set; }

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
        public decimal VisitCompleteRate { get; set; }

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
        public decimal DealRate { get; set; }

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
        public decimal CargoSettlementCommissionCompleteRate { get; set; }

        /// <summary>
        /// 业绩目标（包含面诊卡定金）
        /// </summary>
        public decimal PerformanceTarget { get; set; }

        /// <summary>
        /// 月累计业绩金额
        /// </summary>
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 业绩完成率
        /// </summary>
        public decimal PerformanceCompleteRate { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
