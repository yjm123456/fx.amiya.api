using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.GoodsMemberRankPrice
{
    public class GoodsMemberRankPriceVo
    {
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int MemberRankId { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string MemberCardName { get; set; }
        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
