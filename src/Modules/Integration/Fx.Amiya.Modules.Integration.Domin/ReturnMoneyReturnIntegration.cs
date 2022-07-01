using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    /// <summary>
    /// 退费，退还积分
    /// </summary>
   public class ReturnMoneyReturnIntegration: Integration
    {
        public ReturnMoneyReturnIntegration()
        {
            base.GenerateType = GenerateType.ReturnMoneyAndReturnIntegration;
        }
        public string OrderId { get; set; }
    }
}
