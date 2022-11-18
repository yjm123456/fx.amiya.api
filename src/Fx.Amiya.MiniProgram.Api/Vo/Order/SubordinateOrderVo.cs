using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Order
{
    public class SubordinateOrderVo
    {
        public string GoodsName { get; set; }
        public string GoodsImgUrl { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public string StatusCodeText { get; set; }
    }
}
