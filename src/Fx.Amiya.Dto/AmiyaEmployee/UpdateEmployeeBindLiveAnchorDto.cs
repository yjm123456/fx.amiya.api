using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.AmiyaEmployee
{
    public class UpdateEmployeeBindLiveAnchorDto
    {
        public int EmployeeId { get; set; }

        public List<int> LiveAnchorId { get; set; }
    }
}
