﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyTargetLivingDto
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
        /// 直播间投流目标
        /// </summary>
        public decimal LivingRoomFlowInvestmentTarget { get; set; }
        /// <summary>
        /// 99面诊卡目标
        /// </summary>
        public int ConsultationTarget { get; set; }
        /// <summary>
        /// 199面诊卡目标
        /// </summary>
        public int ConsultationTarget2 { get; set; }
        /// <summary>
        /// 带货结算佣金目标
        /// </summary>
        public decimal CargoSettlementCommissionTarget { get; set; }
        /// <summary>
        /// 直播中退卡量目标
        /// </summary>
        public int LivingRefundCardTarget { get; set; }

        /// <summary>
        /// GMV
        /// </summary>
        public decimal GMVTarget { get; set; }

        /// <summary>
        /// 去卡GMV
        /// </summary>
        public decimal EliminateCardGMVTarget { get; set; }

    }
}
