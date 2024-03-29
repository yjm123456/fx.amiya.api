﻿using System;
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
        /// 当日抖音发布条数
        /// </summary>
        public int CumulativeTikTokRelease { get; set; }

        /// <summary>
        /// 当日抖音投流费用
        /// </summary>

        public decimal CumulativeTikTokFlowinvestment { get; set; }

        /// <summary>
        /// 当日视频号发布条数
        /// </summary>
        public int CumulativeVideoRelease { get; set; }
        /// <summary>
        /// 当日视频号投流费用
        /// </summary>

        public decimal CumulativeVideoFlowinvestment { get; set; }

        /// <summary>
        /// 当日知乎发布条数
        /// </summary>
        public int CumulativeZhihuRelease { get; set; }
        /// <summary>
        /// 当日知乎投流费用
        /// </summary>

        public decimal CumulativeZhihuFlowinvestment { get; set; }

        /// <summary>
        /// 当日小红书发布条数
        /// </summary>
        public int CumulativeXiaoHongShuRelease { get; set; }
        /// <summary>
        /// 当日小红书投流费用
        /// </summary>

        public decimal CumulativeXiaoHongShuFlowinvestment { get; set; }

        /// <summary>
        /// 当日微博发布条数
        /// </summary>
        public int CumulativeSinaWeiBoRelease { get; set; }
        /// <summary>
        /// 当日微博投流费用
        /// </summary>
        public decimal CumulativeSinaWeiBoFlowinvestment { get; set; }

        /// <summary>
        /// 当日发布条数
        /// </summary>
        public int CumulativeRelease { get; set; }
        /// <summary>
        /// 当日运营渠道投流数量
        /// </summary>
        public decimal CumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 当日直播间投流数量
        /// </summary>
        public decimal LivingRoomCumulativeFlowInvestment { get; set; }
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
        /// 当日新客上门数
        /// </summary>
        public int CumulativeNewCustomerVisit { get; set; }

        /// <summary>
        /// 当日老客上门数
        /// </summary>
        public int CumulativeOldCustomerVisit { get; set; }

        /// <summary>
        /// 当日上门数
        /// </summary>
        public int CumulativeVisit { get; set; }

        /// <summary>
        /// 当日新客成交人数
        /// </summary>
        public int CumulativeNewCustomerDealTarget { get; set; }

        /// <summary>
        /// 当日老客成交人数
        /// </summary>
        public int CumulativeOldCustomerDealTarget { get; set; }

        /// <summary>
        /// 当日成交人数
        /// </summary>
        public int CumulativeDealTarget { get; set; }

        /// <summary>
        /// 当日带货结算佣金金额
        /// </summary>
        public decimal CumulativeCargoSettlementCommission { get; set; }

        /// <summary>
        /// 当日新诊绩金额
        /// </summary>
        public decimal CumulativeNewCustomerPerformance { get; set; }

        /// <summary>
        /// 当日复诊业绩金额
        /// </summary>
        public decimal CumulativeSubsequentPerformance { get; set; }

        /// <summary>
        /// 当日老客业绩金额
        /// </summary>
        public decimal CumulativeOldCustomerPerformance { get; set; }

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
