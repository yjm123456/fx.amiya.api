using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TmallOrder
{
    public class SubordinateOrderDto
    {
        public string GoodsName { get; set; }
        public string GoodsImgUrl { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public string StatusCodeText { get; set; }
    }
}
