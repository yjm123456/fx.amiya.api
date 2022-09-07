using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ConsumptionVoucher
{
    public class UpdateCustomerConsumptionVoucherDto
    {
        public string CustomerVoucherId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UseDate { get; set; }
    }
}
