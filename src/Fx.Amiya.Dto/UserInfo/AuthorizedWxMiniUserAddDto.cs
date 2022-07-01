using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.UserInfo
{
  public  class AuthorizedWxMiniUserAddDto
    {
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public byte Gender { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string AvatarUrl { get; set; }
        public string UnionId { get; set; }
        public string AppId { get; set; }
        public string AppPath { get; set; }
        public int Scene { get; set; }
    }
}
