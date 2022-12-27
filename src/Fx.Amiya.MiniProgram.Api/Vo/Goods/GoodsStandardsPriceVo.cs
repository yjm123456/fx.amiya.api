using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Goods
{
    public class GoodsStandardsPriceVo
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public string Standards { get; set; }
        public string StandardsImg { get; set; }
        public decimal Price { get; set; }
    }
}
