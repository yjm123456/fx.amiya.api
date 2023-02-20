using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Appointment
{
    public class WxAppointmentInfoDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Week { get; set; }
        public string Time { get; set; }
        public byte Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Phone { get; set; }
        public string Remark { get; set; }


        public string ItemInfoName { get; set; }
        public string AppointArea { get; set; }
        public AppointmentHospitalDto HospitalInfo { get; set; }

       
    }
}
