using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class UpdateOrderDto
    {
        public string OrderId { get; set; }

        public byte? AppType { get; set; }
        public string StatusCode { get; set; }

        public decimal? Actual_payment { get; set; }

        public decimal? IntergrationQuantity { get; set; }
        public string AppointmentHospital { get; set; }
        public string WriteOffCode { get; set; }
    }
}
