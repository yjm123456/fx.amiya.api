using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ReconciliationDocuments
{
    public class ReconciliationDocumentsCreateBillDto
    {
        public List<string> ReconciliationDocumentsIdList { get; set; }
        public string BillId { get; set; }
        public bool IsCreateBill { get; set; }
    }
}
