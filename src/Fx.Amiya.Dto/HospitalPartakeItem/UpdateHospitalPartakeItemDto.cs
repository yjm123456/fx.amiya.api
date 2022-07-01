using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.HospitalPartakeItem
{
   public class UpdateHospitalPartakeItemDto
    {
        public int Id { get; set; }
        public int ForenoonCanAppointmentQuantity { get; set; }
        public int AfternoonCanAppointmentQuantity { get; set; }
    }
}
