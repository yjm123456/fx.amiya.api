using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class SendGoodsDto
    {
        public string TradeId{get;set;}
        public string OrderId { get; set; }
        public int HandleBy { get; set; }
        
        /// <summary>
        /// 快递单号
        /// </summary>
        public string CourierNumber { get; set; }
        /// <summary>
        /// 物流公司id
        /// </summary>
        public string ExpressId { get; set; }
    }
}
