using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LiveAnchorDailyTarget
{
    public class GmvAndRefundGmvDto
    {
        /// <summary>
        /// 下单gmv
        /// </summary>
        public decimal GMV { get; set; }
        /// <summary>
        /// 退款gmv
        /// </summary>
        public decimal RefundGMV { get; set; }
        /// <summary>
        /// 直播间投流
        /// </summary>
        public decimal LivingRoomCumulativeFlowInvestment { get; set; }
        /// <summary>
        /// 抖+投流投流费用
        /// </summary>
        public decimal TikTokPlusNum { get; set; }
        /// <summary>
        /// 千川投流费用
        /// </summary>
        public decimal QianChuanNum { get; set; }
        /// <summary>
        /// 随心推投流费用
        /// </summary>
        public decimal ShuiXinTuiNum { get; set; }
        /// <summary>
        /// 微信豆投流费用
        /// </summary>
        public decimal WeiXinDou { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
    }
}
