using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorMonthlyTarget
{
    public class LivingTargetDto
    {
        /// <summary>
        /// 下单gmv目标
        /// </summary>
        public decimal OrderGMVTarget { get; set; }
        /// <summary>
        /// 退款gmv目标
        /// </summary>
        public decimal RefundGMVTarget { get; set; }
        /// <summary>
        /// 实际回款目标
        /// </summary>
        public decimal ActualReturnBackMoneyTarget { get; set; }
        /// <summary>
        /// 直播付费目标
        /// </summary>
        public decimal InvestFlowTarget { get; set; }
        /// <summary>
        /// 设计卡下卡量目标
        /// </summary>
        public int DesignCardOrderTarget { get; set; }
        /// <summary>
        /// 设计卡退卡量目标
        /// </summary>
        public int DesignCardRefundTarget { get; set; }
        

    }
}
