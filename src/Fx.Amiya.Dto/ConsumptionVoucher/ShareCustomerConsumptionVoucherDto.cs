using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class ShareCustomerConsumptionVoucherDto
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// 分享人id
        /// </summary>
        public string ShareCustomerId { get; set; }
        /// <summary>
        /// 被分享的抵用券id
        /// </summary>
        public string CustomerConsumptionVocherId { get; set; }
    }
}
