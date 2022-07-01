using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.Order
{
    public class OrderDataVo
    {
        /// <summary>
        /// 订单总数
        /// </summary>
        public int TotalOrderQuantity { get; set; }


        /// <summary>
        /// 今天新增订单数量
        /// </summary>
        public int TodayIncrementQuantity { get; set; }


        /// <summary>
        /// 订单状态最新改变时间，null：今天暂无状态改变的订单
        /// </summary>
        public DateTime? LatelyStatusChangeDate { get; set; }


        /// <summary>
        /// 未绑定客服订单数量
        /// </summary>
        public int? UnBindCustoemrServiceQuantity { get; set; }


        /// <summary>
        /// 未派单订单数量
        /// </summary>
        public int UnSendOrderQuantity { get; set; }
    }
}
