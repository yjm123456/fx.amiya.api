using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.MemberRankPrice
{
    public class GoodsMemberRankPriceAddDto
    {
        public string GoodsId{ get; set; }
        public byte MemberRankId { get; set; }
        public decimal Price { get; set; }
    }
}
