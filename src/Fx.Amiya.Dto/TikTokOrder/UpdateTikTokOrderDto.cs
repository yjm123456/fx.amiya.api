using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TikTokOrder
{
    public class UpdateTikTokOrderDto
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
