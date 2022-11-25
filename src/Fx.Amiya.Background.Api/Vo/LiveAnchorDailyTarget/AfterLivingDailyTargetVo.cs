using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LiveAnchorDailyTarget
{
    public class AfterLivingDailyTargetVo : BaseVo
    {
        /// <summary>
        /// 主播月目标id
        /// </summary>
        public string LiveAnchorMonthlyTargetId { get; set; }

        /// <summary>
        /// 主播
        /// </summary>
        public string LiveAnchor { get; set; }
        /// <summary>
        /// 网咨人员id
        /// </summary>

        public int OperationEmpId { get; set; }
        /// <summary>
        /// 网咨人员
        /// </summary>

        public string OperationEmpName { get; set; }


        /// <summary>
        /// 今日加V量
        /// </summary>
        public int AddWechatNum { get; set; }

        /// <summary>
        /// 今日99消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed { get; set; }
        /// <summary>
        /// 今日199消耗卡数量
        /// </summary>
        public int ConsultationCardConsumed2 { get; set; }
        /// <summary>
        /// 今日激活历史面诊数量
        /// </summary>
        public int ActivateHistoricalConsultation { get; set; }
        /// <summary>
        /// 今日派单量
        /// </summary>
        public int SendOrderNum { get; set; }

        /// <summary>
        /// 今日新诊上门人数
        /// </summary>
        public int NewVisitNum { get; set; }

        /// <summary>
        /// 今日复诊上门人数
        /// </summary>
        public int SubsequentVisitNum { get; set; }

        /// <summary>
        /// 今日老客上门人数
        /// </summary>
        public int OldCustomerVisitNum { get; set; }

        /// <summary>
        /// 今日上门人数
        /// </summary>
        public int VisitNum { get; set; }
        /// <summary>
        /// 今日新客成交人数
        /// </summary>
        public int NewDealNum { get; set; }
        /// <summary>
        /// 今日复诊成交人数
        /// </summary>
        public int SubsequentDealNum { get; set; }
        /// <summary>
        /// 今日老客成交人数
        /// </summary>
        public int OldCustomerDealNum { get; set; }


        /// <summary>
        /// 今日成交人数
        /// </summary>
        public int DealNum { get; set; }
        /// <summary>
        /// 今日新诊业绩
        /// </summary>
        public decimal NewPerformanceNum { get; set; }
        /// <summary>
        /// 今日复诊业绩
        /// </summary>
        public decimal SubsequentPerformanceNum { get; set; }
        /// <summary>
        /// 今日总新客业绩(新诊业绩+复诊业绩)
        /// </summary>
        public decimal NewCustomerPerformanceCountNum { get; set; }


        /// <summary>
        /// 今日老客业绩
        /// </summary>
        public decimal OldCustomerPerformanceNum { get; set; }

        /// <summary>
        /// 今日业绩
        /// </summary>
        public decimal PerformanceNum { get; set; }
        /// <summary>
        /// 今日小黄车退单量
        /// </summary>
        public int MinivanRefund { get; set; }

        /// <summary>
        /// 今日小黄车差评量
        /// </summary>
        public int MiniVanBadReviews { get; set; }

        /// <summary>
        /// 填报时间
        /// </summary>

        public DateTime RecordDate { get; set; }
    }
}
