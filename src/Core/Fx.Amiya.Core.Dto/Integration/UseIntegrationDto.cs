using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record UseIntegrationDto
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }

        public DateTime Date { get; set; }
        public decimal UseQuantity { get; set; }


    }
}
