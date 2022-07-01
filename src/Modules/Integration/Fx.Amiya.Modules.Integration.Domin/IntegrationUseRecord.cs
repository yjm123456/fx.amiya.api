using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    public class IntegrationUseRecord
    {
        public IntegrationUseRecord(decimal useQuantity, DateTime date, byte useType, string orderId)
        {
            this.UseQuantity = useQuantity;
            this.Date = date;
            this.UseType = useType;
            this.OrderId = orderId;
        }

        public decimal UseQuantity { get; set; }
        public DateTime Date { get; set; }
        public decimal AccountBalance { get; set; }

        public byte UseType { get; set; }
        public string OrderId { get; set; }
    }
}
