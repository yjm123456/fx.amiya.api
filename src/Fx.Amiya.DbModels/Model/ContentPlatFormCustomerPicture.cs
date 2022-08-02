using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class ContentPlatFormCustomerPicture
    {
        public string Id { get; set; }
        public string ContentPlatFormOrderId { get; set; }
        public string CustomerPicture { get; set; }

        public string OrderDealId { get; set; }
        public string Description { get; set; }

        public ContentPlatformOrder ContentPlatFormOrderInfo { get; set; }
    }
}
