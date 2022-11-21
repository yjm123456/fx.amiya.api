using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerBaseInfo
{
    public class CustomerBaseInfoDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 绑定客服列表编号
        /// </summary>
        public int BindCustomerServiceId { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 客户昵称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>

        public string MemberCardNo { get; set; }
        /// <summary>
        /// 会员卡名称
        /// </summary>
        public string MemberRankName { get; set; }

        /// <summary>
        /// 建档时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 累计消费
        /// </summary>
        public decimal? AllPrice { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
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
        /// 首次项目需求
        /// </summary>
        public string FirstProjectDemand { get; set; }

        /// <summary>
        /// 最新消费平台
        /// </summary>
        public int? NewConsumptionContentPlatform { get; set; }
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
        /// 归属客服
        /// </summary>
        public string BelongCustomerService { get; set; }

        /// <summary>
        /// 最新消费渠道
        /// </summary>
        public string NewContentPlatForm { get; set; }

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
        /// 消费等级
        /// </summary>
        public string ConsumptionLevel { get; set; }
        /// <summary>
        /// 客户状态
        /// </summary>
        public int CustomerState { get; set; }
        /// <summary>
        /// 客户需求
        /// </summary>
        public string CustomerRequirement { get; set; }
        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WechatNumber { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
