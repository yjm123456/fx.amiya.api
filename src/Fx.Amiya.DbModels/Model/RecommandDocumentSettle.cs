using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class RecommandDocumentSettle
    {
        public string Id { get; set; }
        public string RecommandDocumentId { get; set; }
        public string OrderId { get; set; }
        public string DealInfoId { get; set; }

        public int OrderFrom { get; set; }
        public decimal ReturnBackPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsSettle { get; set; }
        public DateTime? SettleDate { get; set; }

    }
}
