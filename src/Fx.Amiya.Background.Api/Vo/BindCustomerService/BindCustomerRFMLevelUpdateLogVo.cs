using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fx.Amiya.Background.Api.Vo.BindCustomerService
{
    public class BindCustomerRFMLevelUpdateLogVo
    {
        public string Id { get; set; }
        public string CustomerServiceName { get; set; }
        public string Phone { get; set; }
        public string EncryptPhone { get; set; }
        public string From { get; set; }

        public string To { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
