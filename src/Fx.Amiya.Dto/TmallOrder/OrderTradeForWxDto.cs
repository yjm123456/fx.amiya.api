using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class OrderTradeForWxDto
    {
        public string TradeId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AddressId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? TotalIntegration { get; set; }
        public string Remark { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }
        

        public List<OrderInfoDto> OrderInfoList { get; set; }
    }
}
