using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Dto.CheckBaseInfo
{
    public class CheckInfoDto
    {
        public string Id { get; set; }
        public int CheckState { get; set; }

        public string CheckRemark { get; set; }
        public int CheckBy { get; set; }
    }
}
