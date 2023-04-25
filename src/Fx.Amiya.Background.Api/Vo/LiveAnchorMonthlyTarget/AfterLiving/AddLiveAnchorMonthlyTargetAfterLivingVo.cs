using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorMonthlyTarget.AfterLiving
{
    public class AddLiveAnchorMonthlyTargetAfterLivingVo
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
        /// 目标加V量
        /// </summary>
        public int AddWechatTarget { get; set; }
        /// <summary>
        /// 99消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget { get; set; }


        /// <summary>
        /// 199消耗卡目标
        /// </summary>
        public int ConsultationCardConsumedTarget2 { get; set; }

        /// <summary>
        /// 激活历史面诊数量目标
        /// </summary>
        public int ActivateHistoricalConsultationTarget { get; set; }

        /// <summary>
        /// 派单目标
        /// </summary>
        public int SendOrderTarget { get; set; }



        /// <summary>
        /// 新客上门目标
        /// </summary>
        public int NewCustomerVisitTarget { get; set; }

        /// <summary>
        /// 老客上门目标
        /// </summary>
        public int OldCustomerVisitTarget { get; set; }

        /// <summary>
        /// 上门目标
        /// </summary>
        public int VisitTarget { get; set; }
        /// <summary>
        /// 新诊成交人数目标
        /// </summary>
        public int NewCustomerDealTarget { get; set; }

        /// <summary>
        /// 老客成交人数目标
        /// </summary>
        public int OldCustomerDealTarget { get; set; }

        /// <summary>
        /// 成交人数目标
        /// </summary>
        public int DealTarget { get; set; }

        /// <summary>
        /// 新诊业绩目标
        /// </summary>
        public decimal NewCustomerPerformanceTarget { get; set; }

        /// <summary>
        /// 复诊业绩目标
        /// </summary>
        public decimal SubsequentPerformanceTarget { get; set; }

        /// <summary>
        /// 老客业绩目标
        /// </summary>
        public decimal OldCustomerPerformanceTarget { get; set; }

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
