using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.UserInfo
{
    public class UserInfoEditVo
    {
        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public byte Gender { get; set; }
        public string Language { get; set; }
    }
}
