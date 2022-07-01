using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.UserInfo
{
   public class UnauthorizedWxMiniUserAddDto
    {
        public string AppPath { get; set; }
        public int Scene { get; set; }
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public string AppId { get; set; }
    }
}
