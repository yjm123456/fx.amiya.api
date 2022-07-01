using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BindCustomerService
{
  public  class UpdateBindCustomerServiceDto
    {
        public int CustomerServiceId { get; set; }
        public List<string> EncryptPhoneList { get; set; }
    }
}
