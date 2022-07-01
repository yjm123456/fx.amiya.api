using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class CustomerDetailInfoVo
    {
        /// <summary>
        /// 积分余额
        /// </summary>
        public decimal IntegrationBalance { get; set; }

        /// <summary>
        /// 会员级别
        /// </summary>
        public string MemberRank { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemberCardNum { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
       
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WechatNumber { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
    }
}
