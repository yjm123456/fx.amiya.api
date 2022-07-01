using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OrderReport
{
    public class AppointmentReportDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Week { get; set; }

        /// <summary>
        /// 上午/下午
        /// </summary>
        public string Time { get; set; }
        public string StatusText { get; set; }
        public string ItemName { get; set; }
        public string Phone { get; set; }

        public string HospitalName { get; set; }

        public string Remark { get; set; }
    }
}
