using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsMemberRankPrice
{
    public class GoodsMemberRankPriceAddVo
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public byte MemberRankId { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
