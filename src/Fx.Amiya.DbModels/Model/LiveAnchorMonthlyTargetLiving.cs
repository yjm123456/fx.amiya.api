using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    /// <summary>
    /// 主播月度运营目标情况-直播中
    /// </summary>
    public class LiveAnchorMonthlyTargetLiving
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
        /// 月累计直播间投流数量
        /// </summary>
        public decimal LivingRoomCumulativeFlowInvestment { get; set; }

        /// <summary>
        /// 直播间投流完成率
        /// </summary>
        public decimal LivingRoomFlowInvestmentCompleteRate { get; set; }


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
        public decimal ConsultationCompleteRate { get; set; }


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
        public decimal ConsultationCompleteRate2 { get; set; }

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
        /// 直播中退卡量目标
        /// </summary>
        public int LivingRefundCardTarget { get; set; }
        /// <summary>
        /// 月累计退卡量
        /// </summary>
        public int CumulativeLivingRefundCard { get; set; }
        /// <summary>
        /// 退卡量目标完成率
        /// </summary>
        public decimal LivingRefundCardCompleteRate { get; set; }
        /// <summary>
        /// GMV目标
        /// </summary>
        public decimal GMVTarget { get; set; }
        
        /// <summary>
        /// 月累计GMV
        /// </summary>
        public decimal CumulativeGMV { get; set; }
        /// <summary>
        /// GMV目标完成率
        /// </summary>
        public decimal GMVTargetCompleteRate { get; set; }

        /// <summary>
        /// 退款GMV目标
        /// </summary>
        public decimal RefundGMVTarget { get; set; }
        /// <summary>
        /// 累计退款gmv
        /// </summary>
        public decimal CumulativeRefundGMV { get; set; }
        /// <summary>
        /// 退款gmv完成率
        /// </summary>

        public decimal RefundGMVTargetCompleteRate { get; set; }

        /// <summary>
        /// 去卡GMV目标
        /// </summary>
        public decimal EliminateCardGMVTarget { get; set; }
        /// <summary>
        /// 月累计去卡GMV
        /// </summary>
        public decimal CumulativeEliminateCardGMV { get; set; }
        /// <summary>
        /// 去卡GMV目标完成率
        /// </summary>
        public decimal EliminateCardGMVTargetCompleteRate { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        public LiveAnchor LiveAnchor { get; set; }

        public List<LivingDailyTarget> LivingDailyTargets { get; set; }
    }
}
