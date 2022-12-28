using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class OrderReturnBackPriceDto
    {
        public string OrderId { get; set; }
        public decimal ReturnBackPrice { get; set; }
    }
}
