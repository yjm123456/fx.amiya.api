using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    //内容平台成交订单业绩相关
    public  class ContentPlatformOrderdealInfoPerformenceDto
    {
        public string Id { get; set; }
        public bool IsDeal { get; set; }
        public DateTime? DealDate { get; set; }
        public bool IsOldCustomer { get; set; }
        public decimal? DealAmount { get; set; }
    }
}
