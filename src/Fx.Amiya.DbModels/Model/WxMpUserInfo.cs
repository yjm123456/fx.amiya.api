using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class WxMpUserInfo
    {
        public string Id { get; set; }
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime CreateDate { get; set; }
        public int SubscribeCount { get; set; }
        public int SubscribeTime { get; set; }
        public DateTime SubscribeDateTime { get; set; }
        public string Remark { get; set; }
        public int? GroupId { get; set; }
        public string TagIdList { get; set; }
        public string SubscribeScene { get; set; }
        public int? QrScene { get; set; }
        public string QrSceneStr { get; set; }
        public string UserId { get; set; }

        public UserInfo UserInfo { get; set; }

        public List<MpUserSubscribeDetail> SubscribeDetails { get; set; }
    }
}
