using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Modules.Integration.Domin
{
    /// <summary>
    /// 退还礼品，返还积分
    /// </summary>
    public class ReturnGiftIntegration: Integration
    {
        public ReturnGiftIntegration()
        {
            base.GenerateType = GenerateType.ReturnGift;
        }
        public int HandleBy { get; set; }
        public string OrderId { get; set; }
    }
}
