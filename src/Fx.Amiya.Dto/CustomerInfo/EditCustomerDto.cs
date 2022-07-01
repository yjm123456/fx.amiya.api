using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.CustomerInfo
{
   public class EditCustomerDto
    {
        public string EncryptPhone { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Occupation { get; set; }
        public string WechatNumber { get; set; }
        public string City { get; set; }
    }
}
