using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class SendGoodsRecord
    {
        public int Id { get; set; }
        public string TradeId { get; set; }
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public int HandleBy { get; set; }
        public string CourierNumber{get;set;}
        public string ExpressId { get; set; }
        public OrderTrade OrderTrade { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
