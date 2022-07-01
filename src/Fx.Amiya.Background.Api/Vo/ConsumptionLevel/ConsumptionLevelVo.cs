using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.ConsumptionLevel
{
    public class ConsumptionLevelVo
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool Valid { get; set; }
    }
}
