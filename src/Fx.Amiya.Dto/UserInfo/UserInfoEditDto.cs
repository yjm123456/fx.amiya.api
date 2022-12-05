using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UserInfo
{
    public class UserInfoEditDto
    {
        public string Id { get; set; }
        public byte Gender { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
    }
}
