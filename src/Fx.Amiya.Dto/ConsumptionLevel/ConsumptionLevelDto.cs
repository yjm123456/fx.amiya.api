﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionLevel
{
    public class ConsumptionLevelDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool Valid { get; set; }
    }
}
