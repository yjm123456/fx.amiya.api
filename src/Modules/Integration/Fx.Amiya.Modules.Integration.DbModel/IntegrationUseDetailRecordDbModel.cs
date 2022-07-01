using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.DbModel
{
   public class IntegrationUseDetailRecordDbModel
    {
        public long Id { get; set; }
        public long UseRecordId { get; set; }
        public decimal UseQuantity { get; set; }
        public long? GenerateRecordId { get; set; }

        public IntegrationUseRecordDbModel IntegrationUseRecord { get; set; }
        public IntegrationGenerateRecordDbModel IntegrationGenerateRecord { get; set; }
    }
}
