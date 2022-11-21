using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class CustomerBaseInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string Occupation { get; set; }

        public bool PersonalWechat { get; set; }
        public bool BusinessWeChat { get; set; }
        public bool WechatMiniProgram { get; set; }
        public bool OfficialAccounts { get; set; }
        public string OtherPhone { get; set; }
        public string DetailAddress { get; set; }
        public bool IsSendNote { get; set; }
        public bool IsCall { get; set; }
        public bool IsSendWeChat { get; set; }
        public string UnTrackReason { get; set; }
        public int CustomerState { get; set; }
        public string CustomerRequirement { get; set; }
        public string WechatNumber { get; set; }
        public string City { get; set; }

        public string Remark { get; set; }
    }
}
