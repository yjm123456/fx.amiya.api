using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Appointment
{
  public  class AddAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Week { get; set; }
        public string Time { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreateDate { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }
        public int HospitalId { get; set; }
        public string AppointArea { get; set; }
        public string ItemInfoName { get; set; }
    }
}
