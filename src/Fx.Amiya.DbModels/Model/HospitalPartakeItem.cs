using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
    public class HospitalPartakeItem
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int ActivityId { get; set; }
        public int ItemId { get; set; }

        public bool IsAgreeLivingPrice { get; set; }
        public decimal HospitalPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public int ForenoonCanAppointmentQuantity { get; set; }
        public int AfternoonCanAppointmentQuantity { get; set; }

        public HospitalInfo HospitalInfo { get; set; } 
        public ActivityInfo ActivityInfo { get; set; }
        public ItemInfo ItemInfo { get; set; }
    }
}
