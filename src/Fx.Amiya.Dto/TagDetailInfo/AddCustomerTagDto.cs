using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.TagDetailInfo
{
    public class AddCustomerTagDto
    {
        public string CustomerId { get; set; }
        public List<string> TagIds { get; set; }
    }
}
