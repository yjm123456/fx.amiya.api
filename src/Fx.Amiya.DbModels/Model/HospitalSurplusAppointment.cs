using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalSurplusAppointment
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int ItemId { get; set; }
        public int ForenoonSurplusQuantity { get; set; }
        public int AfternoonSurplusQuantity { get; set; }
        public DateTime Date { get; set; }
        public int Version { get; set; }

        public HospitalInfo HospitalInfo { get; set; }
    }
}
