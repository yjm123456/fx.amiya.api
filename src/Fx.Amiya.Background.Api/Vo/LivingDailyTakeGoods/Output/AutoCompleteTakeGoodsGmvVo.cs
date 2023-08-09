using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Output
{
    public class AutoCompleteTakeGoodsGmvVo
    {
        /// <summary>
        /// 今日gmv
        /// </summary>
        public decimal TodayGMV { get; set; }
        /// <summary>
        /// 今日取卡gmv
        /// </summary>
        public decimal EliminateCardGMV { get; set; }
        /// <summary>
        /// 退款gmv
        /// </summary>
        public decimal RefundGMV { get; set; }
    }
}
