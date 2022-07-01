using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerInfo
{
   public class CustomerBaseInfoDto
    {
        public int Id { get; set; }
        public string EncryptPhone { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public string Occupation { get; set; }
        public string WechatNumber { get; set; }
        public string City { get; set; }
       
    }
}
