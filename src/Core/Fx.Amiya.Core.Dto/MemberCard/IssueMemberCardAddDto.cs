using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.MemberCard
{
    public record IssueMemberCardAddDto
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 会员级别编号
        /// </summary>
        public byte MemberRankID { get; set; }

        public int HandleBy { get; set; }

        public string MemberCardNum { get; set; }
    }
}
