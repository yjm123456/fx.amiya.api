using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.CustomerInfo
{
    public class UpdateCustomerBaseInfoVo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否为微信来源
        /// </summary>
        public bool PersonalWechat { get; set; }
        /// <summary>
        /// 是否为企业微信来源
        /// </summary>
        public bool BusinessWeChat { get; set; }
        /// <summary>
        /// 是否为小程序来源
        /// </summary>
        public bool WechatMiniProgram { get; set; }
        /// <summary>
        /// 是否为公众号来源
        /// </summary>
        public bool OfficialAccounts { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WechatNumber { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string Occupation { get; set; }
        /// <summary>
        /// 辅助号码（多个号码用逗号分隔开）
        /// </summary>
        public string OtherPhone { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailAddress { get; set; }

        /// <summary>
        /// 是否发短信（回访）
        /// </summary>
        public bool IsSendNote { get; set; }
        /// <summary>
        /// 是否打电话（回访）
        /// </summary>
        public bool IsCall { get; set; }
        /// <summary>
        /// 是否发微信（回访）
        /// </summary>
        public bool IsSendWeChat { get; set; }
        /// <summary>
        /// 不回访原因
        /// </summary>
        public string UnTrackReason { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 标签id集合
        /// </summary>
        public List<string> TagIds { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
    }
}
