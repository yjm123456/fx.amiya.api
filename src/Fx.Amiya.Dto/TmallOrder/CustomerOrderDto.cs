using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.TmallOrder
{
   public  class CustomerOrderDto
    {
        public string Id { get; set; }
       
        public string Phone { get; set; }
    
        public decimal ActualPayment { get; set; }

        public string CustomerId { get; set; }
    }
}
