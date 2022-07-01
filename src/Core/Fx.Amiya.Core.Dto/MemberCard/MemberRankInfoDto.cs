using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Core.Dto.MemberCard
{
    public record MemberRankInfoDto
    {
        public byte ID { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 最低消费金额（预留）
        /// </summary>
        public decimal MinAmount { get; set; }
        /// <summary>
        /// 最高消费金额（预留）
        /// </summary>
        public decimal MaxAmount { get; set; }
        /// <summary>
        /// 享受折扣（预留）
        /// </summary>
        public decimal Sconto { get; set; }
        /// <summary>
        /// 本人产生积分比例（预留）
        /// </summary>
        public decimal GenerateIntegrationPercent { get; set; }
        /// <summary>
        /// 本人消费介绍人产生积分比例（预留）
        /// </summary>
        public decimal ReferralsIntegrationPercent { get; set; }
        public bool Valid { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 是否默认(默认只能有一个）
        /// </summary>
        public bool Default { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// 会员等级代码
        /// </summary>
        public string RankCode { get; set; }

    }
}
