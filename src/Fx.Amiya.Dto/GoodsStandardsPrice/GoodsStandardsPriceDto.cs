﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsStandardsPrice
{
    public class GoodsStandardsPriceDto
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public string Standards { get; set; }
        public decimal Price { get; set; }
    }
}
