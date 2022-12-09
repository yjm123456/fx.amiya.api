using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalBindCustomerService
{
  public  class UpdateHospitalBindCustomerServiceDto
    {
        public int HospitalEmployeeId { get; set; }
        public List<string> EncryptPhoneList { get; set; }
    }
}
