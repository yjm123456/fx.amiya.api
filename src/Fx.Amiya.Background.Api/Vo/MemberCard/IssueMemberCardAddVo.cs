using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.MemberCard
{
    public class IssueMemberCardAddVo
    { /// <summary>
      /// 客户编号
      /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 会员级别编号
        /// </summary>
        public byte MemberRankId { get; set; }

        /// <summary>
        /// 会员卡号，可空，用作发实体黑卡
        /// </summary>
        public string MemberCardNum { get; set; }

    }
}
