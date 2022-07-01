using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    /// <summary>
    /// 期初积分
    /// </summary>
   public class InitIntegration : Integration
    {
        public InitIntegration()
        {
            base.GenerateType = GenerateType.Init;
        }
    }
}
