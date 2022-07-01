using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalAppointmentQuantity
{
   public class AddHospitalAppointmentQuantityDto
    {
        public int HospitalId { get; set; }
        public int ForenoonCanAppointmentNumer { get; set; }
        public int AfternoonCanAppointmentNumer { get; set; }
    }
}
