using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.MiniProgram.Api.Vo.UserInfo
{
    public class UpdateBirthDayCardVo
    {
        public DateTime BirthDay { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string DetailAddress { get; set; }
        public string Province { get; set; }
    }
}
