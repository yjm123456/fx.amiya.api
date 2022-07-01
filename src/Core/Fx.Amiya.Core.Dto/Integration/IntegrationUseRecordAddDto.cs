using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.Integration
{
    public record IntegrationUseRecordAddDto
    {
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public byte UseType { get; set; }
        public decimal UseQuantity { get; set; }
    }
}
