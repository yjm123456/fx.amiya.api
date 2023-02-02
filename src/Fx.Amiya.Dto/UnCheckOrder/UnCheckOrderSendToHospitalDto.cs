using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.UnCheckOrder
{
    public class UnCheckOrderSendToHospitalDto
    {
        public List<string> idList { get; set; }
        public int HospitalId { get; set; }
    }
}
