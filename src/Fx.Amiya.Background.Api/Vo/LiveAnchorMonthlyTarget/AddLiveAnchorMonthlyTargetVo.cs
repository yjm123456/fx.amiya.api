using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget
{
    /// <summary>
    /// 添加主播月度目标情况
    /// </summary>
    public class AddLiveAnchorMonthlyTargetVo
    {
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
        /// 视频号投流目标
        /// </summary>
        public int FlowInvestmentTarget { get; set; }
        /// <summary>
        /// 直播间投流目标
        /// </summary>
        public int LivingRoomFlowInvestmentTarget { get; set; }

        /// <summary>
        /// 线索目标
        /// </summary>
        public int CluesTarget { get; set; }

        /// <summary>
        /// 涨粉目标
        /// </summary>
        public int AddFansTarget { get; set; }

        /// <summary>
        /// 目标加V量
        /// </summary>
        public int AddWechatTarget { get; set; }
        /// <summary>
        /// 面诊卡目标
        /// </summary>
        public int ConsultationTarget { get; set; }

        /// <summary>
        /// 消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget { get; set; }

        /// <summary>
        /// 激活历史面诊数量目标
        /// </summary>
        public int ActivateHistoricalConsultationTarget { get; set; }

        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }

        /// <summary>
        /// 上门目标
        /// </summary>
        public int VisitTarget { get; set; }

        /// <summary>
        /// 成交人数目标
        /// </summary>
        public int DealTarget { get; set; }
        /// <summary>
        /// 带货结算佣金目标
        /// </summary>
        public decimal CargoSettlementCommissionTarget { get; set; }

        /// <summary>
        /// 业绩目标
        /// </summary>
        public decimal PerformanceTarget { get; set; }

        /// <summary>
        /// 小黄车退单总量
        /// </summary>
        public int MinivanRefundTarget { get; set; }

        /// <summary>
        /// 小黄车差评总量
        /// </summary>
        public int MiniVanBadReviewsTarget { get; set; }
    }
}
