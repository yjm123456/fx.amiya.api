using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.DbModels.Model
{
    public class AppointmentActivity:BaseDbModel
    {
        public string  UserId{ get; set; }
        public bool IsAppointment { get; set; }
    }
}
