using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.BindCustomerService
{
   public class AddBindCustomerServiceDto
    {
        public int CustomerServiceId { get; set; }
        public List<string> OrderIdList { get; set; }
    }
}
