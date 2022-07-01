using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
   public record ConsumptionIntegrationDto
    {
        public decimal Quantity { get; set; }
        public decimal Percent { get; set; }
        public decimal AmountOfConsumption { get; set; }
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public string ProviderId { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public int HandleBy { get; set; }

    }
}
