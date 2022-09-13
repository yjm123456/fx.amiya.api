using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Modules.Goods.DbModel
{
    public class GoodsMemberRankPriceDbModel
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public byte MemberRankId { get; set; }
        public decimal Price { get; set; }
        public GoodsInfoDbModel GoodsInfo { get; set; }

    }
}
