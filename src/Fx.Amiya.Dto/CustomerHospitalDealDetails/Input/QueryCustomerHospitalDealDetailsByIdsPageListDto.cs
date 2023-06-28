using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CustomerHospitalDealDetails.Input
{
    public class QueryCustomerHospitalDealDetailsByIdsPageListDto : BaseQueryDto
    {
        public List<string> CustomerHospitalDealIds { get; set; }
    }
}
