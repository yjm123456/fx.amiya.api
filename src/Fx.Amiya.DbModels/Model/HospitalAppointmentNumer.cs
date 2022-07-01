using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class HospitalAppointmentNumer
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int ForenoonCanAppointmentNumer { get; set; }
        public int AfternoonCanAppointmentNumer { get; set; }

        public HospitalInfo HospitalInfo { get; set; }

    }
}
