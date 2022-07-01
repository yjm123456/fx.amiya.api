using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
  public  class UserInfoUpdateRecord
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime LatestUpdateDate { get; set; }

        public UserInfo UserInfo { get; set; }
    }
}
