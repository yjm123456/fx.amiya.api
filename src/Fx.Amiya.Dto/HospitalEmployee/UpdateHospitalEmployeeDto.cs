using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalEmployee
{
   public class UpdateHospitalEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public bool Valid { get; set; }
        public int HospitalId { get; set; }
        public bool IsCreateSubAccount { get; set; }
        public int HospitalPositionId { get; set; }
        public bool IsCustomerService { get; set; }
    }
}
