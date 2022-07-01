using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
   public class ContentPlatformOrderSend
    {
        public int Id { get; set; }
        public string ContentPlatformOrderId { get; set; }
        public int HospitalId { get; set; }
        public int Sender { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsUncertainDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Remark { get; set; }
        public string HospitalRemark { get; set; }

        public ContentPlatformOrder ContentPlatformOrder { get; set; }
        public AmiyaEmployee AmiyaEmployee { get; set; }
    }
}
