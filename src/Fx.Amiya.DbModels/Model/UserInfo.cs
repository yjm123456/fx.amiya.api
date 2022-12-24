using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class UserInfo
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public byte CreateFromType { get; set; }
        public bool Frozen { get; set; }
        public bool Valid { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }
        public string NickName { get; set; }
        public byte Gender { get; set; }
        public string Avatar { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string PersonalSignature { get; set; }
        public string Language { get; set; }
        public string UnionId { get; set; }

        public string WxBindPhone { get; set; }
        public string DetailAddress { get; set; }

        public string SuperiorId { get; set; }
        public List<WxMiniUserInfo> WxMiniUserInfoList { get; set; }
        public List<WxMpUserInfo> WxMpUserInfoList { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<LeaveMessage> LeaveMessageList { get; set; }
        public List<UserInfoUpdateRecord> UserInfoUpdateRecordList { get; set; }
    }
}
