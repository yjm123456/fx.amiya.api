using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.LivingDailyTakeGoods.Input
{
    public class AutoCompleteGmvDataVo
    {
        /// <summary>
        /// 填报日期
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 月目标id
        /// </summary>
        public string monthTargetId { get; set; }
    }
}
