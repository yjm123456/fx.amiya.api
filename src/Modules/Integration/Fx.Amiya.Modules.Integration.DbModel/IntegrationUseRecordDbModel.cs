using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.DbModel
{
   public class IntegrationUseRecordDbModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerId { get; set; }
        public decimal UseQuantity { get; set; }
        public byte UseType { get; set; }
        public decimal AccountBalance { get; set; }
        public int? HandleBy { get; set; }
        public string OrderId { get; set; }

        public List<IntegrationUseDetailRecordDbModel> IntegrationUseDetailRecordList { get; set; }
    }
}
