using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.ContentPlateFormOrder
{
    public class QueryOnlyMainHospitalOrderByPageDto:BaseQueryDto
    {
        public int employeeId { get; set; }
        public int? OrderStatus { get; set; }
        public int? HospitalId { get; set; }
    }
}
