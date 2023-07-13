using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class BindCustomerRFMLevelUpdateLog
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int BindCustomerServiceId { get; set; }
        public int CustomerServiceId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public BindCustomerService BindCustomerService { get; set; }
        public AmiyaEmployee CustomerServiceInfo { get; set; }
    }
}
