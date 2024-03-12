using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OfficialWebsite.Input
{
    public class GetDesignOrderSignDto
    {
       
        public string NickName { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }
       
        public DateTime? BirthDay { get; set; }
        
        public string Profession { get; set; }
        
        public string WechatRemark { get; set; }
        
        public string City { get; set; }
    }
}
