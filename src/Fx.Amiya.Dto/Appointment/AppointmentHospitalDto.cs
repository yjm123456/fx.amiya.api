using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Appointment
{
   public class AppointmentHospitalDto
    {
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string ThumbPicture { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string HospitalPhone { get; set; }
        public string Address { get; set; }
    }
}
