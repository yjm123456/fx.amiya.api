using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public class BindCustomerServiceOrderDto
    {
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public string GoodsId { get; set; }
        public string ThumbPicUrl { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string AppointmentHospital { get; set; }
        public bool IsAppointment { get; set; }
        public string StatusCode { get; set; }
        public string StatusText { get; set; }

        public int CustomerServiceId { get; set; }
        public string CustomerServiceName { get; set; }
        public decimal? ActualPayment { get; set; }

        public byte AppType { get; set; }

        public string AppTypeText { get; set; }
        public int? Quantity { get; set; }
        public decimal? IntegrationQuantity { get; set; }
        public byte? ExchangeType { get; set; }
        public string ExchangeTypeText { get; set; }
        public string TradeId { get; set; }

    }
}
