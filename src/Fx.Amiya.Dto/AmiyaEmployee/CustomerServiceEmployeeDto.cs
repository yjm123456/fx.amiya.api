using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
  public  class CustomerServiceEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int BindCustomerQuantity { get; set; }
        public int BindOrderQuantity { get; set; }
    }
}
