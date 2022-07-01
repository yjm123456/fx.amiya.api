using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalEmployee
{
   public class AddHospitalEmployeeDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int HospitalId { get; set; }
        public int HospitalPositionId { get; set; }

        public bool IsCreateSubAccount { get; set; }
        public bool IsCustomerService { get; set; }

    }
}
