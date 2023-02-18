using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    /// <summary>
    /// 消费积分
    /// </summary>
   public class ConsumptionIntegration: Integration
    {
        public ConsumptionIntegration()
        {
            base.GenerateType = GenerateType.Consumption;
        }

        public string OrderId { get; set; }

        public decimal AmountOfConsumption { get; set; }

        public string ProviderId { get; set; }
        public decimal Percent { get; set; }
        public int? HandleBy { get; set; }
    }
}
