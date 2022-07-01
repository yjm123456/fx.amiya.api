using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
   public class UseIntegration
    {
        public UseIntegration(byte integrationUseType)
        {
            this.UseType = integrationUseType;
        }

        public byte UseType { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public string OrderId { get; set; }
    }
}
