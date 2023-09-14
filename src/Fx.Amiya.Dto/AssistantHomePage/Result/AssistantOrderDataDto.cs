using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AssistantHomePage.Result
{
    public class AssistantOrderDataDto
    {
        /// <summary>
        /// 总订单
        /// </summary>
        public int TotalOrderCount { get; set; }
        /// <summary>
        /// 今日新增订单
        /// </summary>
        public int TodayOrderCount { get; set; }
        /// <summary>
        /// 未派单订单
        /// </summary>
        public int UnSendOrderCount { get; set; }
        /// <summary>
        /// 今日成交订单
        /// </summary>
        public int TodayDealOrderCount { get; set; }
    }
}
