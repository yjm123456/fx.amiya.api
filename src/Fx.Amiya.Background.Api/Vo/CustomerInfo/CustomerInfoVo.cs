using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class CustomerInfoVo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        public string EncryptPhone { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 绑定客服编号
        /// </summary>
        public int? CustomerServiceId { get; set; }

        /// <summary>
        /// 绑定客服名称
        /// </summary>
        public string CustomerServiceName { get; set; }

        /// <summary>
        /// 会员级别
        /// </summary>
        public string MemberRank { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemberCardNum { get; set; }

        /// <summary>
        /// 积分余额
        /// </summary>
        public decimal? IntegrationBalance { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
