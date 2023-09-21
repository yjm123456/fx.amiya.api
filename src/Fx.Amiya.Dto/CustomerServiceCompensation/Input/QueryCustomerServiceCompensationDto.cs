using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerServiceCompensation.Input
{
    public class QueryCustomerServiceCompensationDto : BaseQueryDto
    {
        public int? BelongEmpId { get; set; }

        public bool? Valid { get; set; }
    }
}
