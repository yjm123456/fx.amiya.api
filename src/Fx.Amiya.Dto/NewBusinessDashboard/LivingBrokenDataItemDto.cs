using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.NewBusinessDashboard
{
    public class LivingBrokenDataItemDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        public string BaseLiveAnchorId { get; set; }
        /// <summary>
        /// 下单GMV
        /// </summary>
        public decimal OrderGMV { get; set; }

        /// <summary>
        /// 退款GMV
        /// </summary>
        public decimal RefundGMV { get; set; }

        /// <summary>
        /// 实际回款
        /// </summary>
        public decimal ActualReturnBackMoney { get; set; }

        /// <summary>
        /// 直播付费
        /// </summary>
        public decimal InvestFlow { get; set; }
    }
}
