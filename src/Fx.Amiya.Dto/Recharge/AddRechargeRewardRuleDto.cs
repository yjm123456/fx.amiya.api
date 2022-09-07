using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.Recharge
{
    public class AddRechargeRewardRuleDto
    {
        public string Id { get; set; }
        public decimal MinAmount { get; set; }
        public decimal GiveMoney { get; set; }
        public decimal GiveIntegration { get; set; }   
    }
}
