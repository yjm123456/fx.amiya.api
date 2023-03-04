using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.GoodsInfo
{
    public class SimpleGoodsInfoDto
    {
        public string GoodsId { get; set; }
        public int ExchageType { get; set; }
        public decimal? Price { get; set; }
        public decimal? IntegralPrice { get; set; }
        public string GoodsPicture { get; set; }
        public string GoodsName { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
