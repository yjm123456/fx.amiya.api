using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.UserInfo
{
    public class UserEditInfoVo
    {
        
        public byte Gender { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string NickName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string PersonalSignature { get; set; }
        public string UserAvatar { get; set; }
    }
}
