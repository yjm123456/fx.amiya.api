using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.OfficialWebsite.Input
{
    public class GoodsOrderDto
    {
        public string Phone { get; set; }
        public string GoodsId { get; set; }
        public int Quantity { get; set; }
        public int? Address { get; set; }
        public string HospitalName { get; set; }
        public string StandardId { get; set; }
        public string Remark { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Sign { get; set; }
    }
}
