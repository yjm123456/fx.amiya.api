using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.FinancialBoard
{
    public class CustomerServiceBoardDataDto
    {
        public string CustomerServiceName { get; set; }
        public decimal DealPrice { get; set; }
        public decimal TotalServicePrice { get; set; }
        public decimal NewCustomerPrice { get; set; }
        public decimal NewCustomerServicePrice { get; set; }
        public decimal OldCustomerPrice { get; set; }
        public decimal OldCustomerServicePrice { get; set; }

    }
}
