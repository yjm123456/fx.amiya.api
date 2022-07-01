using System;
using System.Collections.Generic;
using System.Text;

namespace Fx.Amiya.DbModels.Model
{
   public class SendOrderUpdateRecord
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int OldHospitalId { get; set; }
        public int NewHospitalId { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public HospitalInfo OldHospitalInfo { get; set; }
        public HospitalInfo NewHospitalInfo { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
