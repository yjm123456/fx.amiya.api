using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsDemand
{
    public class AddTmallGoodsSkuDto
    {
        public string GoodsId { get; set; }
        public string SkuName { get; set; }
        public decimal Price { get; set; }
        public int? AllCount { get; set; }

        public string CreateHospital { get; set; }
    }
}
