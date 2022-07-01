using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
   public class HandselIntegration: Integration
    {
        public HandselIntegration()
        {
            base.GenerateType = GenerateType.Handsel;
        }
        public int HandleBy { get; set; }
    }
}
