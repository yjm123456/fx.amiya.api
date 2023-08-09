using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.LivingDailyTakeGoods.OutPut
{
    public class AutoCompleteTakeGoodsGmvDto
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
