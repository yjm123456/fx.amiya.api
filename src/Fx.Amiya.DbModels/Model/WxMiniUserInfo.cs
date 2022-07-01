using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class WxMiniUserInfo
    {
        public string Id { get; set; }
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public string AppPath { get; set; }
        public int Scene { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
