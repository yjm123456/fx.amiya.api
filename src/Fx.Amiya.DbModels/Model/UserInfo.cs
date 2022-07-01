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
        public string NickName { get; set; }
        public byte Gender { get; set; }
        public string Avatar { get; set; }
        public string Language { get; set; }
        public string UnionId { get; set; }

        public string WxBindPhone { get; set; }

        public List<WxMiniUserInfo> WxMiniUserInfoList { get; set; }
        public List<WxMpUserInfo> WxMpUserInfoList { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
        public List<LeaveMessage> LeaveMessageList { get; set; }
        public List<UserInfoUpdateRecord> UserInfoUpdateRecordList { get; set; }
    }
}
