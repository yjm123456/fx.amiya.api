using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyLivingTargetRateAndNumDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 当日直播间投流数量
        /// </summary>
        public decimal LivingRoomCumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 当日99面诊卡
        /// </summary>
        public int CumulativeConsultation { get; set; }
        /// <summary>
        /// 当日199面诊卡
        /// </summary>
        public int CumulativeConsultation2 { get; set; }

        /// <summary>
        /// 当日带货结算佣金金额
        /// </summary>
        public decimal CumulativeCargoSettlementCommission { get; set; }
    }
}
