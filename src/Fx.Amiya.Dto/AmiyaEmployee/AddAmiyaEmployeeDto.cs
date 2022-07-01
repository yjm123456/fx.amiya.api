using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
   public class AddAmiyaEmployeeDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public bool IsCustomerService { get; set; }
    }
}
