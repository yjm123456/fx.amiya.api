﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class LiveAnchorMonthTargetPerformanceDto
    {
        /// <summary>
        /// 业绩目标
        /// </summary>
        public decimal TotalPerformanceTarget { get; set; }
        /// <summary>
        /// 带货业绩目标
        /// </summary>
        public decimal CommercePerformanceTarget { get; set; }
        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 新客业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }
        /// <summary>
        /// 带货完成业绩
        /// </summary>
        public decimal CommerceCompletePerformance { get; set; }
        /// <summary>
        /// 有效业绩
        /// </summary>
        public decimal EffectivePerformance { get; set; }
        /// <summary>
        /// 潜在业绩
        /// </summary>
        public decimal PotentialPerformance { get; set; }
    }

    public class GroupPerformanceListDto
    {
        /// <summary>
        /// 分组业绩量
        /// </summary>
        public decimal GroupPerformance { get; set; }

        /// <summary>
        /// 分组业绩目标
        /// </summary>
        public decimal GroupTargetPerformance { get; set; }
    }

    public class LiveAnchorBaseBusinessMonthTargetPerformanceDto
    {
        /// <summary>
        /// 加v目标
        /// </summary>
        public int AddWeChatTarget { get; set; }
        /// <summary>
        /// 面诊卡下单目标
        /// </summary>
        public int ConsulationCardTarget { get; set; }

        /// <summary>
        /// 面诊卡退卡目标
        /// </summary>
        public int LivingRefundCardTarget { get; set; }
        /// <summary>
        /// 面诊卡消耗目标
        /// </summary>
        public int ConsulationCardConsumedTarget { get; set; }
        /// <summary>
        /// 历史面诊卡消耗目标
        /// </summary>
        public int HistoryConsulationCardConsumedTarget { get; set; }
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
        /// <summary>
        /// 新客上门目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }

        /// <summary>
        /// 新诊成交人数目标
        /// </summary>
        public int NewCustomerDealTarget { get; set; }

        /// <summary>
        /// 小黄车退款上限
        /// </summary>
        public int ConsulationCardRefundTarget { get; set; }
    }

    public class LiveAnchorBaseBusinessMonthTargetSendOrDealDto
    {
        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }
        /// <summary>
        /// 上门目标
        /// </summary>
        public int TotalVisitTarget { get; set; }
        /// <summary>
        /// 新客上门目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }
        /// <summary>
        /// 老客上门目标
        /// </summary>
        public int OldCustomerVisitTarget { get; set; }

        /// <summary>
        /// 成交目标
        /// </summary>
        public int TotalDealTarget { get; set; }
        /// <summary>
        /// 新客成交目标
        /// </summary>
        public int NewCustomerDealTarget { get; set; }
        /// <summary>
        /// 老客成交目标
        /// </summary>
        public int OldCustomerDealTarget { get; set; }
    }
}
