using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.Dto.Appointment
{
    public class AppointmentInfoDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Week { get; set; }

        /// <summary>
        /// 上午/下午
        /// </summary>
        public string Time { get; set; }
        public byte Status { get; set; }
        public string StatusText { get; set; }
        public string ItemName { get; set; }
        public string Phone { get; set; }
        public string PhoneRes { get; set; }
        public string EncryptPhone { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime SubmitDate { get; set; }
       
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
   
        public string Remark { get; set; }

        public string EmpolyeeName{ get; set; }

    }
}
