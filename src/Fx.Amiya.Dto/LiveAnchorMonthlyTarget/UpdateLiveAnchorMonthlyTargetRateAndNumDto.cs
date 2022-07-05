using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class UpdateLiveAnchorMonthlyTargetRateAndNumDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 当日发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }
        /// <summary>
        /// 当日视频号投流数量
        /// </summary>
        public int CumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 当日直播间投流数量
        /// </summary>
        public int LivingRoomCumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 当日线索量
        /// </summary>
        public int CumulativeCluesNum { get; set; }

        /// <summary>
        /// 当日涨粉量
        /// </summary>
        public int CumulativeAddFansNum { get; set; }

        /// <summary>
        /// 当日加V
        /// </summary>
        public int CumulativeAddWechat { get; set; }
        /// <summary>
        /// 当日99面诊卡
        /// </summary>
        public int CumulativeConsultation { get; set; }
        /// <summary>
        /// 当日99消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed { get; set; }
        /// <summary>
        /// 当日199面诊卡
        /// </summary>
        public int CumulativeConsultation2 { get; set; }
        /// <summary>
        /// 当日199消耗卡
        /// </summary>
        public int CumulativeConsultationCardConsumed2 { get; set; }
        /// <summary>
        /// 当日激活历史面诊
        /// </summary>
        public int CumulativeActivateHistoricalConsultation { get; set; }

        /// <summary>
        /// 当日派单
        /// </summary>
        public int CumulativeSendOrder { get; set; }

        /// <summary>
        /// 当日上门数
        /// </summary>
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 当日成交人数
        /// </summary>
        public int CumulativeDealTarget { get; set; }

        /// <summary>
        /// 当日带货结算佣金金额
        /// </summary>
        public decimal CumulativeCargoSettlementCommission { get; set; }
        /// <summary>
        /// 当日业绩金额
        /// </summary>
        public decimal CumulativePerformance { get; set; }

        /// <summary>
        /// 当日小黄车退单
        /// </summary>
        public int CumulativeMinivanRefund { get; set; }
        /// <summary>
        /// 当日小黄车差评
        /// </summary>
        public int CumulativeMiniVanBadReviews { get; set; }
    }
}
