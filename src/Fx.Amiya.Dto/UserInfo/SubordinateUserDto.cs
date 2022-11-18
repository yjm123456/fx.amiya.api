using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UserInfo
{
    public class SubordinateUserDto
    {
        public string NickName { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string CustomerId { get; set; }
    }
}
