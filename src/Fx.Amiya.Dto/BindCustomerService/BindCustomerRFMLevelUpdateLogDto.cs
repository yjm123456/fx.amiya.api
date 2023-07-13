using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.BindCustomerService
{
    public class BindCustomerRFMLevelUpdateLogDto
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
