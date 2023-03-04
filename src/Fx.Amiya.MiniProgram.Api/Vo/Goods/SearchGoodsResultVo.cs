using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.Goods
{
    public class SearchGoodsResultVo
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
