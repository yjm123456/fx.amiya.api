using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class GoodsMemberRankPrice
    {
        public string Id { get; set; }
        public string GoodsId { get; set; }
        public int MemberRankId { get; set; }
        public decimal Price { get; set; }

        public  GoodsInfo GoodsInfo { get; set; }

        public MemberCardRankInfo MemberCardRankInfo { get; set; }
    }
}
