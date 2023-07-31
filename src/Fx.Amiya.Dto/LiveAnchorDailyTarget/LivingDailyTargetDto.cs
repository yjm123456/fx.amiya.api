using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class LivingDailyTargetDto : BaseDto
    {
        public string LiveAnchorMonthlyTargetId { get; set; }

        public string LiveAnchor { get; set; }

        public int OperationEmpId { get; set; }

        public string OperationEmpName { get; set; }

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

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 今日退卡量
        /// </summary>
        public decimal RefundCard { get; set; }
        /// <summary>
        /// 今日GMV
        /// </summary>
        public decimal GMV { get; set; }

        /// <summary>
        /// 今日去卡GMV
        /// </summary>
        public decimal EliminateCardGMV { get; set; }
        /// <summary>
        /// 今日退款gmv
        /// </summary>
        public decimal RefundGMV { get; set; }
    }
}
