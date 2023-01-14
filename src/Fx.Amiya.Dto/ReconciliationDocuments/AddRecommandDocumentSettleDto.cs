using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class AddRecommandDocumentSettleDto
    {
        public string RecommandDocumentId { get; set; }
        public string OrderId { get; set; }
        public string DealInfoId { get; set; }

        public int OrderFrom { get; set; }
        public decimal ReturnBackPrice { get; set; }
    }
}
