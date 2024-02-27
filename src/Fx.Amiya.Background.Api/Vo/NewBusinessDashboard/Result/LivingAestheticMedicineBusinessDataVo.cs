using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.NewBusinessDashboard
{
    public class LivingAestheticMedicineBusinessDataVo
    {
        /// <summary>
        /// 设计卡下卡量
        /// </summary>
        public int DesignCardOrder { get; set; }
        /// <summary>
        /// 设计卡下卡量对比时间进度
        /// </summary>
        public decimal DesignCardOrderToDateSchedule { get; set; }
        /// <summary>
        /// 设计卡下卡量目标
        /// </summary>
        public int DesignCardOrderTarget { get; set; }
        /// <summary>
        /// 设计卡下卡量目标达成率
        /// </summary>
        public decimal? DesignCardOrderTargetCompleteRate { get; set; }
        /// <summary>
        /// 设计卡下卡量环比
        /// </summary>
        public decimal? DesignCardOrderChainRatio { get; set; }
        /// <summary>
        /// 设计卡下卡量同比
        /// </summary>
        public decimal? DesignCardOrderYearOnYear { get; set; }
        /// <summary>
        /// 设计卡退卡量
        /// </summary>
        public int DesignCardRefund { get; set; }
        /// <summary>
        /// 设计卡退卡量对比时间进度
        /// </summary>
        public decimal DesignCardRefundToDateSchedule { get; set; }
        /// <summary>
        /// 设计卡退卡量目标
        /// </summary>
        public int DesignCardRefundTarget { get; set; }
        /// <summary>
        /// 设计卡退卡量目标达成率
        /// </summary>
        public decimal? DesignCardRefundTargetCompleteRate { get; set; }
        /// <summary>
        /// 设计卡退卡量环比
        /// </summary>
        public decimal? DesignCardRefundChainRatio { get; set; }
        /// <summary>
        /// 设计卡退卡量同比
        /// </summary>
        public decimal? DesignCardRefundYearOnYear { get; set; }
        /// <summary>
        /// 实际下卡量
        /// </summary>
        public int DesignCardActual { get; set; }
        /// <summary>
        /// 实际卡下卡量对比时间进度
        /// </summary>
        public decimal DesignCardActualToDateSchedule { get; set; }
        /// <summary>
        /// 实际卡下卡量目标
        /// </summary>
        public int DesignCardActualTarget { get; set; }
        /// <summary>
        /// 实际卡下卡量目标达成率
        /// </summary>
        public decimal? DesignCardActualTargetCompleteRate { get; set; }
        /// <summary>
        /// 实际卡下卡量环比
        /// </summary>
        public decimal? DesignCardActualChainRatio { get; set; }
        /// <summary>
        /// 实际卡下卡量同比
        /// </summary>
        public decimal? DesignCardActualYearOnYear { get; set; }
    }
}
